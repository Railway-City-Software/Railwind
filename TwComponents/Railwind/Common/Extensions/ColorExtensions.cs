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


    public static string ToTextColorDarkWeight400LightWeight800(this Colors color) => color switch
    {
        Colors.Black => "text-black",
        Colors.White => "text-white",
        Colors.Slate => "text-slate-800 dark:text-slate-400",
        Colors.Gray => "text-gray-800 dark:text-gray-400",
        Colors.Zinc => "text-zinc-800 dark:text-zinc-400",
        Colors.Neutral => "text-neutral-800 dark:text-neutral-400",
        Colors.Stone => "text-stone-800 dark:text-stone-400",
        Colors.Red => "text-red-800 dark:text-red-400",
        Colors.Orange => "text-orange-800 dark:text-orange-400",
        Colors.Amber => "text-amber-800 dark:text-amber-400",
        Colors.Yellow => "text-yellow-800 dark:text-yellow-400",
        Colors.Lime => "text-lime-800 dark:text-lime-400",
        Colors.Green => "text-green-800 dark:text-green-400",
        Colors.Emerald => "text-emerald-800 dark:text-emerald-400",
        Colors.Teal => "text-teal-800 dark:text-teal-400",
        Colors.Cyan => "text-cyan-800 dark:text-cyan-400",
        Colors.Sky => "text-sky-800 dark:text-sky-400",
        Colors.Blue => "text-blue-800 dark:text-blue-400",
        Colors.Indigo => "text-indigo-800 dark:text-indigo-400",
        Colors.Violet => "text-violet-800 dark:text-violet-400",
        Colors.Purple => "text-purple-800 dark:text-purple-400",
        Colors.Fuchsia => "text-fuchsia-800 dark:text-fuchsia-400",
        Colors.Pink => "text-pink-800 dark:text-pink-400",
        Colors.Rose => "text-rose-800 dark:text-rose-400",
        Colors.AthensGray => "text-athens-gray-800 dark:text-athens-gray-400",
        Colors.Woodsmoke => "text-woodsmoke-800 dark:text-woodsmoke-400",
        Colors.TurkishRose => "text-turkish-rose-800 dark:text-turkish-rose-400",
        _ => "text-gray-800 dark:text-gray-400"
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
        Colors.AthensGray => "text-athens-gray-800",
        Colors.Woodsmoke => "text-woodsmoke-800",
        Colors.TurkishRose => "text-turkish-rose-800",
        _ => "text-gray-800"
    };
    
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
        Colors.AthensGray => "text-athens-gray-400",
        Colors.Woodsmoke => "text-woodsmoke-400",
        Colors.TurkishRose => "text-turkish-rose-400",
        _ => "text-gray-400"
    };

    public static string ToBackgroundColorWeight400WithOpacity10(this Colors color) => color switch
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
        Colors.AthensGray => "bg-athens-gray-400/10",
        Colors.Woodsmoke => "bg-woodsmoke-400/10",
        Colors.TurkishRose => "bg-turkish-rose-400/10",
        _ => "bg-gray-400/10"
    };
    
    public static string ToBackgroundColorWeight500(this Colors color) => color switch
    {
        Colors.Black => "bg-black",
        Colors.White => "bg-white",
        Colors.Slate => "bg-slate-500",
        Colors.Gray => "bg-gray-500",
        Colors.Zinc => "bg-zinc-500",
        Colors.Neutral => "bg-neutral-500",
        Colors.Stone => "bg-stone-500",
        Colors.Red => "bg-red-500",
        Colors.Orange => "bg-orange-500",
        Colors.Amber => "bg-amber-500",
        Colors.Yellow => "bg-yellow-500",
        Colors.Lime => "bg-lime-500",
        Colors.Green => "bg-green-500",
        Colors.Emerald => "bg-emerald-500",
        Colors.Teal => "bg-teal-500",
        Colors.Cyan => "bg-cyan-500",
        Colors.Sky => "bg-sky-500",
        Colors.Blue => "bg-blue-500",
        Colors.Indigo => "bg-indigo-500",
        Colors.Violet => "bg-violet-500",
        Colors.Purple => "bg-purple-500",
        Colors.Fuchsia => "bg-fuchsia-500",
        Colors.Pink => "bg-pink-500",
        Colors.Rose => "bg-rose-500",
        Colors.AthensGray => "bg-athens-gray-500",
        Colors.Woodsmoke => "bg-woodsmoke-500",
        Colors.TurkishRose => "bg-turkish-rose-500",
        _ => "bg-gray-500"
    };
    
    public static string ToBackgroundColorWeight900WithOpacity20(this Colors color) => color switch
    {
        Colors.Black => "bg-black",
        Colors.White => "bg-white",
        Colors.Slate => "bg-slate-900/20",
        Colors.Gray => "bg-gray-900/20",
        Colors.Zinc => "bg-zinc-900/20",
        Colors.Neutral => "bg-neutral-900/20",
        Colors.Stone => "bg-stone-900/20",
        Colors.Red => "bg-red-900/20",
        Colors.Orange => "bg-orange-900/20",
        Colors.Amber => "bg-amber-900/20",
        Colors.Yellow => "bg-yellow-900/20",
        Colors.Lime => "bg-lime-900/20",
        Colors.Green => "bg-green-900/20",
        Colors.Emerald => "bg-emerald-900/20",
        Colors.Teal => "bg-teal-900/20",
        Colors.Cyan => "bg-cyan-900/20",
        Colors.Sky => "bg-sky-900/20",
        Colors.Blue => "bg-blue-900/20",
        Colors.Indigo => "bg-indigo-900/20",
        Colors.Violet => "bg-violet-900/20",
        Colors.Purple => "bg-purple-900/20",
        Colors.Fuchsia => "bg-fuchsia-900/20",
        Colors.Pink => "bg-pink-900/20",
        Colors.Rose => "bg-rose-900/20",
        Colors.AthensGray => "bg-athens-gray-900/20",
        Colors.Woodsmoke => "bg-woodsmoke-900/20",
        Colors.TurkishRose => "bg-turkish-rose-900/20",
        _ => "bg-gray-900/20"
    };
    
    public static string ToHoverBackgroundColorWeight900WithOpacity40(this Colors color) => color switch
    {
        Colors.Black => "hover:bg-black",
        Colors.White => "hover:bg-white",
        Colors.Slate => "hover:bg-slate-900/40",
        Colors.Gray => "hover:bg-gray-900/40",
        Colors.Zinc => "hover:bg-zinc-900/40",
        Colors.Neutral => "hover:bg-neutral-900/40",
        Colors.Stone => "hover:bg-stone-900/40",
        Colors.Red => "hover:bg-red-900/40",
        Colors.Orange => "hover:bg-orange-900/40",
        Colors.Amber => "hover:bg-amber-900/40",
        Colors.Yellow => "hover:bg-yellow-900/40",
        Colors.Lime => "hover:bg-lime-900/40",
        Colors.Green => "hover:bg-green-900/40",
        Colors.Emerald => "hover:bg-emerald-900/40",
        Colors.Teal => "hover:bg-teal-900/40",
        Colors.Cyan => "hover:bg-cyan-900/40",
        Colors.Sky => "hover:bg-sky-900/40",
        Colors.Blue => "hover:bg-blue-900/40",
        Colors.Indigo => "hover:bg-indigo-900/40",
        Colors.Violet => "hover:bg-violet-900/40",
        Colors.Purple => "hover:bg-purple-900/40",
        Colors.Fuchsia => "hover:bg-fuchsia-900/40",
        Colors.Pink => "hover:bg-pink-900/40",
        Colors.Rose => "hover:bg-rose-900/40",
        Colors.AthensGray => "hover:bg-athens-gray-900/40",
        Colors.Woodsmoke => "hover:bg-woodsmoke-900/40",
        Colors.TurkishRose => "hover:bg-turkish-rose-900/40",
        _ => "hover:bg-gray-900/40"
    };

    public static string ToRingColorWeight400WithOpacity20(this Colors color) => color switch
    {
        Colors.Black => "ring-black",
        Colors.White => "ring-white",
        Colors.Slate => "dark:ring-slate-400/20",
        Colors.Gray => "dark:ring-gray-400/20",
        Colors.Zinc => "dark:ring-zinc-400/20",
        Colors.Neutral => "dark:ring-neutral-400/20",
        Colors.Stone => "dark:ring-stone-400/20",
        Colors.Red => "dark:ring-red-400/20",
        Colors.Orange => "dark:ring-orange-400/20",
        Colors.Amber => "dark:ring-amber-400/20",
        Colors.Yellow => "dark:ring-yellow-400/20",
        Colors.Lime => "dark:ring-lime-400/20",
        Colors.Green => "dark:ring-green-400/20",
        Colors.Emerald => "dark:ring-emerald-400/20",
        Colors.Teal => "dark:ring-teal-400/20",
        Colors.Cyan => "dark:ring-cyan-400/20",
        Colors.Sky => "dark:ring-sky-400/20",
        Colors.Blue => "dark:ring-blue-400/20",
        Colors.Indigo => "dark:ring-indigo-400/20",
        Colors.Violet => "dark:ring-violet-400/20",
        Colors.Purple => "dark:ring-purple-400/20",
        Colors.Fuchsia => "dark:ring-fuchsia-400/20",
        Colors.Pink => "dark:ring-pink-400/20",
        Colors.Rose => "dark:ring-rose-400/20",
        Colors.AthensGray => "dark:ring-athens-gray-400/20",
        Colors.Woodsmoke => "dark:ring-woodsmoke-400/20",
        Colors.TurkishRose => "dark:ring-turkish-rose-400/20",
        _ => "dark:ring-gray-400/20"
    };
    
    public static string ToRingColorWeight600WithOpacity40(this Colors color) => color switch
    {
        Colors.Black => "ring-black",
        Colors.White => "ring-white",
        Colors.Slate => "ring-slate-600 dark:ring-slate-600/40",
        Colors.Gray => "ring-gray-600 dark:ring-gray-600/40",
        Colors.Zinc => "ring-zinc-600 dark:ring-zinc-600/40",
        Colors.Neutral => "ring-neutral-600 dark:ring-neutral-600/40",
        Colors.Stone => "ring-stone-600 dark:ring-stone-600/40",
        Colors.Red => "ring-red-600 dark:ring-red-600/40",
        Colors.Orange => "ring-orange-600 dark:ring-orange-600/40",
        Colors.Amber => "ring-amber-600 dark:ring-amber-600/40",
        Colors.Yellow => "ring-yellow-600 dark:ring-yellow-600/40",
        Colors.Lime => "ring-lime-600 dark:ring-lime-600/40",
        Colors.Green => "ring-green-600 dark:ring-green-600/40",
        Colors.Emerald => "ring-emerald-600 dark:ring-emerald-600/40",
        Colors.Teal => "ring-teal-600 dark:ring-teal-600/40",
        Colors.Cyan => "ring-cyan-600 dark:ring-cyan-600/40",
        Colors.Sky => "ring-sky-600 dark:ring-sky-600/40",
        Colors.Blue => "ring-blue-600 dark:ring-blue-600/40",
        Colors.Indigo => "ring-indigo-600 dark:ring-indigo-600/40",
        Colors.Violet => "ring-violet-600 dark:ring-violet-600/40",
        Colors.Purple => "ring-purple-600 dark:ring-purple-600/40",
        Colors.Fuchsia => "ring-fuchsia-600 dark:ring-fuchsia-600/40",
        Colors.Pink => "ring-pink-600 dark:ring-pink-600/40",
        Colors.Rose => "ring-rose-600 dark:ring-rose-600/40",
        Colors.AthensGray => "ring-athens-gray-600 dark:ring-athens-gray-600/40",
        Colors.Woodsmoke => "ring-woodsmoke-600 dark:ring-woodsmoke-600/40",
        Colors.TurkishRose => "ring-turkish-rose-600 dark:ring-turkish-rose-600/40",
        _ => "ring-gray-600 dark:ring-gray-600/40"
    };
}
