namespace MyPetVenues.Models;

public class Booking
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string VenueImageUrl { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int NumberOfPets { get; set; }
    public List<string> PetNames { get; set; } = [];
    public string SpecialRequests { get; set; } = string.Empty;
    public BookingStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
