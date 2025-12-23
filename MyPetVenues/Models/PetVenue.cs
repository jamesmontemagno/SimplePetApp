namespace MyPetVenues.Models;

public sealed record class PetVenue
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Category { get; init; }
    public required string PetType { get; init; }
    public required string ImageUrl { get; init; }
    public required string Description { get; init; }
    public IReadOnlyList<string> Amenities { get; init; } = Array.Empty<string>();
    public double Rating { get; init; }
    public int ReviewCount { get; init; }
    public bool Featured { get; init; }
    public string? Website { get; init; }
    public string? Address { get; init; }
    public string? Hours { get; init; }
}
