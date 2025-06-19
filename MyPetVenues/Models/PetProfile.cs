using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class PetProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "Pet name is required")]
    [StringLength(100, ErrorMessage = "Pet name cannot exceed 100 characters")]
    public string Name { get; set; } = default!;
    
    [StringLength(100, ErrorMessage = "Breed cannot exceed 100 characters")]
    public string? Breed { get; set; }
    
    [Display(Name = "Birth Date")]
    public DateTime? BirthDate { get; set; }
    
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }
    
    [Display(Name = "Photo URL")]
    [Url(ErrorMessage = "Please enter a valid URL")]
    public string? PhotoUrl { get; set; }
}