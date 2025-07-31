namespace MyPetVenues.Models;

public class Message
{
    public int Id { get; set; }
    public required int SenderId { get; set; }
    public required int RecipientId { get; set; }
    public required string Content { get; set; }
    public required string Subject { get; set; }
    public MessageType Type { get; set; } = MessageType.Direct;
    public MessageStatus Status { get; set; } = MessageStatus.Sent;
    public bool IsRead { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReadDate { get; set; }
    public List<string> Attachments { get; set; } = new();
    
    // Navigation properties
    public User? Sender { get; set; }
    public User? Recipient { get; set; }
}

public class UserPrivacySettings
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public bool AllowMessagesFromAnyone { get; set; } = true;
    public bool AllowEventInvites { get; set; } = true;
    public bool ShowProfileToEveryone { get; set; } = true;
    public bool ShowLocationHistory { get; set; } = false;
    
    // Navigation properties
    public User? User { get; set; }
}

public enum MessageType
{
    Direct,
    EventInvite,
    System,
    Notification
}

public enum MessageStatus
{
    Sent,
    Delivered,
    Failed
}