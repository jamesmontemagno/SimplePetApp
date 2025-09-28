namespace MyPetVenues.Models;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public VenueCategory Category { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> GalleryImages { get; set; } = new();
    public string PetPolicy { get; set; } = string.Empty;
    public List<Amenity> Amenities { get; set; } = new();
    public List<PetSize> AcceptedSizes { get; set; } = new();
    public List<PetType> AcceptedPets { get; set; } = new();
    public Dictionary<string, string> Hours { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public Dictionary<int, int> UserRatings { get; set; } = new(); // UserId -> Rating
    public bool IsFeatured { get; set; } = false;
}

public enum VenueCategory
{
    Parks,
    Restaurants,
    Cafes,
    Hotels,
    PetStores,
    Grooming,
    Veterinary,
    Beaches,
    Trails,
    Other
}

public enum Amenity
{
    WaterBowls,
    PetMenu,
    OffLeashArea,
    IndoorSeating,
    OutdoorSeating,
    WasteStations,
    PetTreats,
    ShadeAreas,
    Parking,
    DogRuns,
    AgilityCourse
}

public enum PetSize
{
    Small,
    Medium,
    Large,
    AllSizes
}

public enum PetType
{
    Dogs,
    Cats,
    Birds,
    SmallAnimals,
    Other
}
