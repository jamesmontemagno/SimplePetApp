using MyPetVenues.Models;
using System.Net.Http.Json;

namespace MyPetVenues.Services;

public interface ILocationService
{
    Task<List<Location>> GetLocationsAsync();
    Task<Location?> GetLocationByIdAsync(int id);
    Task<List<Location>> SearchLocationsAsync(string query, LocationType? type = null);
}

public class LocationService : ILocationService
{
    private readonly HttpClient _httpClient;

    public LocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Location>> GetLocationsAsync()
    {
        // For demo purposes, return mock data
        // In a real app, this would fetch from an API
        await Task.Delay(100); // Simulate API call
        return GetMockLocations();
    }

    public async Task<Location?> GetLocationByIdAsync(int id)
    {
        var locations = await GetLocationsAsync();
        return locations.FirstOrDefault(l => l.Id == id);
    }

    public async Task<List<Location>> SearchLocationsAsync(string query, LocationType? type = null)
    {
        var locations = await GetLocationsAsync();
        
        var filtered = locations.AsEnumerable();
        
        if (!string.IsNullOrWhiteSpace(query))
        {
            filtered = filtered.Where(l => 
                l.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                l.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                l.Address.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
        
        if (type.HasValue)
        {
            filtered = filtered.Where(l => l.Type == type.Value);
        }
        
        return filtered.ToList();
    }

    private List<Location> GetMockLocations()
    {
        var amenities = new List<Amenity>
        {
            new() { Id = 1, Name = "Dog Run", Icon = "🐕" },
            new() { Id = 2, Name = "Water Bowl", Icon = "💧" },
            new() { Id = 3, Name = "Pet Treats", Icon = "🦴" },
            new() { Id = 4, Name = "Pet Menu", Icon = "🍽️" },
            new() { Id = 5, Name = "Outdoor Seating", Icon = "🪑" },
            new() { Id = 6, Name = "Pet Beds", Icon = "🛏️" },
            new() { Id = 7, Name = "Grooming", Icon = "✂️" },
            new() { Id = 8, Name = "Vet on Site", Icon = "🏥" }
        };

        return new List<Location>
        {
            new()
            {
                Id = 1,
                Name = "Central Bark Park",
                Description = "Spacious, clean, and perfect for a game of fetch! Large off-leash area with separate sections for small and large dogs.",
                Address = "123 Park Ave, Downtown",
                ImageUrl = "images/venues/park1.jpg",
                Type = LocationType.Park,
                Latitude = 40.7128,
                Longitude = -74.0060,
                Amenities = new List<Amenity> { amenities[0], amenities[1] },
                PetPolicy = "All dogs welcome. Must be on leash when entering/exiting. Off-leash allowed in designated areas.",
                Phone = "(555) 123-4567",
                Website = "https://centralbarkpark.com",
                Hours = new List<string> { "6:00 AM - 10:00 PM Daily" },
                Reviews = new List<Review>
                {
                    new() { Id = 1, UserName = "Sarah M.", Comment = "Amazing park! My golden retriever loves it here.", Rating = 5, Date = DateTime.Now.AddDays(-10), PetType = "Dog" },
                    new() { Id = 2, UserName = "Mike T.", Comment = "Great facilities and very clean.", Rating = 4, Date = DateTime.Now.AddDays(-5), PetType = "Dog" }
                }
            },
            new()
            {
                Id = 2,
                Name = "Paws & Coffee",
                Description = "Enjoy a latte while your pet gets a treat. Cozy atmosphere with indoor and outdoor seating for you and your furry friend.",
                Address = "456 Coffee St, Midtown",
                ImageUrl = "images/venues/cafe1.jpg",
                Type = LocationType.Cafe,
                Latitude = 40.7589,
                Longitude = -73.9851,
                Amenities = new List<Amenity> { amenities[2], amenities[3], amenities[4] },
                PetPolicy = "Well-behaved pets welcome. Must remain on leash. Pet menu available.",
                Phone = "(555) 234-5678",
                Website = "https://pawsandcoffee.com",
                Hours = new List<string> { "7:00 AM - 8:00 PM Mon-Fri", "8:00 AM - 9:00 PM Sat-Sun" },
                Reviews = new List<Review>
                {
                    new() { Id = 3, UserName = "Emma L.", Comment = "Love bringing my cat here in her carrier. Great pet treats!", Rating = 5, Date = DateTime.Now.AddDays(-3), PetType = "Cat" },
                    new() { Id = 4, UserName = "David K.", Comment = "Good coffee and pet-friendly atmosphere.", Rating = 4, Date = DateTime.Now.AddDays(-1), PetType = "Dog" }
                }
            },
            new()
            {
                Id = 3,
                Name = "PetStay Hotel",
                Description = "Traveling? Stay at the best pet-friendly hotel in town. Luxury accommodations for both you and your pet.",
                Address = "789 Hotel Blvd, Business District",
                ImageUrl = "images/venues/hotel1.jpg",
                Type = LocationType.Hotel,
                Latitude = 40.7505,
                Longitude = -73.9934,
                Amenities = new List<Amenity> { amenities[5], amenities[2], amenities[1] },
                PetPolicy = "Pets up to 50lbs welcome. $25 pet fee per night. Pet beds and bowls provided.",
                Phone = "(555) 345-6789",
                Website = "https://petstayhotel.com",
                Hours = new List<string> { "24/7 Check-in" },
                Reviews = new List<Review>
                {
                    new() { Id = 5, UserName = "Lisa R.", Comment = "Excellent service and very pet-friendly staff!", Rating = 5, Date = DateTime.Now.AddDays(-7), PetType = "Dog" },
                    new() { Id = 6, UserName = "John D.", Comment = "Great amenities for pets. Will stay again.", Rating = 4, Date = DateTime.Now.AddDays(-2), PetType = "Cat" }
                }
            },
            new()
            {
                Id = 4,
                Name = "Pet Paradise Store",
                Description = "Everything your pet needs under one roof. From toys to treats, grooming to boarding services.",
                Address = "321 Pet Ave, Shopping Center",
                ImageUrl = "images/venues/store1.jpg",
                Type = LocationType.Store,
                Latitude = 40.7282,
                Longitude = -74.0776,
                Amenities = new List<Amenity> { amenities[6], amenities[2], amenities[7] },
                PetPolicy = "All pets welcome. Grooming services available by appointment.",
                Phone = "(555) 456-7890",
                Website = "https://petparadisestore.com",
                Hours = new List<string> { "9:00 AM - 8:00 PM Mon-Sat", "10:00 AM - 6:00 PM Sun" },
                Reviews = new List<Review>
                {
                    new() { Id = 7, UserName = "Rachel P.", Comment = "Best pet store in the area! Great selection.", Rating = 5, Date = DateTime.Now.AddDays(-4), PetType = "Dog" },
                    new() { Id = 8, UserName = "Tom W.", Comment = "Helpful staff and quality products.", Rating = 4, Date = DateTime.Now.AddDays(-6), PetType = "Cat" }
                }
            },
            new()
            {
                Id = 5,
                Name = "Woof & Whiskers Vet",
                Description = "Comprehensive veterinary care for all your pets. Emergency services available 24/7.",
                Address = "654 Medical Dr, Health District",
                ImageUrl = "images/venues/moochs1.jpg",
                Type = LocationType.Veterinary,
                Latitude = 40.7356,
                Longitude = -74.1724,
                Amenities = new List<Amenity> { amenities[7], amenities[1] },
                PetPolicy = "All pets welcome. Emergency care available. Appointments recommended.",
                Phone = "(555) 567-8901",
                Website = "https://woofandwhiskersvet.com",
                Hours = new List<string> { "8:00 AM - 6:00 PM Mon-Fri", "9:00 AM - 4:00 PM Sat", "Emergency 24/7" },
                Reviews = new List<Review>
                {
                    new() { Id = 9, UserName = "Maria S.", Comment = "Excellent care for my dog. Very professional.", Rating = 5, Date = DateTime.Now.AddDays(-8), PetType = "Dog" },
                    new() { Id = 10, UserName = "Chris B.", Comment = "Great emergency service when my cat was ill.", Rating = 5, Date = DateTime.Now.AddDays(-12), PetType = "Cat" }
                }
            },
            new()
            {
                Id = 6,
                Name = "Happy Tails Restaurant",
                Description = "Fine dining experience that welcomes well-behaved pets. Special pet menu available.",
                Address = "987 Gourmet St, Food District",
                ImageUrl = "images/venues/home1.jpg",
                Type = LocationType.Restaurant,
                Latitude = 40.7411,
                Longitude = -73.9897,
                Amenities = new List<Amenity> { amenities[3], amenities[4], amenities[1] },
                PetPolicy = "Well-behaved pets welcome on patio. Pet menu includes grilled chicken and special treats.",
                Phone = "(555) 678-9012",
                Website = "https://happytailsrestaurant.com",
                Hours = new List<string> { "5:00 PM - 11:00 PM Tue-Sun", "Closed Mondays" },
                Reviews = new List<Review>
                {
                    new() { Id = 11, UserName = "Jessica M.", Comment = "Amazing food and they love pets! My dog got a special meal.", Rating = 5, Date = DateTime.Now.AddDays(-1), PetType = "Dog" },
                    new() { Id = 12, UserName = "Alex K.", Comment = "Great atmosphere and pet-friendly service.", Rating = 4, Date = DateTime.Now.AddDays(-3), PetType = "Dog" }
                }
            }
        };
    }
}