using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<List<Venue>> GetVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType);
}

public class VenueService : IVenueService
{
    private readonly List<Venue> _venues;

    public VenueService()
    {
        _venues = GenerateSampleVenues();
    }

    public Task<List<Venue>> GetVenuesAsync()
    {
        return Task.FromResult(_venues);
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(venue);
    }

    public Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType)
    {
        var filteredVenues = _venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            filteredVenues = filteredVenues.Where(v => 
                v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (category.HasValue)
        {
            filteredVenues = filteredVenues.Where(v => v.Category == category.Value);
        }

        if (petType.HasValue)
        {
            filteredVenues = filteredVenues.Where(v => v.AllowedPetTypes.Contains(petType.Value));
        }

        return Task.FromResult(filteredVenues.ToList());
    }

    private List<Venue> GenerateSampleVenues()
    {
        return new List<Venue>
        {
            new(1, "Paws & Coffee", "Cozy café where your furry friends are as welcome as you are. Outdoor seating with water bowls and treats available.",
                "123 Main St", "Seattle", "WA", "98101", VenueCategory.Cafe,
                new List<PetType> { PetType.Dog, PetType.Cat },
                new List<string> { "Outdoor Seating", "Pet Water Bowls", "Pet Treats", "Wi-Fi" },
                new List<string> { "Pets must be leashed", "No aggressive pets" },
                4.5, 127, "images/venues/cafe1.jpg", "https://pawsandcoffee.com", "(206) 555-0123"),

            new(2, "Doggy Day Park", "Large off-leash park with separate areas for small and large dogs. Agility equipment and shaded seating areas.",
                "456 Park Ave", "Seattle", "WA", "98102", VenueCategory.Park,
                new List<PetType> { PetType.Dog },
                new List<string> { "Off-Leash Area", "Agility Equipment", "Waste Stations", "Parking" },
                new List<string> { "Dogs must be vaccinated", "Owner supervision required" },
                4.7, 203, "images/venues/park1.jpg", null, null),

            new(3, "The Pet-Friendly Inn", "Boutique hotel welcoming pets with special amenities including pet beds, toys, and walking services.",
                "789 Hotel Blvd", "Portland", "OR", "97201", VenueCategory.Hotel,
                new List<PetType> { PetType.Dog, PetType.Cat, PetType.SmallAnimal },
                new List<string> { "Pet Beds", "Walking Service", "Pet Toys", "Room Service" },
                new List<string> { "Pet fee applies", "Weight limit 80lbs", "2 pets max per room" },
                4.3, 89, "images/venues/hotel1.jpg", "https://petfriendlyinn.com", "(503) 555-0456"),

            new(4, "Furry Friends Bistro", "Upscale restaurant with a dedicated pet patio featuring a special dog menu alongside human cuisine.",
                "321 Dining St", "San Francisco", "CA", "94101", VenueCategory.Restaurant,
                new List<PetType> { PetType.Dog },
                new List<string> { "Pet Menu", "Outdoor Patio", "Pet Water", "Waste Bags" },
                new List<string> { "Outdoor seating only", "Reservations recommended" },
                4.6, 156, null, "https://furryfriendsbistro.com", "(415) 555-0789"),

            new(5, "Sunny Beach Dog Run", "Beautiful beach area designated for dogs to run free and play in the sand and waves.",
                "Ocean View Dr", "Santa Monica", "CA", "90401", VenueCategory.Beach,
                new List<PetType> { PetType.Dog },
                new List<string> { "Off-Leash", "Beach Access", "Shower Stations", "Parking" },
                new List<string> { "Dawn to dusk only", "Clean up required", "Aggressive dogs prohibited" },
                4.8, 342, null, null, null),

            new(6, "Mountain Paws Trail", "Scenic hiking trail perfect for dogs with multiple difficulty levels and creek access for cooling off.",
                "Trail Head Rd", "Boulder", "CO", "80301", VenueCategory.Trail,
                new List<PetType> { PetType.Dog },
                new List<string> { "Creek Access", "Multiple Trails", "Parking", "Trail Maps" },
                new List<string> { "Leash required on main trail", "Wildlife area - be cautious" },
                4.4, 78, null, null, null),

            new(7, "Pet Paradise Shop", "Complete pet store with grooming services, supplies, and adoption events every weekend.",
                "555 Commerce Way", "Austin", "TX", "78701", VenueCategory.Shop,
                new List<PetType> { PetType.Dog, PetType.Cat, PetType.Bird, PetType.SmallAnimal, PetType.Reptile, PetType.Fish },
                new List<string> { "Grooming Services", "Adoption Events", "Pet Training", "Delivery" },
                new List<string> { "Well-behaved pets only", "Vaccination records required for grooming" },
                4.2, 198, null, "https://petparadiseshop.com", "(512) 555-0321"),

            new(8, "Whiskers & Wags Café", "Cat café featuring adoptable cats and specialty coffee drinks. Perfect for cat lovers looking to relax.",
                "888 Purr Lane", "Portland", "OR", "97202", VenueCategory.Cafe,
                new List<PetType> { PetType.Cat },
                new List<string> { "Adoptable Cats", "Cat Toys", "Reading Corner", "Cat Treats" },
                new List<string> { "No outside cats allowed", "Children must be supervised", "Adoption process required" },
                4.5, 167, null, "https://whiskersandwags.com", "(503) 555-0654")
        };
    }
}