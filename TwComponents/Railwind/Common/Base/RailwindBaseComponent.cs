using Microsoft.AspNetCore.Components;
using Railwind.Common.Enums.Tailwind;
using Railwind.Common.Extensions;

namespace Railwind.Common;

public class RailwindBaseComponent : ComponentBase, IEventJsComponent
{
    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Inject] public EventsJsInterop EventsJsInterop { get; set; } = default!;

    // [Parameter] public Sizing? Padding { get; set; }
    // [Parameter] public Sizing? Margin { get; set; }
    // [Parameter] public Sizing? Spacing { get; set; }
    // [Parameter] public Sizing? Gap { get; set; }

    public string ClassName(Action<ClassBuilder> action)
    {
        var css = new ClassBuilder();

        action(css);

        // TODO: Once I spend time on a more automated less time consuming way to ensure the TW will be generated. Universal methods are useless otherwise
        // css.Add(Padding!.Value.ToTailwind("p"), Padding.HasValue);
        // css.Add(Margin!.Value.ToTailwind("m"), Padding.HasValue);
        // css.Add(Spacing!.Value.ToTailwind("space"), Padding.HasValue);
        // css.Add(Gap!.Value.ToTailwind("gap"), Padding.HasValue);
        // css.Add(Margin!.Value.ToPadding(), Margin.HasValue);
        
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