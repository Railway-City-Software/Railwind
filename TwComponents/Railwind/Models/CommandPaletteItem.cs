namespace Railwind.Models;

public partial class CommandPaletteItem<T>
{
    public bool IsSelected { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    
    public T Value { get; set; } = default!;
}