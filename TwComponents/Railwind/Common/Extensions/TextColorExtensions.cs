using Railwind.Enums;

namespace Railwind.Common.Extensions;

public static class TextColorExtensions
{
    public static string GetTextColor400(Colors color) => color switch 
    {
        Colors.Black => "text-black",
        Colors.White => "text-white",
        Colors.Slate => "text-slate-400",
        Colors.Gray => "bg-gray-400",
        Colors.Zinc => "bg-zinc-400",
        Colors.Neutral => "bg-neutral-400",
        Colors.Stone => "bg-stone-400",
        Colors.Red => "bg-red-400",
        Colors.Orange => "bg-orange-400",
        Colors.Amber => "bg-amber-400",
        Colors.Yellow => "bg-yellow-400",
        Colors.Lime => "bg-lime-400",
        Colors.Green => "bg-green-400",
        Colors.Emerald => "bg-emerald-400",
        Colors.Teal => "bg-teal-400",
        Colors.Cyan => "bg-cyan-400",
        Colors.Sky => "bg-sky-400",
        Colors.Blue => "bg-blue-400",
        Colors.Indigo => "bg-indigo-400",
        Colors.Violet => "bg-violet-400",
        Colors.Purple => "bg-purple-400",
        Colors.Fuchsia => "bg-fuchsia-400",
        Colors.Pink => "bg-pink-400",
        Colors.Rose => "bg-rose-400",
        _ => "bg-gray-400"
    };
}