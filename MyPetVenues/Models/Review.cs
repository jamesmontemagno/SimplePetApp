namespace MyPetVenues.Models;

public class Review
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public Guid UserId { get; set; }
    public int Rating { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public PetType PetType { get; set; }
    public List<string> Photos { get; set; } = new();
    public int HelpfulCount { get; set; }
    public DateTime DateCreated { get; set; }
    
    // Navigation properties
    public User? User { get; set; }
    public string UserName => User?.Name ?? "Anonymous";
}
