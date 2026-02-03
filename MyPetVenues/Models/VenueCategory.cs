namespace MyPetVenues.Models;

public enum VenueCategory
{
    Park,
    Cafe,
    Restaurant,
    Hotel,
    Store,
    Beach,
    Grooming,
    Veterinary,
    DayCare,
    Trail,
    Other
}

public static class VenueCategoryExtensions
{
    public static string GetEmoji(this VenueCategory category) => category switch
    {
        VenueCategory.Park => "🌳",
        VenueCategory.Cafe => "☕",
        VenueCategory.Restaurant => "🍽️",
        VenueCategory.Hotel => "🏨",
        VenueCategory.Store => "🛍️",
        VenueCategory.Beach => "🏖️",
        VenueCategory.Grooming => "✂️",
        VenueCategory.Veterinary => "🏥",
        VenueCategory.DayCare => "🏠",
        VenueCategory.Trail => "🥾",
        VenueCategory.Other => "📍",
        _ => "📍"
    };

    public static string GetDisplayName(this VenueCategory category) => category switch
    {
        VenueCategory.Park => "Park",
        VenueCategory.Cafe => "Café",
        VenueCategory.Restaurant => "Restaurant",
        VenueCategory.Hotel => "Hotel",
        VenueCategory.Store => "Pet Store",
        VenueCategory.Beach => "Beach",
        VenueCategory.Grooming => "Grooming",
        VenueCategory.Veterinary => "Veterinary",
        VenueCategory.DayCare => "Day Care",
        VenueCategory.Trail => "Trail",
        VenueCategory.Other => "Other",
        _ => "Other"
    };
}
