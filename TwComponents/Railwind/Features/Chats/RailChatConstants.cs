namespace Railwind.Features.Chats;

public static class RailChatConstants
{
    public const string CHAT_GROUP = "chat-group";
    public const string CHAT_HUB_URL = "/chat-hub";
    public const string CHAT_RECEIVE_MESSAGE = "receive-message";
    public const string CHAT_SEND_MESSAGE = "send-message";
    
    public static string BuildChatGroup<T> (T chatId) => $"{CHAT_GROUP}-{chatId.ToString()}";  

}