namespace MyPetVenues.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public List<int> PetIds { get; set; } = [];
    public List<int> FavoriteVenueIds { get; set; } = [];
    public DateTime JoinDate { get; set; }
    public int ReviewCount { get; set; }
    public int VenuesAdded { get; set; }
}
