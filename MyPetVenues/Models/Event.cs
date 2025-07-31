namespace MyPetVenues.Models;

public class Event
{
    public int Id { get; set; }
    public required int OrganizerId { get; set; }
    public required int LocationId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public int MaxAttendees { get; set; } = 0; // 0 = unlimited
    public EventType Type { get; set; } = EventType.Meetup;
    public EventStatus Status { get; set; } = EventStatus.Upcoming;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    
    // Navigation properties
    public User? Organizer { get; set; }
    public Location? Location { get; set; }
    public List<EventRsvp> Rsvps { get; set; } = new();
}

public class EventRsvp
{
    public int Id { get; set; }
    public required int EventId { get; set; }
    public required int UserId { get; set; }
    public RsvpStatus Status { get; set; } = RsvpStatus.Going;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Event? Event { get; set; }
    public User? User { get; set; }
}

public enum EventType
{
    Meetup,
    Training,
    Adoption,
    Social,
    Competition,
    Other
}

public enum EventStatus
{
    Upcoming,
    InProgress,
    Completed,
    Cancelled
}

public enum RsvpStatus
{
    Going,
    Maybe,
    NotGoing
}