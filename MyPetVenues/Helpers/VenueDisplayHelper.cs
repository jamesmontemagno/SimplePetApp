using MyPetVenues.Models;

namespace MyPetVenues.Helpers;

/// <summary>
/// Provides display formatting utilities for venues.
/// Single Responsibility: Only handles display formatting logic.
/// </summary>
public static class VenueDisplayHelper
{
    /// <summary>
    /// Gets the emoji representation of a venue type.
    /// </summary>
    public static string GetTypeEmoji(VenueType type) => type switch
    {
        VenueType.Park => "🌳",
        VenueType.Restaurant => "🍔",
        VenueType.Cafe => "☕",
        VenueType.Hotel => "🏨",
        VenueType.Store => "🛍️",
        VenueType.Beach => "🏖️",
        VenueType.Boarding => "🏠",
        VenueType.Grooming => "✂️",
        VenueType.VetClinic => "🏥",
        _ => "📍"
    };

    /// <summary>
    /// Gets the emoji representation of a pet type.
    /// </summary>
    public static string GetPetEmoji(string petType) => petType.ToLowerInvariant() switch
    {
        "dogs" => "🐕",
        "cats" => "🐱",
        "birds" => "🐦",
        "small pets" => "🐹",
        "reptiles" => "🦎",
        _ => "🐾"
    };

    /// <summary>
    /// Converts a numeric rating to star characters.
    /// </summary>
    public static string GetStars(double rating)
    {
        var fullStars = (int)Math.Floor(rating);
        var hasHalfStar = rating - fullStars >= 0.5;
        var emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0);

        return new string('★', fullStars) +
               (hasHalfStar ? "½" : "") +
               new string('☆', emptyStars);
    }

    /// <summary>
    /// Truncates text to a maximum length with ellipsis.
    /// </summary>
    public static string TruncateText(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text[..maxLength].TrimEnd() + "...";
    }
}
