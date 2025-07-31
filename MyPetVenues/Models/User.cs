namespace MyPetVenues.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? DisplayName { get; set; }
    public string? ProfileImage { get; set; }
    public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}