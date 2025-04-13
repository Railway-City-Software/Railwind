using Railwind.Enums;

namespace Railwind.Common.Extensions;

public static class ColorExtensions
{
    /// <summary>
    /// Combines a color and weight to generate a Tailwind CSS text color class (e.g., "text-gray-900").
    /// </summary>
    /// <param name="color">The Tailwind color (e.g., Colors.Gray).</param>
    /// <param name="weight">The weight or shade (e.g., Weight.Weight900).</param>
    /// <returns>A Tailwind text color class string (e.g., "text-gray-900").</returns>
    public static string ToTextColor(this Colors color, Weight weight)
    {
        // Convert color enum to lowercase Tailwind color name
        string colorName = color.ToString().ToLower();

        // Extract the numeric weight value (e.g., Weight900 -> 900)
        int weightValue = (int)weight;

        // Return formatted Tailwind text color class
        return $"text-{colorName}-{weightValue}";
    }
    
    
}