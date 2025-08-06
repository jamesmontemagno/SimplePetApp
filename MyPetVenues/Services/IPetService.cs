using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IPetService
{
    Task<List<Pet>> GetPetsByUserIdAsync(string userId);
    Task<Pet?> GetPetAsync(string petId);
    Task<bool> AddPetAsync(Pet pet);
    Task<bool> UpdatePetAsync(Pet pet);
    Task<bool> DeletePetAsync(string petId);
    Task<List<Pet>> GetPublicPetsAsync();
}