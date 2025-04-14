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


    public static string ToTextColorWeight400(this Colors color) => color switch
    {
        Colors.Black => "text-black",
        Colors.White => "text-white",
        Colors.Slate => "text-slate-400",
        Colors.Gray => "text-gray-400",
        Colors.Zinc => "text-zinc-400",
        Colors.Neutral => "text-neutral-400",
        Colors.Stone => "text-stone-400",
        Colors.Red => "text-red-400",
        Colors.Orange => "text-orange-400",
        Colors.Amber => "text-amber-400",
        Colors.Yellow => "text-yellow-400",
        Colors.Lime => "text-lime-400",
        Colors.Green => "text-green-400",
        Colors.Emerald => "text-emerald-400",
        Colors.Teal => "text-teal-400",
        Colors.Cyan => "text-cyan-400",
        Colors.Sky => "text-sky-400",
        Colors.Blue => "text-blue-400",
        Colors.Indigo => "text-indigo-400",
        Colors.Violet => "text-violet-400",
        Colors.Purple => "text-purple-400",
        Colors.Fuchsia => "text-fuchsia-400",
        Colors.Pink => "text-pink-400",
        Colors.Rose => "text-rose-400",
        _ => "text-gray-400"
    };
    
    public static string ToTextColorWeight800(this Colors color) => color switch
    {
        Colors.Black => "text-black",
        Colors.White => "text-white",
        Colors.Slate => "text-slate-800",
        Colors.Gray => "text-gray-800",
        Colors.Zinc => "text-zinc-800",
        Colors.Neutral => "text-neutral-800",
        Colors.Stone => "text-stone-800",
        Colors.Red => "text-red-800",
        Colors.Orange => "text-orange-800",
        Colors.Amber => "text-amber-800",
        Colors.Yellow => "text-yellow-800",
        Colors.Lime => "text-lime-800",
        Colors.Green => "text-green-800",
        Colors.Emerald => "text-emerald-800",
        Colors.Teal => "text-teal-800",
        Colors.Cyan => "text-cyan-800",
        Colors.Sky => "text-sky-800",
        Colors.Blue => "text-blue-800",
        Colors.Indigo => "text-indigo-800",
        Colors.Violet => "text-violet-800",
        Colors.Purple => "text-purple-800",
        Colors.Fuchsia => "text-fuchsia-800",
        Colors.Pink => "text-pink-800",
        Colors.Rose => "text-rose-800",
        _ => "text-gray-800"
    };

    public static string ToBackgroundColorWithOpacity10(this Colors color) => color switch
    {
        Colors.Black => "bg-black",
        Colors.White => "bg-white",
        Colors.Slate => "bg-slate-400/10",
        Colors.Gray => "bg-gray-400/10",
        Colors.Zinc => "bg-zinc-400/10",
        Colors.Neutral => "bg-neutral-400/10",
        Colors.Stone => "bg-stone-400/10",
        Colors.Red => "bg-red-400/10",
        Colors.Orange => "bg-orange-400/10",
        Colors.Amber => "bg-amber-400/10",
        Colors.Yellow => "bg-yellow-400/10",
        Colors.Lime => "bg-lime-400/10",
        Colors.Green => "bg-green-400/10",
        Colors.Emerald => "bg-emerald-400/10",
        Colors.Teal => "bg-teal-400/10",
        Colors.Cyan => "bg-cyan-400/10",
        Colors.Sky => "bg-sky-400/10",
        Colors.Blue => "bg-blue-400/10",
        Colors.Indigo => "bg-indigo-400/10",
        Colors.Violet => "bg-violet-400/10",
        Colors.Purple => "bg-purple-400/10",
        Colors.Fuchsia => "bg-fuchsia-400/10",
        Colors.Pink => "bg-pink-400/10",
        Colors.Rose => "bg-rose-400/10",
        _ => "bg-gray-400/10"
    };

    public static string ToRingColorWithOpacity20(this Colors color) => color switch
    {
        Colors.Black => "ring-black",
        Colors.White => "ring-white",
        Colors.Slate => "ring-slate-400/20",
        Colors.Gray => "ring-gray-400/20",
        Colors.Zinc => "ring-zinc-400/20",
        Colors.Neutral => "ring-neutral-400/20",
        Colors.Stone => "ring-stone-400/20",
        Colors.Red => "ring-red-400/20",
        Colors.Orange => "ring-orange-400/20",
        Colors.Amber => "ring-amber-400/20",
        Colors.Yellow => "ring-yellow-400/20",
        Colors.Lime => "ring-lime-400/20",
        Colors.Green => "ring-green-400/20",
        Colors.Emerald => "ring-emerald-400/20",
        Colors.Teal => "ring-teal-400/20",
        Colors.Cyan => "ring-cyan-400/20",
        Colors.Sky => "ring-sky-400/20",
        Colors.Blue => "ring-blue-400/20",
        Colors.Indigo => "ring-indigo-400/20",
        Colors.Violet => "ring-violet-400/20",
        Colors.Purple => "ring-purple-400/20",
        Colors.Fuchsia => "ring-fuchsia-400/20",
        Colors.Pink => "ring-pink-400/20",
        Colors.Rose => "ring-rose-400/20",
        _ => "ring-gray-400/20"
    };
}