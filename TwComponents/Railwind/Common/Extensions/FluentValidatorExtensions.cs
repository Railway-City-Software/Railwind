using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using Railwind.Features.Validation;

namespace Railwind.Common.Extensions;


public static class FluentValidatorExtensions
{
    private static readonly char[] Separators = ['.', '['];
    private static readonly List<string> ScannedAssembly = [];
    private static readonly List<AssemblyScanner.AssemblyScanResult> AssemblyScanResults = [];

    private static readonly ConcurrentDictionary<Type, IValidator> ValidatorCache = new();

    public static void AddFluentValidation(
        this EditContext editContext,
        IServiceProvider serviceProvider,
        bool disableAssemblyScanning,
        IValidator? validator,
        FluentValidator fluentValidationValidator)
    {
        ArgumentNullException.ThrowIfNull(editContext, nameof(editContext));

        ValidationMessageStore messages = new(editContext);
        editContext.OnValidationRequested += (async (sender, _) =>
            await ValidateModel((EditContext)sender!, messages, serviceProvider,
                disableAssemblyScanning, fluentValidationValidator, validator));

        editContext.OnFieldChanged += async (_, eventArgs) =>
            await ValidateField(editContext, messages, eventArgs.FieldIdentifier,
                serviceProvider, disableAssemblyScanning, validator);
    }

    private static async Task ValidateModel(
        EditContext editContext,
        ValidationMessageStore messages,
        IServiceProvider serviceProvider,
        bool disableAssemblyScanning,
        FluentValidator fluentValidationValidator,
        IValidator? validator = null)
    {
        validator ??= GetValidatorForModel(serviceProvider, editContext.Model, disableAssemblyScanning);
        if (validator == null)
            return;

        Task<ValidationResult> task = validator.ValidateAsync(fluentValidationValidator.ValidateOptions == null
            ? (fluentValidationValidator.Options == null
                ? new ValidationContext<object>(editContext.Model)
                : ValidationContext<object>.CreateWithOptions(editContext.Model,
                    fluentValidationValidator.Options))
            : (IValidationContext)ValidationContext<object>.CreateWithOptions(editContext.Model,
                fluentValidationValidator.ValidateOptions));

        editContext.Properties["AsyncValidationTask"] = task;
        ValidationResult validationResult = await task;

        messages.Clear();
        foreach (ValidationFailure error in validationResult.Errors)
        {
            FieldIdentifier fieldIdentifier = ToFieldIdentifier(in editContext, error.PropertyName);
            messages.Add(in fieldIdentifier, error.ErrorMessage);
        }

        editContext.NotifyValidationStateChanged();
    }

    private static async Task ValidateField(
        EditContext editContext,
        ValidationMessageStore messages,
        FieldIdentifier fieldIdentifier,
        IServiceProvider serviceProvider,
        bool disableAssemblyScanning,
        IValidator? validator = null)
    {
        string[] memberNames = [fieldIdentifier.FieldName];
        ValidationContext<object> context = new(fieldIdentifier.Model, new PropertyChain(),
            new MemberNameValidatorSelector(memberNames));

        validator ??= GetValidatorForModel(serviceProvider, fieldIdentifier.Model, disableAssemblyScanning);
        if (validator == null)
            return;

        ValidationResult validationResult = await validator.ValidateAsync(context);
        messages.Clear(in fieldIdentifier);
        messages.Add(in fieldIdentifier, validationResult.Errors.Select(error => error.ErrorMessage));
        editContext.NotifyValidationStateChanged();
    }

    private static IValidator? GetValidatorForModel(
        IServiceProvider serviceProvider,
        object model,
        bool disableAssemblyScanning)
    {
        Type modelType = model.GetType();
        Type serviceType = typeof(IValidator<>).MakeGenericType(modelType);

        try
        {
            if (serviceProvider.GetService(serviceType) is IValidator service)
                return service;
        }
        catch (Exception e)
        {
            Trace.TraceError(e.ToString());
        }

        if (disableAssemblyScanning)
            return null;

        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly assembly in
                 assemblies.Where(a => a.FullName != null && !ScannedAssembly.Contains(a.FullName)))
        {
            try
            {
                AssemblyScanResults.AddRange(AssemblyScanner.FindValidatorsInAssembly(assembly));
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            ScannedAssembly.Add(assembly.FullName!);
        }

        Type interfaceValidatorType = typeof(IValidator<>).MakeGenericType(modelType);
        Type? validatorType = AssemblyScanResults
            .FirstOrDefault((i => interfaceValidatorType.IsAssignableFrom(i.InterfaceType)))?.ValidatorType;

        return validatorType != null
            ? ValidatorCache.GetOrAdd(validatorType,
                x => (IValidator)ActivatorUtilities.CreateInstance(serviceProvider, x))
            : default;
    }

    private static FieldIdentifier ToFieldIdentifier(
        in EditContext editContext,
        in string propertyPath)
    {
        object model = editContext.Model;

        int length = propertyPath.IndexOfAny(Separators);
        if (length < 0)
            return new FieldIdentifier(model, propertyPath);

        ReadOnlySpan<char> span = (ReadOnlySpan<char>)propertyPath;
        do
        {
            ReadOnlySpan<char> readOnlySpan = span[..length];
            span = span[(length + 1)..];

            object? obj1;
            if (readOnlySpan.EndsWith((ReadOnlySpan<char>)"]"))
            {
                readOnlySpan = readOnlySpan.Slice(0, readOnlySpan.Length - 1);
                PropertyInfo property = model.GetType().GetProperty("Item");
                if (property != null)
                {
                    Type parameterType = property.GetIndexParameters()[0].ParameterType;
                    object obj2 = Convert.ChangeType(readOnlySpan.ToString(), parameterType);
                    obj1 = property.GetValue(model, new object[1] { obj2 });
                }
                else
                {
                    if (model is not object[] objArray)
                        throw new InvalidOperationException(
                            $"Could not find indexer on object of type {model.GetType().FullName}.");

                    int index = int.Parse(readOnlySpan);
                    obj1 = objArray[index];
                }
            }
            else
            {
                PropertyInfo? property = model.GetType().GetProperty(readOnlySpan.ToString());
                if (property == null)
                {
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new(50, 2);
                    interpolatedStringHandler.AppendLiteral("Could not find property named ");
                    interpolatedStringHandler.AppendFormatted(readOnlySpan.ToString());
                    interpolatedStringHandler.AppendLiteral(" on object of type ");
                    interpolatedStringHandler.AppendFormatted(model.GetType().FullName);
                    interpolatedStringHandler.AppendLiteral(".");
                    throw new InvalidOperationException(interpolatedStringHandler.ToStringAndClear());
                }

                obj1 = property.GetValue(model);
            }

            if (obj1 == null)
                return new FieldIdentifier(model, readOnlySpan.ToString());

            model = obj1;
            length = span.IndexOfAny((ReadOnlySpan<char>)Separators);
        } while (length >= 0);

        return new FieldIdentifier(model, span.ToString());
    }
}