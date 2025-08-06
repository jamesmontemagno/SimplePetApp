using Microsoft.JSInterop;
using System.Text.Json;
using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class PetService : IPetService
{
    private readonly IJSRuntime _jsRuntime;
    private const string PetsKey = "petapp_pets";

    public PetService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<Pet>> GetPetsByUserIdAsync(string userId)
    {
        var pets = await GetAllPetsAsync();
        return pets.Where(p => p.UserId == userId).ToList();
    }

    public async Task<Pet?> GetPetAsync(string petId)
    {
        var pets = await GetAllPetsAsync();
        return pets.FirstOrDefault(p => p.Id == petId);
    }

    public async Task<bool> AddPetAsync(Pet pet)
    {
        try
        {
            var pets = await GetAllPetsAsync();
            pets.Add(pet);
            await SavePetsAsync(pets);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdatePetAsync(Pet pet)
    {
        try
        {
            var pets = await GetAllPetsAsync();
            var existingPet = pets.FirstOrDefault(p => p.Id == pet.Id);
            
            if (existingPet == null)
                return false;

            // Update pet properties
            existingPet.Name = pet.Name;
            existingPet.Type = pet.Type;
            existingPet.Breed = pet.Breed;
            existingPet.Age = pet.Age;
            existingPet.Gender = pet.Gender;
            existingPet.Description = pet.Description;
            existingPet.PhotoPath = pet.PhotoPath;
            existingPet.IsPublic = pet.IsPublic;
            existingPet.ShowInSearchResults = pet.ShowInSearchResults;

            await SavePetsAsync(pets);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeletePetAsync(string petId)
    {
        try
        {
            var pets = await GetAllPetsAsync();
            var pet = pets.FirstOrDefault(p => p.Id == petId);
            
            if (pet == null)
                return false;

            pets.Remove(pet);
            await SavePetsAsync(pets);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<Pet>> GetPublicPetsAsync()
    {
        var pets = await GetAllPetsAsync();
        return pets.Where(p => p.IsPublic && p.ShowInSearchResults).ToList();
    }

    private async Task<List<Pet>> GetAllPetsAsync()
    {
        try
        {
            var petsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", PetsKey);
            return string.IsNullOrEmpty(petsJson) 
                ? new List<Pet>() 
                : JsonSerializer.Deserialize<List<Pet>>(petsJson) ?? new List<Pet>();
        }
        catch
        {
            return new List<Pet>();
        }
    }

    private async Task SavePetsAsync(List<Pet> pets)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", PetsKey, JsonSerializer.Serialize(pets));
    }
}