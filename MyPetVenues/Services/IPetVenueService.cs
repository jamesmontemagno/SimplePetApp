using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IPetVenueService
{
    Task<IReadOnlyList<PetVenue>> GetFeaturedAsync();
    Task<IReadOnlyList<PetVenue>> GetAllAsync();
    Task<PetVenue?> GetByIdAsync(int id);
    Task<IReadOnlyList<PetVenue>> SearchAsync(string? term, string? petType, IEnumerable<string>? amenities);
}
