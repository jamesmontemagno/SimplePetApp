namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public PetType PetType { get; set; }
    public string PetName { get; set; } = string.Empty;
    public string PetImageUrl { get; set; } = string.Empty;
}
