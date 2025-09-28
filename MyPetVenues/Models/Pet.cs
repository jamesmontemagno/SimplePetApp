namespace MyPetVenues.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public PetSize Size { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public List<string> Personality { get; set; } = new();
    public string OwnerName { get; set; } = string.Empty;
    public List<string> FavoriteVenues { get; set; } = new();
    public bool IsFeatured { get; set; } = false;
}
