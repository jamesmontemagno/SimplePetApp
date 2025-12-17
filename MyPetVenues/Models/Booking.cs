namespace MyPetVenues.Models;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int VenueId { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string VenueImage { get; set; } = string.Empty;
    public DateTime BookingDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int NumberOfPets { get; set; }
    public List<string> PetNames { get; set; } = new();
    public string SpecialRequests { get; set; } = string.Empty;
    public BookingStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
