namespace MyPetVenues.Models;

public class BookingRequest
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public int TimeSlotId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public string PetType { get; set; } = string.Empty;
    public string SpecialRequests { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public string? Notes { get; set; }
}

public enum BookingStatus
{
    Pending,
    Approved,
    Rejected,
    Cancelled
}