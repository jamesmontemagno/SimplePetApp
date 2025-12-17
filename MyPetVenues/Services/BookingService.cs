using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IBookingService
{
    Task<List<Booking>> GetUserBookingsAsync(int userId);
    Task<Booking?> GetBookingByIdAsync(int id);
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<bool> CancelBookingAsync(int bookingId);
}

public class MockBookingService : IBookingService
{
    private readonly List<Booking> _bookings;
    private int _nextId = 4;

    public MockBookingService()
    {
        _bookings = GenerateMockBookings();
    }

    public Task<List<Booking>> GetUserBookingsAsync(int userId) =>
        Task.FromResult(_bookings.Where(b => b.UserId == userId).OrderByDescending(b => b.BookingDate).ToList());

    public Task<Booking?> GetBookingByIdAsync(int id) =>
        Task.FromResult(_bookings.FirstOrDefault(b => b.Id == id));

    public Task<Booking> CreateBookingAsync(Booking booking)
    {
        booking.Id = _nextId++;
        booking.CreatedAt = DateTime.Now;
        booking.Status = BookingStatus.Confirmed;
        _bookings.Add(booking);
        return Task.FromResult(booking);
    }

    public Task<bool> CancelBookingAsync(int bookingId)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking != null)
        {
            booking.Status = BookingStatus.Cancelled;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    private static List<Booking> GenerateMockBookings() => new()
    {
        new Booking
        {
            Id = 1,
            UserId = 1,
            VenueId = 3,
            VenueName = "Paws & Relax Hotel",
            VenueImage = "images/venues/hotel1.jpg",
            BookingDate = DateTime.Now.AddDays(7),
            StartTime = new TimeSpan(14, 0, 0),
            EndTime = new TimeSpan(12, 0, 0),
            NumberOfPets = 2,
            PetNames = new List<string> { "Max", "Whiskers" },
            SpecialRequests = "Please provide extra blankets for Whiskers",
            Status = BookingStatus.Confirmed,
            TotalPrice = 450.00m,
            CreatedAt = DateTime.Now.AddDays(-3)
        },
        new Booking
        {
            Id = 2,
            UserId = 1,
            VenueId = 6,
            VenueName = "Sunny Paws Day Care",
            VenueImage = "images/venues/home1.jpg",
            BookingDate = DateTime.Now.AddDays(2),
            StartTime = new TimeSpan(8, 0, 0),
            EndTime = new TimeSpan(17, 0, 0),
            NumberOfPets = 1,
            PetNames = new List<string> { "Max" },
            SpecialRequests = "",
            Status = BookingStatus.Confirmed,
            TotalPrice = 35.00m,
            CreatedAt = DateTime.Now.AddDays(-1)
        },
        new Booking
        {
            Id = 3,
            UserId = 1,
            VenueId = 3,
            VenueName = "Paws & Relax Hotel",
            VenueImage = "images/venues/hotel1.jpg",
            BookingDate = DateTime.Now.AddDays(-14),
            StartTime = new TimeSpan(14, 0, 0),
            EndTime = new TimeSpan(12, 0, 0),
            NumberOfPets = 1,
            PetNames = new List<string> { "Max" },
            SpecialRequests = "",
            Status = BookingStatus.Completed,
            TotalPrice = 300.00m,
            CreatedAt = DateTime.Now.AddDays(-21)
        }
    };
}
