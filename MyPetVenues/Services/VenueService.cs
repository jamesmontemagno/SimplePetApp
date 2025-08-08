using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class VenueService : IVenueService
{
    private readonly List<Venue> _venues;

    public VenueService()
    {
        _venues = SeedVenues();
    }

    public Task<IEnumerable<Venue>> GetAllAsync()
    {
        return Task.FromResult(_venues.AsEnumerable());
    }

    public Task<IEnumerable<Venue>> SearchAsync(string? term = null, string? category = null, string? petType = null)
    {
        var query = _venues.AsQueryable();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(v => 
                v.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                v.City.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                v.ShortDescription.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(v => v.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(petType))
        {
            query = query.Where(v => v.PetTypesAllowed.Contains(petType, StringComparer.OrdinalIgnoreCase));
        }

        return Task.FromResult(query.AsEnumerable());
    }

    public Task<IEnumerable<Venue>> GetFeaturedAsync(int count = 3)
    {
        var featured = _venues.Where(v => v.IsFeatured).Take(count);
        return Task.FromResult(featured);
    }

    private static List<Venue> SeedVenues()
    {
        return new List<Venue>
        {
            new(1, "The Paws Café", "Café", "Seattle", 
                new() { "Dogs", "Cats" }, 
                new() { "Outdoor Seating", "Pet Menu", "Water Bowls" },
                "images/venues/cafe1.jpg", "images/venues/cafe1.jpg",
                "A cozy café where your furry friends are welcome to join you for coffee and treats. Features special pet menu items.",
                "Pets must be leashed", 4.7, 156, true),

            new(2, "Riverside Park", "Park", "Portland", 
                new() { "Dogs", "Cats", "Birds" }, 
                new() { "Off-leash Area", "Walking Trails", "Pet Waste Stations" },
                "images/venues/park1.jpg", "images/venues/park1.jpg",
                "Expansive park with dedicated off-leash areas and scenic walking trails perfect for pets of all sizes.",
                null, 4.5, 89, true),

            new(3, "Pet Palace Hotel", "Hotel", "San Francisco", 
                new() { "Dogs", "Cats", "Small Pets" }, 
                new() { "Pet Spa", "Pet Sitting", "Premium Bedding" },
                "images/venues/hotel1.jpg", "images/venues/hotel1.jpg",
                "Luxury hotel that treats your pets like royalty with spa services and premium accommodations.",
                "Weight limit 80lbs", 4.8, 234, true),

            new(4, "Tail Waggers Store", "Pet Store", "Austin", 
                new() { "Dogs", "Cats", "Birds", "Small Pets" }, 
                new() { "Grooming", "Training Classes", "Adoption Center" },
                "images/venues/store1.jpg", "images/venues/store1.jpg",
                "Complete pet store offering everything from supplies to professional grooming and training services.",
                null, 4.4, 67, false),

            new(5, "Happy Tails Home", "Boarding", "Denver", 
                new() { "Dogs", "Cats" }, 
                new() { "24/7 Care", "Play Areas", "Webcam Access" },
                "images/venues/home1.jpg", "images/venues/home1.jpg",
                "Home-style pet boarding facility providing loving care in a comfortable, home-like environment.",
                "Vaccinations required", 4.6, 142, false),

            new(6, "Mooch's Diner", "Restaurant", "Nashville", 
                new() { "Dogs" }, 
                new() { "Patio Dining", "Pet Menu", "Dog Treats" },
                "images/venues/moochs1.jpg", "images/venues/moochs1.jpg",
                "Family-friendly diner with a spacious patio where dogs can enjoy the dining experience too.",
                "Dogs only, must be leashed", 4.2, 78, false),

            new(7, "Urban Dog Run", "Park", "Chicago", 
                new() { "Dogs" }, 
                new() { "Agility Equipment", "Separate Small Dog Area", "Shade Structures" },
                "images/venues/park1.jpg", "images/venues/park1.jpg",
                "Modern dog park featuring agility equipment and separate areas for dogs of different sizes.",
                "Dogs must be socialized", 4.3, 91, false),

            new(8, "The Pet Spa Retreat", "Spa", "Los Angeles", 
                new() { "Dogs", "Cats" }, 
                new() { "Full Grooming", "Massage Therapy", "Aromatherapy" },
                "images/venues/hotel1.jpg", "images/venues/hotel1.jpg",
                "Premium spa services for pets including grooming, massage, and relaxation treatments.",
                "Appointment required", 4.9, 187, true),

            new(9, "Brew & Bow-Wow", "Brewery", "Portland", 
                new() { "Dogs" }, 
                new() { "Outdoor Seating", "Dog Treats", "Water Stations" },
                "images/venues/cafe1.jpg", "images/venues/cafe1.jpg",
                "Dog-friendly brewery where you can enjoy craft beer while your pup socializes and relaxes.",
                "Dogs must be well-behaved", 4.1, 203, false),

            new(10, "Adventure Trails Lodge", "Hiking", "Boulder", 
                new() { "Dogs", "Small Pets" }, 
                new() { "Trail Maps", "Pet First Aid", "Mountain Views" },
                "images/venues/park1.jpg", "images/venues/park1.jpg",
                "Scenic hiking trails with pet-friendly accommodations and stunning mountain views.",
                "Leash required on trails", 4.5, 156, false)
        };
    }
}