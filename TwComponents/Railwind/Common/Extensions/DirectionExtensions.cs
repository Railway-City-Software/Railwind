using System.Runtime.CompilerServices;
using Railwind.Common.Enums.Tailwind;

namespace Railwind.Common.Extensions;

public static class DirectionExtensions
{
    public static string GetDirection(this Direction? direction)
    {
        switch (direction)
        {
            case null:
                return "-";

            case Direction.Bottom:
                return "b-";

            case Direction.X:
                return "x-";

            case Direction.Y:
                return "y-";

            case Direction.Top:
                return "t-";

            case Direction.Left:
                return "l-";

            case Direction.Right:
                return "r-";

            default:
                return "-";
        }
    }
}