using Railwind.Enums;

namespace Railwind.Common.Extensions;


public static class FontWeightExtensions
{
    public static string ToCss(this FontWeight fontWeight)
    {
        return fontWeight switch
        {
            FontWeight.Thin => "font-thin",
            FontWeight.ExtraLight => "font-extralight",
            FontWeight.Light => "font-light",
            FontWeight.Normal => "font-normal",
            FontWeight.Medium => "font-medium",
            FontWeight.SemiBold => "font-semibold",
            FontWeight.Bold => "font-bold",
            FontWeight.ExtraBold => "font-extrabold",
            FontWeight.Black => "font-black",
            _ => throw new ArgumentOutOfRangeException(nameof(fontWeight), fontWeight, null)
        };
    }
}