namespace MyPetVenues.Models;

public sealed record VenueReview(
    int Id,
    int VenueId,
    int Rating,
    string Author,
    string Text,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<VenueAmenity, bool?> AmenityConfirmations);
