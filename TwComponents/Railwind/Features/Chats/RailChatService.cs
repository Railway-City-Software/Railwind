using Microsoft.AspNetCore.SignalR;
using Railwind.Common.Enums;
using Railwind.Common.Models;

namespace Railwind.Features.Chats;

public abstract class RailChatService<TAccountId, TChatId>(RailChatHub<TAccountId, TChatId> railChatHub)
{
    public async Task<Outcome> SendMessage(MessagePayload<TAccountId, TChatId> messagePayload)
    {
        var outcome = await PreSendMessage(messagePayload);
        
        // send the receive message event to all clients in the chat group
        await railChatHub.Clients.Group(RailChatConstants.BuildChatGroup(messagePayload.ChatId)).SendAsync(RailChatConstants.CHAT_RECEIVE_MESSAGE, messagePayload);

        return outcome;
    }
    
    /// <summary>
    /// Define this method for calling before sending a message. This is useful for saving the message to the database before sending it to the clients.
    /// </summary>
    /// <param name="messagePayload"></param>
    /// <returns></returns>
    public abstract Task<Outcome> PreSendMessage(MessagePayload<TAccountId, TChatId> messagePayload);

    /// <summary>
    /// Use this method to get all messages by chat id. Is generic to allow for different types of chat ids, i.e int, guid, etc.
    /// </summary>
    /// <param name="chatId"></param>
    /// <returns></returns>
    public abstract Task<Outcome<List<MessagePayload<TAccountId, TChatId>>>> GetAllChatMessagesByChatId(TChatId chatId);
}