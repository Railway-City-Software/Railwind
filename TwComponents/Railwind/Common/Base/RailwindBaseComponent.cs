using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Railwind.Common.Enums;
using Railwind.Common.Enums.Tailwind;
using Railwind.Common.Extensions;
using Railwind.Enums;
using Railwind.Features.Themes;

namespace Railwind.Common;

public class RailwindBaseComponent : ComponentBase, IEventJsComponent
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();

    [CascadingParameter] public MyThemeProvider? ThemeProvider { get; set; }

    [Inject] public EventsJsInterop EventsJsInterop { get; set; } = default!;

    [Parameter] public Colors? Color { get; set; }

    [Parameter] public ColorVariant ColorVariant { get; set; } = ColorVariant.Primary;
    [Parameter] public StyleVariant? StyleVariant { get; set; }
    [Parameter] public ShapeVariant? ShapeVariant { get; set; }
    [Parameter] public Width? Width { get; set; }
    [Parameter] public Rounded Rounded { get; set; } = Rounded.Md;

    [Inject] public ILogger<RailwindBaseComponent> Logger { get; set; } = null!;

    public Colors MyColor => GetComponentColor();
    public StyleVariant MyStyleVariant => GetComponentStyle();
    public ShapeVariant MyShapeVariant => GetComponentShape();

    private ShapeVariant GetComponentShape()
    {
        return ShapeVariant ?? ThemeProvider?.ShapeVariant ?? Enums.ShapeVariant.Default;
    }

    private StyleVariant GetComponentStyle()
    {
        return StyleVariant ?? ThemeProvider?.StyleVariant ?? Enums.StyleVariant.Default;
    }

    private Colors GetComponentColor()
    {
        return Color ?? ThemeProvider?.GetColorByVariant(ColorVariant) ?? Colors.Gray;
    }

    public string ClassName(Action<ClassBuilder> action)
    {
        var css = new ClassBuilder();

        action(css);

        return css;
    }

    public bool IsActive { get; set; }

    /// <summary>
    /// Log any message to the console and this will auto attach the file name, method name and line number where it was called.
    /// </summary>
    /// <param name="message">The message you would like to display to the console</param>
    /// <param name="level">Optional: Will automatically select information level></param>
    /// <param name="methodName">Optional: Will automatically grab for you</param>
    /// <param name="filePath">Optional: Will automatically grab for you</param>
    /// <param name="line">Optional: Will automatically grab for you</param>
    protected void Log(string message,
        LogLevel level = LogLevel.Information,
        [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int line = 0)
    {
        // removes the extension, but fails to remove the path
        var fileName = Path.GetFileNameWithoutExtension(filePath);

        // Path fails to parse for the file name, so we need to split the path and get the last element
        // https://github.com/mono/mono/issues/18933
        fileName = fileName.Split("\\").Last();

        switch (level)
        {
            case LogLevel.Trace:
                Logger.LogTrace("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
            case LogLevel.Information:
                Logger.LogInformation("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
            case LogLevel.Warning:
                Logger.LogWarning("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
            case LogLevel.Error:
                Logger.LogError("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
            case LogLevel.Critical:
                Logger.LogCritical("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
            default:
                Logger.LogInformation("{ClassName}.{MethodName}.{LineNumber}: {Message}", fileName, methodName, line, message);
                break;
        }
    }

    /// <summary>
    /// On purpose throws not implemented as the components must implement this method
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void OnClickedOutside()
    {
        throw new NotImplementedException();
    }
}

public class RailwindLayoutComponent : LayoutComponentBase, IEventJsComponent
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Inject] public EventsJsInterop EventsJsInterop { get; set; } = default!;

    public string ClassName(Action<ClassBuilder> action)
    {
        var css = new ClassBuilder();

        action(css);

        return css;
    }

    public bool IsActive { get; set; }

    /// <summary>
    /// On purpose throws not implemented as the components must implement this method
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void OnClickedOutside()
    {
        throw new NotImplementedException();
    }
}