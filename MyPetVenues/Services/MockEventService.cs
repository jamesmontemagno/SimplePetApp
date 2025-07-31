using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockEventService : IEventService
{
    private static List<Event> _events = new();
    private static List<EventRsvp> _rsvps = new();
    private static int _nextEventId = 1;
    private static int _nextRsvpId = 1;

    public Task<List<Event>> GetEventsAsync()
    {
        return Task.FromResult(_events.Where(e => e.Status == EventStatus.Upcoming).ToList());
    }

    public Task<List<Event>> GetEventsByLocationAsync(int locationId)
    {
        var events = _events.Where(e => e.LocationId == locationId).ToList();
        return Task.FromResult(events);
    }

    public Task<List<Event>> GetEventsByUserAsync(int userId)
    {
        var events = _events.Where(e => e.OrganizerId == userId).ToList();
        return Task.FromResult(events);
    }

    public Task<Event?> GetEventAsync(int id)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(eventItem);
    }

    public Task<Event> CreateEventAsync(Event eventItem)
    {
        eventItem.Id = _nextEventId++;
        eventItem.CreatedDate = DateTime.UtcNow;
        _events.Add(eventItem);
        return Task.FromResult(eventItem);
    }

    public Task<Event> UpdateEventAsync(Event eventItem)
    {
        var existing = _events.FirstOrDefault(e => e.Id == eventItem.Id);
        if (existing != null)
        {
            existing.Title = eventItem.Title;
            existing.Description = eventItem.Description;
            existing.StartDate = eventItem.StartDate;
            existing.EndDate = eventItem.EndDate;
            existing.MaxAttendees = eventItem.MaxAttendees;
            existing.Type = eventItem.Type;
            existing.UpdatedDate = DateTime.UtcNow;
            return Task.FromResult(existing);
        }
        return Task.FromResult(eventItem);
    }

    public Task<bool> DeleteEventAsync(int id)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == id);
        if (eventItem != null)
        {
            _events.Remove(eventItem);
            _rsvps.RemoveAll(r => r.EventId == id);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<EventRsvp> RsvpToEventAsync(int eventId, int userId, RsvpStatus status)
    {
        var existing = _rsvps.FirstOrDefault(r => r.EventId == eventId && r.UserId == userId);
        if (existing != null)
        {
            existing.Status = status;
            return Task.FromResult(existing);
        }

        var rsvp = new EventRsvp
        {
            Id = _nextRsvpId++,
            EventId = eventId,
            UserId = userId,
            Status = status,
            CreatedDate = DateTime.UtcNow
        };
        _rsvps.Add(rsvp);
        return Task.FromResult(rsvp);
    }

    public Task<List<EventRsvp>> GetEventAttendeesAsync(int eventId)
    {
        var attendees = _rsvps.Where(r => r.EventId == eventId).ToList();
        return Task.FromResult(attendees);
    }
}