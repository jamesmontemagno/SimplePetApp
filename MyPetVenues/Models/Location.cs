namespace MyPetVenues.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public LocationType Type { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<Amenity> Amenities { get; set; } = new();
    public string PetPolicy { get; set; } = string.Empty;
    public List<Review> Reviews { get; set; } = new();
    public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public List<string> Hours { get; set; } = new();
}

public enum LocationType
{
    Park,
    Cafe,
    Hotel,
    Store,
    Restaurant,
    Veterinary,
    Other
}

public class Amenity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class Review
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public string PetType { get; set; } = string.Empty;
}