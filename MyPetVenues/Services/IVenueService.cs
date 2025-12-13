using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<IReadOnlyList<Venue>> GetVenuesAsync(CancellationToken cancellationToken = default);
    Task<Venue?> GetVenueAsync(int id, CancellationToken cancellationToken = default);
}
