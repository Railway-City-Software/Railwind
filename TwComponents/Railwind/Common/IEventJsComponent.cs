using Microsoft.JSInterop;

namespace Railwind.Common;

public interface IEventJsComponent
{
    public bool IsActive { get; set; }

    [JSInvokable]
    public void OnClickedOutside();

}