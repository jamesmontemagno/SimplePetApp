using Microsoft.JSInterop;
using System.Text.Json;
using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class AuthService : IAuthService
{
    private readonly IJSRuntime _jsRuntime;
    private User? _currentUser;
    private const string StorageKey = "petapp_auth";
    private const string UsersKey = "petapp_users";

    public AuthService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            // Get users from localStorage
            var usersJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UsersKey);
            var users = string.IsNullOrEmpty(usersJson) 
                ? new List<User>() 
                : JsonSerializer.Deserialize<List<User>>(usersJson) ?? new List<User>();

            // Find user by username
            var user = users.FirstOrDefault(u => u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase));
            
            if (user == null)
            {
                return new AuthResponse { IsSuccess = false, Message = "Invalid username or password" };
            }

            // For demo purposes, accept any password
            _currentUser = user;
            var token = Guid.NewGuid().ToString();
            
            // Store auth info
            var authData = new { UserId = user.Id, Token = token, User = user };
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, JsonSerializer.Serialize(authData));

            return new AuthResponse 
            { 
                IsSuccess = true, 
                Message = "Login successful", 
                User = user, 
                Token = token 
            };
        }
        catch (Exception ex)
        {
            return new AuthResponse { IsSuccess = false, Message = $"Login failed: {ex.Message}" };
        }
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        try
        {
            if (request.Password != request.ConfirmPassword)
            {
                return new AuthResponse { IsSuccess = false, Message = "Passwords do not match" };
            }

            // Get existing users
            var usersJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UsersKey);
            var users = string.IsNullOrEmpty(usersJson) 
                ? new List<User>() 
                : JsonSerializer.Deserialize<List<User>>(usersJson) ?? new List<User>();

            // Check if user already exists
            if (users.Any(u => u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase)))
            {
                return new AuthResponse { IsSuccess = false, Message = "Username already exists" };
            }

            if (users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return new AuthResponse { IsSuccess = false, Message = "Email already exists" };
            }

            // Create new user
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            users.Add(user);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UsersKey, JsonSerializer.Serialize(users));

            _currentUser = user;
            var token = Guid.NewGuid().ToString();
            
            // Store auth info
            var authData = new { UserId = user.Id, Token = token, User = user };
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, JsonSerializer.Serialize(authData));

            return new AuthResponse 
            { 
                IsSuccess = true, 
                Message = "Registration successful", 
                User = user, 
                Token = token 
            };
        }
        catch (Exception ex)
        {
            return new AuthResponse { IsSuccess = false, Message = $"Registration failed: {ex.Message}" };
        }
    }

    public async Task LogoutAsync()
    {
        _currentUser = null;
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", StorageKey);
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        if (_currentUser != null)
            return _currentUser;

        try
        {
            var authDataJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            if (string.IsNullOrEmpty(authDataJson))
                return null;

            var authData = JsonSerializer.Deserialize<JsonElement>(authDataJson);
            if (authData.TryGetProperty("User", out var userElement))
            {
                _currentUser = JsonSerializer.Deserialize<User>(userElement.GetRawText());
            }

            return _currentUser;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        return await GetCurrentUserAsync() != null;
    }
}