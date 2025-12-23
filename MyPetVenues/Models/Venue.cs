namespace MyPetVenues.Models;

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
    public VenueCategory Category { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> GalleryImages { get; set; } = [];
    public List<PetType> AcceptedPetTypes { get; set; } = [];
    public List<Amenity> Amenities { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
    public string Hours { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
    public DateTime DateAdded { get; set; }
    
    public double AverageRating => Reviews.Count > 0 
        ? Math.Round(Reviews.Average(r => r.Rating), 1) 
        : 0;
    
    public int ReviewCount => Reviews.Count;

    public string FullAddress => $"{Address}, {City}, {State} {ZipCode}";
}
