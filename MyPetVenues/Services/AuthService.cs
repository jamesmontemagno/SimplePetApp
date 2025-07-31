using MyPetVenues.Models;
using System.Security.Cryptography;
using System.Text;

namespace MyPetVenues.Services;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest request);
    Task<AuthResult> LoginAsync(LoginRequest request);
    Task LogoutAsync();
    Task<User?> GetCurrentUserAsync();
    bool IsLoggedIn { get; }
    event Action? OnAuthStateChanged;
}

public class AuthService : IAuthService
{
    private readonly List<User> _users = new();
    private User? _currentUser;
    private int _nextUserId = 1;

    public bool IsLoggedIn => _currentUser != null;
    public event Action? OnAuthStateChanged;

    public Task<User?> GetCurrentUserAsync() => Task.FromResult(_currentUser);

    public Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(request.Name) || 
            string.IsNullOrWhiteSpace(request.Email) || 
            string.IsNullOrWhiteSpace(request.Password))
        {
            return Task.FromResult(new AuthResult 
            { 
                Success = false, 
                Message = "All fields are required." 
            });
        }

        if (request.Password != request.ConfirmPassword)
        {
            return Task.FromResult(new AuthResult 
            { 
                Success = false, 
                Message = "Passwords do not match." 
            });
        }

        if (_users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.FromResult(new AuthResult 
            { 
                Success = false, 
                Message = "Email already exists." 
            });
        }

        // Create new user
        var user = new User
        {
            Id = _nextUserId++,
            Name = request.Name,
            Email = request.Email,
            PasswordHash = HashPassword(request.Password)
        };

        _users.Add(user);
        _currentUser = user;

        OnAuthStateChanged?.Invoke();

        return Task.FromResult(new AuthResult 
        { 
            Success = true, 
            Message = "Registration successful!", 
            User = user 
        });
    }

    public Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u => 
            u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));

        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
        {
            return Task.FromResult(new AuthResult 
            { 
                Success = false, 
                Message = "Invalid email or password." 
            });
        }

        _currentUser = user;
        OnAuthStateChanged?.Invoke();

        return Task.FromResult(new AuthResult 
        { 
            Success = true, 
            Message = "Login successful!", 
            User = user 
        });
    }

    public Task LogoutAsync()
    {
        _currentUser = null;
        OnAuthStateChanged?.Invoke();
        return Task.CompletedTask;
    }

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private static bool VerifyPassword(string password, string hash)
    {
        var hashToCheck = HashPassword(password);
        return hash == hashToCheck;
    }
}