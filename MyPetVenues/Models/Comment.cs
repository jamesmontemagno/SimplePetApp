namespace MyPetVenues.Models;

public class Comment
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int LocationId { get; set; }
    public required string Content { get; set; }
    public int? ParentCommentId { get; set; } // For threaded replies
    public CommentType Type { get; set; } = CommentType.General;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public int LikesCount { get; set; } = 0;
    
    // Navigation properties
    public User? User { get; set; }
    public Location? Location { get; set; }
    public Comment? ParentComment { get; set; }
    public List<Comment> Replies { get; set; } = new();
}

public enum CommentType
{
    General,
    Question,
    Answer,
    Tip
}