using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class InMemoryVenueService : IVenueService
{
    private readonly List<Venue> _venues;

    public InMemoryVenueService()
    {
        _venues = new List<Venue>
        {
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Paws & Beans Café",
                Category = VenueCategory.Cafe,
                City = "Seattle",
                Description = "A cozy neighborhood café that welcomes furry friends. Enjoy artisan coffee while your pet relaxes on our outdoor patio.",
                PetTypesAllowed = new List<string> { "Dog", "Cat" },
                Amenities = new List<string> { "Outdoor Seating", "Water Bowls", "Pet Treats" },
                Image = "images/venues/cafe1.jpg",
                Rating = 4.7,
                ReviewsCount = 142,
                Tags = new List<string> { "pet-friendly", "coffee", "outdoor", "treats" },
                IsVerified = true,
                LastUpdated = DateTime.Now.AddDays(-5)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Central Bark Park",
                Category = VenueCategory.Park,
                City = "Portland",
                Description = "Large off-leash dog park with separate areas for small and large dogs. Features agility equipment and plenty of shade.",
                PetTypesAllowed = new List<string> { "Dog" },
                Amenities = new List<string> { "Off-Leash Area", "Agility Equipment", "Waste Stations", "Water Fountains" },
                Image = "images/venues/park1.jpg",
                Rating = 4.9,
                ReviewsCount = 89,
                Tags = new List<string> { "off-leash", "exercise", "dogs-only", "agility" },
                IsVerified = true,
                LastUpdated = DateTime.Now.AddDays(-12)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "The Pet Palace Hotel",
                Category = VenueCategory.Hotel,
                City = "San Francisco",
                Description = "Luxury hotel that treats pets like royalty. Premium pet amenities and dedicated pet concierge service.",
                PetTypesAllowed = new List<string> { "Dog", "Cat", "Rabbit" },
                Amenities = new List<string> { "Pet Beds", "Room Service", "Pet Spa", "Walking Service" },
                Image = "images/venues/hotel1.jpg",
                Rating = 4.8,
                ReviewsCount = 76,
                Tags = new List<string> { "luxury", "pet-spa", "concierge", "premium" },
                IsVerified = false,
                LastUpdated = DateTime.Now.AddDays(-8)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Pet Supplies Plus",
                Category = VenueCategory.Store,
                City = "Austin",
                Description = "One-stop shop for all your pet needs. From food to toys to accessories, we have everything for your furry family.",
                PetTypesAllowed = new List<string> { "Dog", "Cat", "Rabbit", "Hedgehog" },
                Amenities = new List<string> { "Shopping Carts", "Free Samples", "Expert Advice" },
                Image = "images/venues/store1.jpg",
                Rating = 4.5,
                ReviewsCount = 203,
                Tags = new List<string> { "shopping", "supplies", "food", "toys" },
                IsVerified = true,
                LastUpdated = DateTime.Now.AddDays(-3)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Paws & Work Co-Space",
                Category = VenueCategory.Coworking,
                City = "Denver",
                Description = "Modern coworking space designed for pet owners. High-speed wifi, meeting rooms, and a dedicated pet play area.",
                PetTypesAllowed = new List<string> { "Dog", "Cat" },
                Amenities = new List<string> { "WiFi", "Meeting Rooms", "Pet Play Area", "Coffee Bar" },
                Image = "images/venues/home1.jpg",
                Rating = 4.6,
                ReviewsCount = 34,
                Tags = new List<string> { "coworking", "professional", "pet-play", "wifi" },
                IsVerified = false,
                LastUpdated = DateTime.Now.AddDays(-15)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Mooch's Pet Bistro",
                Category = VenueCategory.Cafe,
                City = "Chicago",
                Description = "Unique dining experience where pets can enjoy specially prepared meals alongside their owners.",
                PetTypesAllowed = new List<string> { "Dog", "Cat" },
                Amenities = new List<string> { "Pet Menu", "Indoor Dining", "Pet High Chairs" },
                Image = "images/venues/moochs1.jpg",
                Rating = 4.4,
                ReviewsCount = 67,
                Tags = new List<string> { "dining", "pet-menu", "unique", "indoor" },
                IsVerified = true,
                LastUpdated = DateTime.Now.AddDays(-7)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "Rainbow Bridge Retreat",
                Category = VenueCategory.Other,
                City = "Asheville",
                Description = "Peaceful sanctuary offering meditation and wellness activities for both pets and their humans.",
                PetTypesAllowed = new List<string> { "Dog", "Cat", "Rabbit", "Hedgehog" },
                Amenities = new List<string> { "Meditation Garden", "Wellness Classes", "Natural Trails" },
                Image = "images/pets/dog1.png",
                Rating = 4.3,
                ReviewsCount = 28,
                Tags = new List<string> { "wellness", "meditation", "peaceful", "nature" },
                IsVerified = false,
                LastUpdated = DateTime.Now.AddDays(-20)
            },
            new Venue
            {
                Id = Guid.NewGuid(),
                Name = "The Bunny Hop Market",
                Category = VenueCategory.Store,
                City = "Portland",
                Description = "Specialty store focusing on small pet needs. Expert staff and unique products for rabbits, hedgehogs, and more.",
                PetTypesAllowed = new List<string> { "Rabbit", "Hedgehog" },
                Amenities = new List<string> { "Specialty Products", "Expert Staff", "Small Pet Focus" },
                Image = "images/pets/bunny.jpg",
                Rating = 4.9,
                ReviewsCount = 45,
                Tags = new List<string> { "specialty", "small-pets", "expert", "unique" },
                IsVerified = true,
                LastUpdated = DateTime.Now.AddDays(-4)
            }
        };
    }

    public Task<IEnumerable<Venue>> GetAllAsync()
    {
        return Task.FromResult(_venues.AsEnumerable());
    }

    public Task<Venue?> GetByIdAsync(Guid id)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(venue);
    }

    public Task<IEnumerable<Venue>> SearchAsync(string? text, VenueCategory? category, string? petType)
    {
        var query = _venues.AsEnumerable();

        // Filter by text (search in Name, Description, and Tags)
        if (!string.IsNullOrWhiteSpace(text))
        {
            var searchText = text.ToLowerInvariant();
            query = query.Where(v => 
                v.Name.ToLowerInvariant().Contains(searchText) ||
                v.Description.ToLowerInvariant().Contains(searchText) ||
                v.Tags.Any(tag => tag.ToLowerInvariant().Contains(searchText))
            );
        }

        // Filter by category
        if (category.HasValue)
        {
            query = query.Where(v => v.Category == category.Value);
        }

        // Filter by pet type
        if (!string.IsNullOrWhiteSpace(petType))
        {
            var searchPetType = petType.ToLowerInvariant();
            query = query.Where(v => 
                v.PetTypesAllowed.Any(pt => pt.ToLowerInvariant().Contains(searchPetType))
            );
        }

        return Task.FromResult(query);
    }
}