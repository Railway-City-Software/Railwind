namespace Railwind.Features.Chats;

public class MessagePayload
{
    /// <summary>
    /// SenderId is the id of the user who sent the message
    /// </summary>
    public int SenderId { get; set; } = default!;
    
    /// <summary>
    /// Represents the chat Id
    /// </summary>
    public int ChatId { get; set; } = default!;

    /// <summary>
    /// This is used for the SignalR address
    /// </summary>
    // public string TargetAddress { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime UtcSentTime { get; set; }
    
    public string Initials => FullName.Split(" ").Select(s => s[0]).Aggregate("", (current, c) => current + c);

    public string FullName { get; set; } = string.Empty;
}