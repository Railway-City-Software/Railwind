using Microsoft.AspNetCore.SignalR;

namespace Railwind.Features.Chats;

/// <summary>
/// Ensure you inherit from Hub as well as IChatHub when using this interface
/// </summary>
public abstract class RailChatHub<TAccountId, TChatId> : Hub
{
    /// <summary>
    /// Default method calls the group based on the chat id
    /// </summary>
    /// <param name="messagePayload"></param>
    public virtual async Task SendMessage(MessagePayload<TAccountId, TChatId> messagePayload)
    {
        await Clients.Group(RailChatConstants.BuildChatGroup(messagePayload.ChatId)).SendAsync(RailChatConstants.CHAT_RECEIVE_MESSAGE, messagePayload);
    }
}