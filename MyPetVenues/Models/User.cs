using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;
    
    public string Bio { get; set; } = string.Empty;
    public string ProfileImagePath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Privacy Settings
    public bool IsProfilePublic { get; set; } = true;
    public bool ShowEmail { get; set; } = false;
    public bool ShowPets { get; set; } = true;
}