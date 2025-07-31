using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IPetService
{
    Task<IEnumerable<Pet>> GetUserPetsAsync(int userId);
    Task<Pet?> GetPetAsync(int petId);
    Task<Pet> AddPetAsync(Pet pet);
    Task<Pet?> UpdatePetAsync(Pet pet);
    Task<bool> DeletePetAsync(int petId);
    Task<IEnumerable<Pet>> GetPublicPetsAsync();
}

public class PetService : IPetService
{
    private readonly List<Pet> _pets = new();
    private int _nextPetId = 1;

    public PetService()
    {
        // Add some sample data
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        var samplePets = new List<Pet>
        {
            new Pet
            {
                Id = _nextPetId++,
                Name = "Buddy",
                Species = "Dog",
                Breed = "Golden Retriever",
                Age = 3,
                Description = "Friendly and energetic dog who loves playing fetch!",
                PhotoPath = "dog1.png",
                IsPublic = true,
                UserId = 999, // Sample user
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            },
            new Pet
            {
                Id = _nextPetId++,
                Name = "Whiskers",
                Species = "Cat",
                Breed = "Persian",
                Age = 2,
                Description = "Calm and affectionate cat who enjoys sunbathing.",
                PhotoPath = "cat1.jpg",
                IsPublic = true,
                UserId = 998, // Sample user
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Pet
            {
                Id = _nextPetId++,
                Name = "Spike",
                Species = "Other",
                Breed = "Hedgehog",
                Age = 1,
                Description = "Adorable little hedgehog with a big personality!",
                PhotoPath = "hedgehog.jpg",
                IsPublic = true,
                UserId = 997, // Sample user
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            }
        };

        _pets.AddRange(samplePets);
    }

    public Task<IEnumerable<Pet>> GetUserPetsAsync(int userId)
    {
        var pets = _pets.Where(p => p.UserId == userId).ToList();
        return Task.FromResult<IEnumerable<Pet>>(pets);
    }

    public Task<Pet?> GetPetAsync(int petId)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == petId);
        return Task.FromResult(pet);
    }

    public Task<Pet> AddPetAsync(Pet pet)
    {
        pet.Id = _nextPetId++;
        pet.CreatedAt = DateTime.UtcNow;
        _pets.Add(pet);
        return Task.FromResult(pet);
    }

    public Task<Pet?> UpdatePetAsync(Pet pet)
    {
        var existingPet = _pets.FirstOrDefault(p => p.Id == pet.Id);
        if (existingPet == null)
            return Task.FromResult<Pet?>(null);

        existingPet.Name = pet.Name;
        existingPet.Species = pet.Species;
        existingPet.Breed = pet.Breed;
        existingPet.Age = pet.Age;
        existingPet.Description = pet.Description;
        existingPet.PhotoPath = pet.PhotoPath;
        existingPet.IsPublic = pet.IsPublic;

        return Task.FromResult<Pet?>(existingPet);
    }

    public Task<bool> DeletePetAsync(int petId)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == petId);
        if (pet == null)
            return Task.FromResult(false);

        _pets.Remove(pet);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<Pet>> GetPublicPetsAsync()
    {
        var publicPets = _pets.Where(p => p.IsPublic).ToList();
        return Task.FromResult<IEnumerable<Pet>>(publicPets);
    }
}