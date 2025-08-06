using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
    Task<User?> GetCurrentUserAsync();
    Task<bool> IsAuthenticatedAsync();
}