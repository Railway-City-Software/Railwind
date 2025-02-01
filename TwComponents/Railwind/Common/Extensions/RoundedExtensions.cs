using Railwind.Common.Enums;

namespace Railwind.Common.Extensions;

public static class RoundedExtensions
{
    public static string ToClassName(this Rounded rounded)
    {
        switch (rounded)
        {
            case Rounded.None:
                return "rounded-none";
            case Rounded.Sm:
                return "rounded-sm";
            case Rounded.Md:
                return "rounded-md";
            case Rounded.Lg:
                return "rounded-lg";
            case Rounded.Xl:
                return "rounded-xl";
            case Rounded.Xl2:
                return "rounded-2xl";
            case Rounded.Xl3:
                return "rounded-3xl";
            case Rounded.Xl4:
                return "rounded-4xl";
            case Rounded.Default:
                return "rounded";
            default:
                return "rounded-none";
        }
    }
}