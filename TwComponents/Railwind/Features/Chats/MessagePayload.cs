namespace Railwind.Features.Chats;

public class MessagePayload<TAccount, TChat> where TAccount : notnull where TChat : notnull
{
    /// <summary>
    /// SenderId is the id of the user who sent the message
    /// </summary>
    public TAccount SenderId { get; set; } = default!;
    
    /// <summary>
    /// Represents the chat Id
    /// </summary>
    public TChat ChatId { get; set; } = default!;

    /// <summary>
    /// This is used for the SignalR address
    /// </summary>
    // public string TargetAddress { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime UtcSentTime { get; set; }
    
    public string Initials { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}