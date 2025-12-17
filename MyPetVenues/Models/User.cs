namespace MyPetVenues.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime JoinedDate { get; set; }
    public List<Pet> Pets { get; set; } = [];
    public List<int> FavoriteVenueIds { get; set; } = [];
    public List<Booking> Bookings { get; set; } = [];
    public int ReviewCount { get; set; }
    public int VenuesAdded { get; set; }
}

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
