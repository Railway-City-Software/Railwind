using Railwind.Common.Enums;
using Railwind.Enums;
using Railwind.Features.Themes;

namespace Railwind.Common.Extensions;

public static class ThemeProviderExtensions
{
    public static Colors GetColorByVariant(this MyThemeProvider themeProvider, ColorVariant colorVariant)
    {
        return colorVariant switch
        {
            ColorVariant.Primary => themeProvider.PrimaryColor,
            ColorVariant.Secondary => themeProvider.SecondaryColor,
            ColorVariant.Accent => themeProvider.AccentColor,
            _ => Colors.Gray
        };
    }
}