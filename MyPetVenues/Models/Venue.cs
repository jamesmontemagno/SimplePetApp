using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Venue name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;
    
    public VenueType Type { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "State is required")]
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<PetType> AcceptedPetTypes { get; set; } = new();
    public List<Amenity> Amenities { get; set; } = new();
    public string OperatingHours { get; set; } = string.Empty;
    public decimal AverageRating { get; set; }
    public int ReviewCount { get; set; }
    public DateTime DateAdded { get; set; }
}
