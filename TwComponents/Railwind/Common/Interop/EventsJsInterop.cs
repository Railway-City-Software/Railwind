using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Railwind.Common;

public class EventsJsInterop(IJSRuntime jsRuntime) : IAsyncDisposable
  
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/Railwind/events.js").AsTask());

    public async Task AddEventListener<T>(ElementReference element ,T @class) where T : class
    {
        var module = await moduleTask.Value;

        await module.InvokeVoidAsync("railwindAddClickOutsideListener", element, DotNetObjectReference.Create(@class));
    }
    
    public async Task RemoveEventListener(ElementReference element)
    {
        var module = await moduleTask.Value;

        await module.InvokeVoidAsync("railwindRemoveClickOutsideListener", element);
    }
    
    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}