namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
    public decimal Rating { get; set; }
    public int ReviewCount { get; set; }
    public string ContactEmail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<TimeSlot> AvailableSlots { get; set; } = new();
}

public class TimeSlot
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAvailable { get; set; } = true;
    public int MaxCapacity { get; set; } = 1;
    public int CurrentBookings { get; set; } = 0;
    public decimal Price { get; set; }
}