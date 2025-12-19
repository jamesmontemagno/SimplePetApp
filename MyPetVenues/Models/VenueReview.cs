namespace MyPetVenues.Models;

public record class VenueReview
{
    public required string Author { get; init; }
    public required string PetType { get; init; }
    public required int Rating { get; init; }
    public required string Comment { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
