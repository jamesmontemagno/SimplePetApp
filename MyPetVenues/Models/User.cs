namespace MyPetVenues.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime JoinedDate { get; set; }
    public List<Pet> Pets { get; set; } = new();
    public List<int> FavoriteVenueIds { get; set; } = new();
    public UserPreferences Preferences { get; set; } = new();
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

public class UserPreferences
{
    public bool EmailNotifications { get; set; } = true;
    public bool PushNotifications { get; set; } = true;
    public int SearchRadius { get; set; } = 25;
    public List<PetType> PreferredPetTypes { get; set; } = new();
    public List<VenueType> PreferredVenueTypes { get; set; } = new();
}
