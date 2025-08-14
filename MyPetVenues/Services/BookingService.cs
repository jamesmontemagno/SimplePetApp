using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IBookingService
{
    Task<List<BookingRequest>> GetBookingRequestsAsync();
    Task<BookingRequest?> GetBookingRequestByIdAsync(int id);
    Task<int> CreateBookingRequestAsync(BookingRequest request);
    Task<bool> UpdateBookingStatusAsync(int id, BookingStatus status, string? notes = null);
}

public class BookingService : IBookingService
{
    private readonly List<BookingRequest> _bookingRequests;
    private int _nextId = 1;

    public BookingService()
    {
        _bookingRequests = new List<BookingRequest>();
    }

    public Task<List<BookingRequest>> GetBookingRequestsAsync()
    {
        return Task.FromResult(_bookingRequests.ToList());
    }

    public Task<BookingRequest?> GetBookingRequestByIdAsync(int id)
    {
        var request = _bookingRequests.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(request);
    }

    public Task<int> CreateBookingRequestAsync(BookingRequest request)
    {
        request.Id = _nextId++;
        request.RequestDate = DateTime.Now;
        request.Status = BookingStatus.Pending;
        
        _bookingRequests.Add(request);
        
        return Task.FromResult(request.Id);
    }

    public Task<bool> UpdateBookingStatusAsync(int id, BookingStatus status, string? notes = null)
    {
        var request = _bookingRequests.FirstOrDefault(r => r.Id == id);
        if (request == null) return Task.FromResult(false);

        request.Status = status;
        if (notes != null)
        {
            request.Notes = notes;
        }

        return Task.FromResult(true);
    }
}