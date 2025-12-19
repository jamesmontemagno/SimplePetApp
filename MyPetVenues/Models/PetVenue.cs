namespace MyPetVenues.Models;

public record class PetVenue
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string City { get; set; }
    public string Neighborhood { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public required string Description { get; set; }
    public List<string> PetTypes { get; set; } = [];
    public List<string> Amenities { get; set; } = [];
    public string ImageUrl { get; set; } = "images/venues/park1.jpg";
    public string Website { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string? Hours { get; set; }
    public bool ReservationsRequired { get; set; }
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
}
