namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public VenueCategory Category { get; set; }
    public List<Amenity> Amenities { get; set; } = [];
    public List<PetType> AllowedPets { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string Hours { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsFeatured { get; set; }
    
    public double AverageRating => Reviews.Count > 0 ? Reviews.Average(r => r.Rating) : 0;
    public int ReviewCount => Reviews.Count;
}

public enum VenueCategory
{
    Park,
    Restaurant,
    Cafe,
    Hotel,
    Beach,
    Store,
    Grooming,
    Veterinary,
    DayCare,
    Other
}

public enum Amenity
{
    WaterBowls,
    PetMenu,
    OffLeashArea,
    FencedArea,
    WasteBags,
    PetTreats,
    OutdoorSeating,
    IndoorPetFriendly,
    PetWashStation,
    DogPark,
    AgilityEquipment,
    ShadedAreas,
    ParkingAvailable,
    WheelchairAccessible
}

public enum PetType
{
    Dogs,
    Cats,
    SmallAnimals,
    Birds,
    Reptiles,
    All
}
