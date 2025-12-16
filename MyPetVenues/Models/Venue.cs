namespace MyPetVenues.Models;

/// <summary>
/// Represents a pet-friendly venue/location.
/// </summary>
public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public VenueType Type { get; set; }
    public List<string> Amenities { get; set; } = new();
    public List<string> PetTypesAllowed { get; set; } = new();
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public string Hours { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public List<Review> Reviews { get; set; } = new();

    /// <summary>
    /// Gets the full address formatted as a single string.
    /// </summary>
    public string FullAddress => $"{Address}, {City}, {State} {ZipCode}";

    /// <summary>
    /// Gets the location formatted as City, State.
    /// </summary>
    public string LocationDisplay => $"{City}, {State}";
}
