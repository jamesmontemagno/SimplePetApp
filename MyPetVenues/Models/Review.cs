namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int LocationId { get; set; }
    public required int Rating { get; set; } // 1-5 stars
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public int HelpfulVotes { get; set; } = 0;
    public List<string> Photos { get; set; } = new();
    
    // Navigation properties
    public User? User { get; set; }
    public Location? Location { get; set; }
}