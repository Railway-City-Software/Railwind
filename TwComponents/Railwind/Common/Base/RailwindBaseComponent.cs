using Microsoft.AspNetCore.Components;

namespace Railwind.Common;

public class RailwindBaseComponent : ComponentBase, IEventJsComponent
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Inject] public EventsJsInterop EventsJsInterop { get; set; } = default!;
    public string ClassName(Action<ClassBuilder> action)
    {
        var css = new ClassBuilder();
        
        action(css);
        
        return css;
    }

    public bool IsActive { get; set; }
    
    /// <summary>
    /// On purpose throws not implemented as the components must implement this method
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void OnClickedOutside()
    {
        throw new NotImplementedException();
    }
}

public class RailwindLayoutComponent : LayoutComponentBase, IEventJsComponent
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Inject] public EventsJsInterop EventsJsInterop { get; set; } = default!;
    public string ClassName(Action<ClassBuilder> action)
    {
        var css = new ClassBuilder();
        
        action(css);
        
        return css;
    }

    public bool IsActive { get; set; }
    
    /// <summary>
    /// On purpose throws not implemented as the components must implement this method
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void OnClickedOutside()
    {
        throw new NotImplementedException();
    }
}