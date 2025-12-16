namespace MyPetVenues.Models;

public sealed record Venue(
    int Id,
    string Name,
    string Description,
    string Address,
    string City,
    string State,
    string ImageUrl,
    double Rating,
    int ReviewCount,
    IReadOnlyList<VenueAmenity> Amenities,
    VenueRules Rules,
    IReadOnlyList<VenueReview> Reviews);
