using Microsoft.AspNetCore.Components;
using Railwind.Common;
using Railwind.Common.Enums.Tailwind;
using Railwind.Common.Extensions;
using Railwind.Enums;
using Railwind.Features.Themes;

namespace Railwind.Components.Typography;

public class BaseTypography : RailwindBaseComponent
{
    [Parameter] public string? Text { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public FontWeight? FontWeight { get; set; }
    [Parameter] public Func<FontWeight, string>? WeightExpression { get; set; } = c => c.ToCss();

    [Parameter] public Sizing? Size { get; set; }
    [Parameter] public Func<Sizing, string>? SizeExpression { get; set; } = c => c.ToFontSize();

    [Parameter] public Colors? FontColor { get; set; }
    [Parameter] public Func<Colors, string>? ColorExpression { get; set; }
    
    protected Colors MyFontColor => FontColor ?? ThemeProvider?.TextColor ?? Colors.Black;

    protected string TypographyClassName => ClassName(css =>
    {
        css.Add(WeightExpression!.Invoke(FontWeight!.Value));
        css.Add(SizeExpression!.Invoke(Size!.Value));
        css.Add(ColorExpression!.Invoke(MyFontColor));
    });
}