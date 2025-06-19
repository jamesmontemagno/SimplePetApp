using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class PetProfileService : IPetProfileService
{
    private readonly List<PetProfile> _profiles = [];

    public PetProfileService()
    {
        // Add some sample data for demonstration
        _profiles.AddRange([
            new PetProfile
            {
                Id = Guid.NewGuid(),
                Name = "Buddy",
                Breed = "Golden Retriever",
                BirthDate = new DateTime(2020, 3, 15),
                Description = "Buddy is a friendly and energetic Golden Retriever who loves playing fetch and swimming. He's great with kids and other dogs.",
                PhotoUrl = "https://images.unsplash.com/photo-1552053831-71594a27632d?w=400"
            },
            new PetProfile
            {
                Id = Guid.NewGuid(),
                Name = "Whiskers",
                Breed = "Maine Coon",
                BirthDate = new DateTime(2019, 7, 8),
                Description = "Whiskers is a majestic Maine Coon cat with a calm and gentle personality. She loves napping in sunny spots and watching birds.",
                PhotoUrl = "https://images.unsplash.com/photo-1514888286974-6c03e2ca1dba?w=400"
            },
            new PetProfile
            {
                Id = Guid.NewGuid(),
                Name = "Luna",
                Breed = "Border Collie",
                BirthDate = new DateTime(2021, 11, 22),
                Description = "Luna is an intelligent and active Border Collie who excels at agility training. She's always ready for an adventure!",
                PhotoUrl = "https://images.unsplash.com/photo-1551717743-49959800b1f6?w=400"
            }
        ]);
    }

    public Task<List<PetProfile>> GetProfilesAsync(CancellationToken cancellationToken = default)
    {
        // Return a copy to prevent external modifications
        return Task.FromResult(_profiles.ToList());
    }

    public Task<PetProfile?> GetProfileAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var profile = _profiles.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(profile);
    }

    public Task AddProfileAsync(PetProfile profile, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(profile);
        
        // Ensure the profile has a unique ID
        if (profile.Id == Guid.Empty)
            profile.Id = Guid.NewGuid();
            
        _profiles.Add(profile);
        return Task.CompletedTask;
    }

    public Task UpdateProfileAsync(PetProfile profile, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(profile);
        
        var existingProfile = _profiles.FirstOrDefault(p => p.Id == profile.Id);
        if (existingProfile is not null)
        {
            var index = _profiles.IndexOf(existingProfile);
            _profiles[index] = profile;
        }
        
        return Task.CompletedTask;
    }

    public Task DeleteProfileAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var profile = _profiles.FirstOrDefault(p => p.Id == id);
        if (profile is not null)
        {
            _profiles.Remove(profile);
        }
        
        return Task.CompletedTask;
    }
}