using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string ReviewerName { get; set; } = string.Empty;
    
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }
    
    [Required(ErrorMessage = "Review comment is required")]
    public string Comment { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public PetType PetType { get; set; }
    public string PetName { get; set; } = string.Empty;
    public string PetImageUrl { get; set; } = string.Empty;
}
