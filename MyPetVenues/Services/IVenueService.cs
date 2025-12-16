using MyPetVenues.Models;

namespace MyPetVenues.Services;

/// <summary>
/// Interface for venue-related operations.
/// Follows Interface Segregation Principle - only venue-specific methods.
/// </summary>
public interface IVenueService
{
    /// <summary>
    /// Gets all venues.
    /// </summary>
    IReadOnlyList<Venue> GetAllVenues();

    /// <summary>
    /// Gets a venue by its unique identifier.
    /// </summary>
    /// <param name="id">The venue ID.</param>
    /// <returns>The venue if found; otherwise, null.</returns>
    Venue? GetVenueById(int id);

    /// <summary>
    /// Searches venues based on the provided criteria.
    /// </summary>
    /// <param name="criteria">The search and filter criteria.</param>
    /// <returns>A list of matching venues.</returns>
    IReadOnlyList<Venue> SearchVenues(VenueSearchCriteria criteria);

    /// <summary>
    /// Gets all unique amenities across all venues.
    /// </summary>
    IReadOnlyList<string> GetAllAmenities();

    /// <summary>
    /// Gets all unique cities where venues are located.
    /// </summary>
    IReadOnlyList<string> GetAllCities();

    /// <summary>
    /// Gets venues similar to the specified venue (same type).
    /// </summary>
    /// <param name="venueId">The venue ID to find similar venues for.</param>
    /// <param name="count">Maximum number of similar venues to return.</param>
    IReadOnlyList<Venue> GetSimilarVenues(int venueId, int count = 3);

    /// <summary>
    /// Gets venues similar to the specified venue by type.
    /// </summary>
    /// <param name="venueId">The venue ID to exclude.</param>
    /// <param name="type">The venue type to match.</param>
    /// <param name="count">Maximum number of similar venues to return.</param>
    IReadOnlyList<Venue> GetSimilarVenues(int venueId, VenueType type, int count = 3);
}
