using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<IEnumerable<Venue>> GetAllAsync();
    Task<Venue?> GetByIdAsync(Guid id);
    Task<IEnumerable<Venue>> SearchAsync(string? text, VenueCategory? category, string? petType);
}