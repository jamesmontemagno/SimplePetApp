using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IUserService
{
    Task<User?> GetUserAsync(string userId);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(string userId);
    Task<List<User>> GetUsersAsync();
}