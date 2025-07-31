using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class Pet
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Pet name is required")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Pet name must be between 1 and 50 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Species is required")]
    public string Species { get; set; } = string.Empty;
    
    [StringLength(50, ErrorMessage = "Breed must be less than 50 characters")]
    public string Breed { get; set; } = string.Empty;
    
    [Range(0, 30, ErrorMessage = "Age must be between 0 and 30 years")]
    public int Age { get; set; }
    
    [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
    public string Description { get; set; } = string.Empty;
    
    public string PhotoPath { get; set; } = string.Empty;
    public bool IsPublic { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public User? User { get; set; }
}