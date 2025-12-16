using MyPetVenues.Models;

namespace MyPetVenues.Services;

/// <summary>
/// Interface for venue data access.
/// Follows Dependency Inversion Principle - abstracts data source.
/// </summary>
public interface IVenueRepository
{
    /// <summary>
    /// Gets all venues from the data source.
    /// </summary>
    IReadOnlyList<Venue> GetAll();

    /// <summary>
    /// Gets a venue by ID from the data source.
    /// </summary>
    Venue? GetById(int id);
}
