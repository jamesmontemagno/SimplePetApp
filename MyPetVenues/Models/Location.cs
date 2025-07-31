namespace MyPetVenues.Models;

public class Location
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public string? Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Category { get; set; } // Park, Cafe, Hotel, etc.
    public List<string> Amenities { get; set; } = new();
    public bool IsPetFriendly { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}