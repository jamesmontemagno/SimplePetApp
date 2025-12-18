namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
}
