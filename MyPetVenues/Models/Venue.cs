namespace MyPetVenues.Models;

public enum VenueCategory
{
    Cafe,
    Park,
    Hotel,
    Store,
    Coworking,
    Other
}

public class Venue
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public VenueCategory Category { get; set; }
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> PetTypesAllowed { get; set; } = new();
    public List<string> Amenities { get; set; } = new();
    public string Image { get; set; } = string.Empty;
    public double? Rating { get; set; }
    public int ReviewsCount { get; set; }
    public List<string> Tags { get; set; } = new();
    public bool IsVerified { get; set; }
    public DateTime LastUpdated { get; set; }
}