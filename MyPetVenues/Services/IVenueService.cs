using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<List<Venue>> GetAllVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType);
    Task<Venue> AddVenueAsync(Venue venue);
    Task<Review> AddReviewAsync(int venueId, Review review);
}
