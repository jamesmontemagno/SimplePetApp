using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<List<Venue>> GetVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<List<TimeSlot>> GetAvailableTimeSlotsAsync(int venueId, DateTime date);
}

public class VenueService : IVenueService
{
    private readonly List<Venue> _venues;

    public VenueService()
    {
        _venues = GenerateMockVenues();
    }

    public Task<List<Venue>> GetVenuesAsync()
    {
        return Task.FromResult(_venues);
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(venue);
    }

    public Task<List<TimeSlot>> GetAvailableTimeSlotsAsync(int venueId, DateTime date)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue == null) return Task.FromResult(new List<TimeSlot>());

        var availableSlots = venue.AvailableSlots
            .Where(slot => slot.StartTime.Date == date.Date && slot.IsAvailable)
            .OrderBy(slot => slot.StartTime)
            .ToList();

        return Task.FromResult(availableSlots);
    }

    private List<Venue> GenerateMockVenues()
    {
        var venues = new List<Venue>
        {
            new Venue
            {
                Id = 1,
                Name = "Happy Paws Dog Park",
                Description = "A spacious dog park with separate areas for large and small dogs. Features agility equipment and water stations.",
                Address = "123 Park Avenue",
                City = "Seattle, WA",
                ImageUrl = "/images/venues/park1.jpg",
                Tags = new List<string> { "dog park", "outdoor", "exercise", "social" },
                Rating = 4.5m,
                ReviewCount = 127,
                ContactEmail = "info@happypaws.com",
                Phone = "(555) 123-4567",
                AvailableSlots = GenerateTimeSlots(1)
            },
            new Venue
            {
                Id = 2,
                Name = "Furry Friends Daycare",
                Description = "Professional pet daycare with supervised play, feeding, and rest time. Perfect for busy pet parents.",
                Address = "456 Pet Street",
                City = "Portland, OR",
                ImageUrl = "/images/venues/daycare1.jpg",
                Tags = new List<string> { "daycare", "indoor", "supervised", "feeding" },
                Rating = 4.8m,
                ReviewCount = 89,
                ContactEmail = "hello@furryfriends.com",
                Phone = "(555) 987-6543",
                AvailableSlots = GenerateTimeSlots(2)
            },
            new Venue
            {
                Id = 3,
                Name = "Paws & Claws Grooming",
                Description = "Full-service pet grooming with experienced groomers. Nail trimming, bathing, and styling available.",
                Address = "789 Grooming Lane",
                City = "San Francisco, CA",
                ImageUrl = "/images/venues/grooming1.jpg",
                Tags = new List<string> { "grooming", "professional", "bathing", "styling" },
                Rating = 4.7m,
                ReviewCount = 203,
                ContactEmail = "book@pawsandclaws.com",
                Phone = "(555) 456-7890",
                AvailableSlots = GenerateTimeSlots(3)
            }
        };

        return venues;
    }

    private List<TimeSlot> GenerateTimeSlots(int venueId)
    {
        var slots = new List<TimeSlot>();
        var baseDate = DateTime.Today;

        for (int day = 0; day < 7; day++)
        {
            var currentDate = baseDate.AddDays(day);
            
            // Generate slots for 9 AM to 5 PM
            for (int hour = 9; hour < 17; hour++)
            {
                var startTime = currentDate.AddHours(hour);
                var endTime = startTime.AddHours(1);
                
                slots.Add(new TimeSlot
                {
                    Id = slots.Count + 1,
                    StartTime = startTime,
                    EndTime = endTime,
                    IsAvailable = Random.Shared.NextDouble() > 0.3, // 70% availability
                    MaxCapacity = venueId == 2 ? 10 : 1, // Daycare has higher capacity
                    CurrentBookings = 0,
                    Price = venueId switch
                    {
                        1 => 0, // Dog park is free
                        2 => 45m, // Daycare per hour
                        3 => 75m, // Grooming per session
                        _ => 25m
                    }
                });
            }
        }

        return slots;
    }
}