namespace MyPetVenues.Models;

/// <summary>
/// Represents search and filter criteria for venue queries.
/// </summary>
public class VenueSearchCriteria
{
    public string? SearchTerm { get; set; }
    public VenueType? Type { get; set; }
    public string? City { get; set; }
    public List<string> RequiredAmenities { get; set; } = new();
    public bool AllowsDogs { get; set; } = true;
    public bool AllowsCats { get; set; } = true;
    public double MinimumRating { get; set; }
    public VenueSortOption SortBy { get; set; } = VenueSortOption.RatingDesc;
}

/// <summary>
/// Sort options for venue listings.
/// </summary>
public enum VenueSortOption
{
    RatingDesc,
    RatingAsc,
    ReviewCountDesc,
    NameAsc,
    NameDesc,
    Newest
}
