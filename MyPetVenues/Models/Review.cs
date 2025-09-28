namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public required string AuthorName { get; set; }
    public required string AuthorPetName { get; set; }
    public string? AuthorPetType { get; set; }
    public required string Content { get; set; }
    public int Rating { get; set; }
    public int PetFriendlinessRating { get; set; }
    public int CleanlinessRating { get; set; }
    public int AmenitiesRating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
