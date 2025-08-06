using Microsoft.JSInterop;
using System.Text.Json;
using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class UserService : IUserService
{
    private readonly IJSRuntime _jsRuntime;
    private const string UsersKey = "petapp_users";

    public UserService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<User?> GetUserAsync(string userId)
    {
        var users = await GetAllUsersAsync();
        return users.FirstOrDefault(u => u.Id == userId);
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            var users = await GetAllUsersAsync();
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            
            if (existingUser == null)
                return false;

            // Update user properties
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Bio = user.Bio;
            existingUser.ProfileImagePath = user.ProfileImagePath;
            existingUser.IsProfilePublic = user.IsProfilePublic;
            existingUser.ShowEmail = user.ShowEmail;
            existingUser.ShowPets = user.ShowPets;

            await SaveUsersAsync(users);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        try
        {
            var users = await GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Id == userId);
            
            if (user == null)
                return false;

            users.Remove(user);
            await SaveUsersAsync(users);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var users = await GetAllUsersAsync();
        return users.Where(u => u.IsProfilePublic).ToList();
    }

    private async Task<List<User>> GetAllUsersAsync()
    {
        try
        {
            var usersJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UsersKey);
            return string.IsNullOrEmpty(usersJson) 
                ? new List<User>() 
                : JsonSerializer.Deserialize<List<User>>(usersJson) ?? new List<User>();
        }
        catch
        {
            return new List<User>();
        }
    }

    private async Task SaveUsersAsync(List<User> users)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UsersKey, JsonSerializer.Serialize(users));
    }
}