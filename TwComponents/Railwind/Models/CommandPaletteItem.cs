﻿namespace Railwind.Models;

public partial class CommandPaletteItem<T>
{
    public bool IsSelected { get; set; }
    public bool IsSelectable { get; set; } = true;
    public string Title { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = [];

    public T Value { get; set; } = default!;
}