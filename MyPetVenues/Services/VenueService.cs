using MyPetVenues.Models;

namespace MyPetVenues.Services;

/// <summary>
/// Implementation of IVenueService.
/// Single Responsibility: Business logic for venue operations.
/// Open/Closed: Can extend functionality without modifying existing code.
/// Dependency Inversion: Depends on IVenueRepository abstraction.
/// </summary>
public class VenueService : IVenueService
{
    private readonly IVenueRepository _repository;

    public VenueService(IVenueRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public IReadOnlyList<Venue> GetAllVenues() => _repository.GetAll();

    public Venue? GetVenueById(int id) => _repository.GetById(id);

    public IReadOnlyList<Venue> SearchVenues(VenueSearchCriteria criteria)
    {
        ArgumentNullException.ThrowIfNull(criteria);

        var query = _repository.GetAll().AsEnumerable();

        query = ApplySearchFilter(query, criteria.SearchTerm);
        query = ApplyTypeFilter(query, criteria.Type);
        query = ApplyCityFilter(query, criteria.City);
        query = ApplyAmenitiesFilter(query, criteria.RequiredAmenities);
        query = ApplyPetFilters(query, criteria.AllowsDogs, criteria.AllowsCats);
        query = ApplyMinimumRatingFilter(query, criteria.MinimumRating);
        query = ApplySorting(query, criteria.SortBy);

        return query.ToList().AsReadOnly();
    }

    public IReadOnlyList<string> GetAllAmenities()
    {
        return _repository.GetAll()
            .SelectMany(v => v.Amenities)
            .Distinct()
            .OrderBy(a => a)
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyList<string> GetAllCities()
    {
        return _repository.GetAll()
            .Select(v => v.City)
            .Distinct()
            .OrderBy(c => c)
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyList<Venue> GetSimilarVenues(int venueId, int count = 3)
    {
        var venue = _repository.GetById(venueId);
        if (venue == null) return Array.Empty<Venue>();

        return GetSimilarVenues(venueId, venue.Type, count);
    }

    public IReadOnlyList<Venue> GetSimilarVenues(int venueId, VenueType type, int count = 3)
    {
        return _repository.GetAll()
            .Where(v => v.Id != venueId && v.Type == type)
            .OrderByDescending(v => v.Rating)
            .Take(count)
            .ToList()
            .AsReadOnly();
    }

    private static IEnumerable<Venue> ApplySearchFilter(IEnumerable<Venue> query, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;

        var term = searchTerm.ToLowerInvariant();
        return query.Where(v =>
            v.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            v.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            v.City.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            v.Address.Contains(term, StringComparison.OrdinalIgnoreCase));
    }

    private static IEnumerable<Venue> ApplyTypeFilter(IEnumerable<Venue> query, VenueType? type)
    {
        if (!type.HasValue)
            return query;

        return query.Where(v => v.Type == type.Value);
    }

    private static IEnumerable<Venue> ApplyCityFilter(IEnumerable<Venue> query, string? city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return query;

        return query.Where(v => v.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }

    private static IEnumerable<Venue> ApplyAmenitiesFilter(IEnumerable<Venue> query, List<string> requiredAmenities)
    {
        if (requiredAmenities.Count == 0)
            return query;

        return query.Where(v => requiredAmenities.All(req =>
            v.Amenities.Any(a => a.Contains(req, StringComparison.OrdinalIgnoreCase))));
    }

    private static IEnumerable<Venue> ApplyPetFilters(IEnumerable<Venue> query, bool allowsDogs, bool allowsCats)
    {
        // If both are selected, no filtering needed
        if (allowsDogs && allowsCats)
            return query;

        // If neither is selected, show all (or could show none)
        if (!allowsDogs && !allowsCats)
            return query;

        // Filter by specific pet type
        if (allowsDogs && !allowsCats)
            return query.Where(v => v.PetTypesAllowed.Any(p => p.Contains("Dogs", StringComparison.OrdinalIgnoreCase)));
        
        if (!allowsDogs && allowsCats)
            return query.Where(v => v.PetTypesAllowed.Any(p => p.Contains("Cats", StringComparison.OrdinalIgnoreCase)));

        return query;
    }

    private static IEnumerable<Venue> ApplyMinimumRatingFilter(IEnumerable<Venue> query, double minimumRating)
    {
        if (minimumRating <= 0)
            return query;

        return query.Where(v => v.Rating >= minimumRating);
    }

    private static IEnumerable<Venue> ApplySorting(IEnumerable<Venue> query, VenueSortOption sortBy)
    {
        return sortBy switch
        {
            VenueSortOption.RatingDesc => query.OrderByDescending(v => v.Rating),
            VenueSortOption.RatingAsc => query.OrderBy(v => v.Rating),
            VenueSortOption.ReviewCountDesc => query.OrderByDescending(v => v.ReviewCount),
            VenueSortOption.NameAsc => query.OrderBy(v => v.Name),
            VenueSortOption.NameDesc => query.OrderByDescending(v => v.Name),
            VenueSortOption.Newest => query.OrderByDescending(v => v.Id), // Using ID as proxy for newest
            _ => query.OrderByDescending(v => v.Rating)
        };
    }
}

