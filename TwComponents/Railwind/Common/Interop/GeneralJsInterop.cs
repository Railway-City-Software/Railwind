using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Railwind.Common;

public class GeneralJsInterop(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/Railwind/general.js").AsTask());

    public async Task CopyTextToClipboard(string text) 
    {
        var module = await moduleTask.Value;

        await module.InvokeVoidAsync("copyTextToClipboard", text);
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