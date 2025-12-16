namespace MyPetVenues.Models;

/// <summary>
/// Represents a user review for a venue.
/// </summary>
public class Review
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorAvatar { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public double Rating { get; set; }
    public double CleanlinessRating { get; set; }
    public double StaffRating { get; set; }
    public double PetFriendlinessRating { get; set; }
    public DateTime DatePosted { get; set; }
    public string? PetName { get; set; }
    public string? PetType { get; set; }
}
