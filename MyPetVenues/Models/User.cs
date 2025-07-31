namespace MyPetVenues.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublicProfile { get; set; } = true;
    public string Bio { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<Pet> Pets { get; set; } = new();
}