namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public PetType PetType { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public List<string> Photos { get; set; } = new();
    public int HelpfulCount { get; set; }
}
