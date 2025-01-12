using System.ComponentModel.DataAnnotations;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Railwind.Common.Extensions;

namespace Railwind.Features.Validation;

using FluentValidation;

public class FluentValidator : ComponentBase
{
    [Inject] private IServiceProvider ServiceProvider { get; set; }

    [CascadingParameter] private EditContext? CurrentEditContext { get; set; }

    [Parameter] public IValidator? Validator { get; set; }

    [Parameter] public bool DisableAssemblyScanning { get; set; }

    [Parameter] public Action<ValidationStrategy<object>>? Options { get; set; }

    internal Action<ValidationStrategy<object>>? ValidateOptions { get; set; }

    public bool Validate(Action<ValidationStrategy<object>>? options = null)
    {
        if (this.CurrentEditContext == null)
            throw new NullReferenceException("CurrentEditContext");
        this.ValidateOptions = options;
        try
        {
            return this.CurrentEditContext.Validate();
        }
        finally
        {
            this.ValidateOptions = (Action<ValidationStrategy<object>>)null;
        }
    }

    public async Task<bool> ValidateAsync(Action<ValidationStrategy<object>>? options = null)
    {
        if (this.CurrentEditContext == null)
            throw new NullReferenceException("CurrentEditContext");
        this.ValidateOptions = options;
        bool flag;
        try
        {
            this.CurrentEditContext.Validate();
            object obj;
            if (!this.CurrentEditContext.Properties.TryGetValue((object)"AsyncValidationTask", out obj))
                throw new InvalidOperationException("No pending ValidationResult found");
            ValidationResult validationResult = await (Task<ValidationResult>)obj;
            flag = !this.CurrentEditContext.GetValidationMessages().Any<string>();
        }
        finally
        {
            this.ValidateOptions = (Action<ValidationStrategy<object>>)null;
        }

        return flag;
    }

    protected override void OnInitialized()
    {
        if (this.CurrentEditContext == null)
            throw new InvalidOperationException(
                "FluentValidationValidator requires a cascading parameter of type EditContext. For example, you can use FluentValidationValidator inside an EditForm.");
        this.CurrentEditContext.AddFluentValidation(this.ServiceProvider, this.DisableAssemblyScanning, this.Validator,
            this);
    }
}