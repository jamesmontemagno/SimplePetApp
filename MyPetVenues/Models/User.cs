namespace MyPetVenues.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public List<Pet> Pets { get; set; } = new();
    public int ReviewCount { get; set; }
    public DateTime JoinDate { get; set; }
}
