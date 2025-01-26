using System.Runtime.CompilerServices;
using Railwind.Common.Enums.Tailwind;

namespace Railwind.Common.Extensions;

public static class SizingExtensions
{
    public static string GetSizing(this Sizing size)
    {
        return size switch
        {
            Sizing.Xs => "1",
            Sizing.Sm => "2",
            Sizing.Md => "4",
            Sizing.Lg => "8",
            Sizing.Xl => "10",
            _ => "0"
        };
        
    }
    
    /// <summary>
    /// Easily converts to a tailwind css class i.e p-4 or m-4 or px-4 or gap-x-4
    /// </summary>
    /// <param name="size"></param>
    /// <param name="tailClass"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static string ToTailwind(this Sizing size, string tailClass, Direction? direction = null)
    {
        return $"{tailClass}{direction.GetDirection()}{size.GetSizing()}";
    }
    
    public static string ToPadding(this Sizing size, Direction? direction = null)
    {
        return $"p{direction.GetDirection()}{size.GetSizing()}";
    }
    
    public static string ToMargin(this Sizing size, Direction? direction = null)
    {
        return $"m{direction.GetDirection()}{size.GetSizing()}";
    }
    
}