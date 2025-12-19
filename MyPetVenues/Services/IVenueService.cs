using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<List<Venue>> GetVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueType? venueType, PetType? petType, Amenity? amenity);
    Task<List<Venue>> GetFeaturedVenuesAsync(int count = 6);
    Task AddVenueAsync(Venue venue);
}

public interface IReviewService
{
    Task<List<Review>> GetReviewsByVenueIdAsync(int venueId);
    Task<List<Review>> GetRecentReviewsAsync(int count = 5);
    Task AddReviewAsync(Review review);
}
