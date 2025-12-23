namespace MyPetVenues.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public string Bio { get; set; } = string.Empty;
    public List<string> FavoriteActivities { get; set; } = [];
    public List<int> VisitedVenueIds { get; set; } = [];
    public DateTime DateAdded { get; set; }

    public string AgeDisplay => Age == 1 ? "1 year old" : $"{Age} years old";
}
