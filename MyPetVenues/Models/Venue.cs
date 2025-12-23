namespace MyPetVenues.Models;

public class Venue
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public VenueType Type { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<Amenity> Amenities { get; set; } = new();
    public List<PetType> AllowedPets { get; set; } = new();
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public DateTime DateAdded { get; set; }
}
