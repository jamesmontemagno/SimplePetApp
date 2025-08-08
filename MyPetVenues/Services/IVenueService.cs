using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<IEnumerable<Venue>> GetAllAsync();
    Task<IEnumerable<Venue>> SearchAsync(string? term = null, string? category = null, string? petType = null);
    Task<IEnumerable<Venue>> GetFeaturedAsync(int count = 3);
}