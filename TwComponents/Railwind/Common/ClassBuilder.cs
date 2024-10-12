using System.Diagnostics;
using System.Text;

namespace Railwind.Common;

public record ClassBuilder
{
    private readonly StringBuilder _builder = new();
    public ClassBuilder Add(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return this;
        
        // always add a space before adding a new class
        if (!string.IsNullOrWhiteSpace(_builder.ToString()))
            _builder.Append(' ');
        
        _builder.Append(name);
        return this;
    }

    public ClassBuilder Add(string name, bool condition) => condition ? Add(name) : this;

    public static implicit operator string(ClassBuilder self) => self.ClassList;
    public string ClassList => _builder.ToString();
    public override string? ToString() => ClassList;
}