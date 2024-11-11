using Railwind.Common.Enums;

namespace Railwind.Common.Extensions;

public static class RoundedExtensions
{
    public static string ToClassName(this Rounded rounded)
    {
        switch (rounded)
        {
            case Rounded.None:
                return "rw-rounded-none";
            case Rounded.Sm:
                return "rw-rounded-sm";
            case Rounded.Md:
                return "rw-rounded-md";
            case Rounded.Lg:
                return "rw-rounded-lg";
            case Rounded.Xl:
                return "rw-rounded-xl";
            case Rounded.Xl2:
                return "rw-rounded-2xl";
            case Rounded.Xl3:
                return "rw-rounded-3xl";
            case Rounded.Xl4:
                return "rw-rounded-4xl";
            case Rounded.Default:
                return "rw-rounded";
            default:
                return "rw-rounded-none";
        }
    }
}