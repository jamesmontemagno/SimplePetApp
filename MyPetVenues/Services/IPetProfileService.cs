using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IPetProfileService
{
    Task<List<PetProfile>> GetProfilesAsync(CancellationToken cancellationToken = default);
    Task<PetProfile?> GetProfileAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddProfileAsync(PetProfile profile, CancellationToken cancellationToken = default);
    Task UpdateProfileAsync(PetProfile profile, CancellationToken cancellationToken = default);
    Task DeleteProfileAsync(Guid id, CancellationToken cancellationToken = default);
}