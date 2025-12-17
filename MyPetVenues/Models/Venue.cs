namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public VenueType Type { get; set; }
    public List<PetType> AcceptedPets { get; set; } = new();
    public List<string> Amenities { get; set; } = new();
    public string PetPolicy { get; set; } = string.Empty;
    public string Hours { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsFeatured { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public decimal PricePerHour { get; set; }
}

public enum VenueType
{
    Park,
    Restaurant,
    Cafe,
    Hotel,
    Store,
    Beach,
    DayCare,
    Grooming,
    VetClinic
}

public enum PetType
{
    Dog,
    Cat,
    Bird,
    Rabbit,
    SmallPet,
    All
}
