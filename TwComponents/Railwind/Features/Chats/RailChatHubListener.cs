using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Railwind.Features.Chats;

/// <summary>
/// This is an abstract class, you need to inherit from this class and implement the HandleReceivedMessage method. Always implement IAsyncDisposable and call ChatHubListeners dispose method when the component is disposed.
/// </summary>
/// <warning>Must implement HandleReceivedMessage</warning>
/// <param name="navigation"></param>
/// <typeparam name="TAccount"></typeparam>
/// <typeparam name="TChat"></typeparam>
public class RailChatHubListener<TAccount, TChat>(NavigationManager navigation) : IAsyncDisposable where TAccount : notnull where TChat : notnull
{
    private HubConnection? HubConnection { get; set; }
    
    // Event that can be subscribed to
    public event Action<MessagePayload<TAccount, TChat>>? OnMessageReceived;

    /// <summary>
    /// Initializes the hub connection and sets up the OnReceiveMessage event
    /// </summary>
    public virtual async Task InitializeHubConnectionAsync()
    {
        HubConnection = new HubConnectionBuilder()
            .WithUrl(navigation.ToAbsoluteUri(RailChatConstants.CHAT_HUB_URL))
            .Build();

        HubConnection.On<MessagePayload<TAccount, TChat>>(RailChatConstants.CHAT_RECEIVE_MESSAGE, HandleReceivedMessage);

        await HubConnection.StartAsync();
    }

    /// <summary>
    /// Method for handling the received message by default invokes all subscribed events
    /// </summary>
    /// <param name="payload"></param>
    public virtual void HandleReceivedMessage(MessagePayload<TAccount, TChat> payload)
    {
        // notify all subscribers
        OnMessageReceived?.Invoke(payload);
    }

    /// <summary>
    /// 
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (HubConnection != null) await HubConnection.DisposeAsync();
        
        OnMessageReceived = null;
    }
}