using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class Pet
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Pet name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Pet type is required")]
    public string Type { get; set; } = string.Empty; // Dog, Cat, Bird, etc.
    
    public string Breed { get; set; } = string.Empty;
    public int? Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Privacy Settings
    public bool IsPublic { get; set; } = true;
    public bool ShowInSearchResults { get; set; } = true;
}