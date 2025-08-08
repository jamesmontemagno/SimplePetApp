namespace MyPetVenues.Models;

public record Venue(
    int Id,
    string Name,
    string Category,
    string City,
    List<string> PetTypesAllowed,
    List<string> Amenities,
    string HeroImage,
    string ThumbnailImage,
    string ShortDescription,
    string? Restrictions,
    double? Rating,
    int ReviewsCount,
    bool IsFeatured
);