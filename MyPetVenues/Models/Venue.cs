namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public VenueCategory Category { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<PetType> PetTypesAllowed { get; set; } = new();
    public List<Amenity> Amenities { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public DateTime CreatedDate { get; set; }
    public double AverageRating => Reviews.Count > 0 ? Reviews.Average(r => r.Rating) : 0;
}
