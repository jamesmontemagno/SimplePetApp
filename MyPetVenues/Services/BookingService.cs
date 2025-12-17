using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
    Task<Booking?> GetBookingByIdAsync(int id);
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<bool> CancelBookingAsync(int bookingId);
    Task<IEnumerable<TimeSpan>> GetAvailableTimeSlotsAsync(int venueId, DateTime date);
}

public class BookingService : IBookingService
{
    private readonly List<Booking> _bookings = [];
    private int _nextId = 100;

    public Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
    {
        return Task.FromResult<IEnumerable<Booking>>(_bookings.Where(b => b.UserId == userId));
    }

    public Task<Booking?> GetBookingByIdAsync(int id)
    {
        return Task.FromResult(_bookings.FirstOrDefault(b => b.Id == id));
    }

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
        if (booking == null) return Task.FromResult(false);
        
        booking.Status = BookingStatus.Cancelled;
        return Task.FromResult(true);
    }

    public Task<IEnumerable<TimeSpan>> GetAvailableTimeSlotsAsync(int venueId, DateTime date)
    {
        // Generate mock available time slots
        var slots = new List<TimeSpan>();
        for (int hour = 8; hour < 20; hour++)
        {
            slots.Add(new TimeSpan(hour, 0, 0));
            slots.Add(new TimeSpan(hour, 30, 0));
        }
        
        // Remove some random slots to simulate bookings
        var random = new Random(date.DayOfYear + venueId);
        var slotsToRemove = random.Next(3, 8);
        for (int i = 0; i < slotsToRemove && slots.Count > 5; i++)
        {
            slots.RemoveAt(random.Next(slots.Count));
        }
        
        return Task.FromResult<IEnumerable<TimeSpan>>(slots);
    }
}
