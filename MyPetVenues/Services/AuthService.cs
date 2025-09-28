using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class AuthService
{
    private User? _currentUser;
    private readonly List<User> _users = new();
    
    public event Action? OnAuthStateChanged;

    public AuthService()
    {
        // Add mock users for demo
        _users.Add(new User
        {
            Id = 1,
            Email = "demo@pawspots.com",
            FirstName = "Demo",
            LastName = "User",
            PasswordHash = HashPassword("demo123"),
            FavoriteVenueIds = new List<int> { 1, 3, 5 }
        });
    }

    public User? CurrentUser => _currentUser;
    public bool IsAuthenticated => _currentUser != null;

    public async Task<(bool Success, string Message)> LoginAsync(LoginRequest request)
    {
        await Task.Delay(500); // Simulate API call

        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return (false, "Email and password are required");
        }

        var user = _users.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
        
        if (user == null || user.PasswordHash != HashPassword(request.Password))
        {
            return (false, "Invalid email or password");
        }

        _currentUser = user;
        OnAuthStateChanged?.Invoke();
        
        return (true, "Login successful!");
    }

    public async Task<(bool Success, string Message)> RegisterAsync(RegisterRequest request)
    {
        await Task.Delay(500); // Simulate API call

        // Validation
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return (false, "Email is required");
        }

        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            return (false, "First name is required");
        }

        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            return (false, "Last name is required");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return (false, "Password is required");
        }

        if (request.Password.Length < 6)
        {
            return (false, "Password must be at least 6 characters");
        }

        if (request.Password != request.ConfirmPassword)
        {
            return (false, "Passwords do not match");
        }

        if (_users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
        {
            return (false, "Email already registered");
        }

        var newUser = new User
        {
            Id = _users.Count + 1,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = HashPassword(request.Password),
            CreatedAt = DateTime.Now
        };

        _users.Add(newUser);
        _currentUser = newUser;
        OnAuthStateChanged?.Invoke();

        return (true, "Registration successful!");
    }

    public void Logout()
    {
        _currentUser = null;
        OnAuthStateChanged?.Invoke();
    }

    private string HashPassword(string password)
    {
        // In a real app, use proper password hashing (BCrypt, Argon2, etc.)
        // This is just for demo purposes
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password + "_salt"));
    }
}
