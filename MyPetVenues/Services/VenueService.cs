using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<List<Venue>> GetAllVenuesAsync();
    Task<List<Venue>> GetFeaturedVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueType? type, PetType? petType);
    Task<List<Review>> GetVenueReviewsAsync(int venueId);
}

public class MockVenueService : IVenueService
{
    private readonly List<Venue> _venues;
    private readonly List<Review> _reviews;

    public MockVenueService()
    {
        _venues = GenerateMockVenues();
        _reviews = GenerateMockReviews();
    }

    public Task<List<Venue>> GetAllVenuesAsync() => Task.FromResult(_venues);

    public Task<List<Venue>> GetFeaturedVenuesAsync() => 
        Task.FromResult(_venues.Where(v => v.IsFeatured).ToList());

    public Task<Venue?> GetVenueByIdAsync(int id) => 
        Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));

    public Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueType? type, PetType? petType)
    {
        var results = _venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            results = results.Where(v => 
                v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (type.HasValue)
        {
            results = results.Where(v => v.Type == type.Value);
        }

        if (petType.HasValue)
        {
            results = results.Where(v => 
                v.AcceptedPets.Contains(petType.Value) || 
                v.AcceptedPets.Contains(PetType.All));
        }

        return Task.FromResult(results.ToList());
    }

    public Task<List<Review>> GetVenueReviewsAsync(int venueId) => 
        Task.FromResult(_reviews.Where(r => r.VenueId == venueId).OrderByDescending(r => r.DatePosted).ToList());

    private static List<Venue> GenerateMockVenues() => new()
    {
        new Venue
        {
            Id = 1,
            Name = "Pawsome Park",
            Description = "A beautiful 50-acre off-leash dog park with separate areas for large and small dogs. Features agility equipment, water fountains, and shaded seating areas for pet parents.",
            Address = "123 Bark Street",
            City = "San Francisco, CA",
            Phone = "(555) 123-4567",
            Email = "info@pawsomepark.com",
            Website = "www.pawsomepark.com",
            ImageUrl = "images/venues/park1.jpg",
            Type = VenueType.Park,
            AcceptedPets = new List<PetType> { PetType.Dog, PetType.Cat },
            Amenities = new List<string> { "Off-leash area", "Water stations", "Agility equipment", "Shaded seating", "Waste stations", "Parking" },
            PetPolicy = "All friendly dogs welcome. Must be up to date on vaccinations. Aggressive dogs not permitted.",
            Hours = "6:00 AM - 10:00 PM Daily",
            Rating = 4.8,
            ReviewCount = 342,
            IsFeatured = true,
            PricePerHour = 0
        },
        new Venue
        {
            Id = 2,
            Name = "The Barking Bean Café",
            Description = "A cozy pet-friendly café where you can enjoy artisan coffee and pastries while your furry friend relaxes beside you. We even have a special 'Puppuccino' menu!",
            Address = "456 Meow Lane",
            City = "San Francisco, CA",
            Phone = "(555) 234-5678",
            Email = "hello@barkingbean.com",
            Website = "www.barkingbean.com",
            ImageUrl = "images/venues/cafe1.jpg",
            Type = VenueType.Cafe,
            AcceptedPets = new List<PetType> { PetType.All },
            Amenities = new List<string> { "Pet menu", "Water bowls", "Outdoor seating", "Pet treats", "WiFi", "AC" },
            PetPolicy = "All well-behaved pets welcome. Dogs must be leashed. Pet carriers available for small animals.",
            Hours = "7:00 AM - 8:00 PM Daily",
            Rating = 4.6,
            ReviewCount = 189,
            IsFeatured = true,
            PricePerHour = 0
        },
        new Venue
        {
            Id = 3,
            Name = "Paws & Relax Hotel",
            Description = "Luxury pet-friendly accommodations featuring spacious suites, pet spa services, and a dedicated dog walking team. Your pet will feel like royalty!",
            Address = "789 Woof Boulevard",
            City = "Los Angeles, CA",
            Phone = "(555) 345-6789",
            Email = "reservations@pawsrelax.com",
            Website = "www.pawsrelax.com",
            ImageUrl = "images/venues/hotel1.jpg",
            Type = VenueType.Hotel,
            AcceptedPets = new List<PetType> { PetType.Dog, PetType.Cat, PetType.SmallPet },
            Amenities = new List<string> { "Pet spa", "Dog walking", "Pet beds", "Room service", "Pet sitting", "Grooming" },
            PetPolicy = "Two pets per room max. Weight limit 80 lbs. $50/night pet fee. Pet deposit required.",
            Hours = "24/7 Check-in Available",
            Rating = 4.9,
            ReviewCount = 521,
            IsFeatured = true,
            PricePerHour = 150
        },
        new Venue
        {
            Id = 4,
            Name = "Mooch's Bistro",
            Description = "An upscale pet-friendly restaurant with a dedicated patio for dining with your four-legged companions. Our chef even prepares special pet-safe meals!",
            Address = "321 Purr Avenue",
            City = "Seattle, WA",
            Phone = "(555) 456-7890",
            Email = "dine@moochsbistro.com",
            Website = "www.moochsbistro.com",
            ImageUrl = "images/venues/moochs1.jpg",
            Type = VenueType.Restaurant,
            AcceptedPets = new List<PetType> { PetType.Dog, PetType.Cat },
            Amenities = new List<string> { "Pet menu", "Outdoor patio", "Water service", "Pet treats", "Heat lamps" },
            PetPolicy = "Pets welcome on patio only. Must be leashed and well-behaved. No pets inside dining room.",
            Hours = "11:00 AM - 10:00 PM Tue-Sun",
            Rating = 4.5,
            ReviewCount = 267,
            IsFeatured = false,
            PricePerHour = 0
        },
        new Venue
        {
            Id = 5,
            Name = "Happy Tails Pet Store",
            Description = "Your one-stop shop for premium pet supplies, organic treats, and stylish accessories. Bring your pet to help pick out their favorites!",
            Address = "555 Fetch Drive",
            City = "Portland, OR",
            Phone = "(555) 567-8901",
            Email = "shop@happytails.com",
            Website = "www.happytails.com",
            ImageUrl = "images/venues/store1.jpg",
            Type = VenueType.Store,
            AcceptedPets = new List<PetType> { PetType.All },
            Amenities = new List<string> { "Self-serve wash", "Treat bar", "Pet photos", "Training classes", "Adoption events" },
            PetPolicy = "All friendly pets welcome! Please keep dogs leashed and cats in carriers when possible.",
            Hours = "9:00 AM - 9:00 PM Daily",
            Rating = 4.7,
            ReviewCount = 156,
            IsFeatured = true,
            PricePerHour = 0
        },
        new Venue
        {
            Id = 6,
            Name = "Sunny Paws Day Care",
            Description = "Premier doggy daycare with supervised play groups, nap rooms, and webcam access so you can check on your pup anytime!",
            Address = "888 Wagging Way",
            City = "San Diego, CA",
            Phone = "(555) 678-9012",
            Email = "care@sunnypaws.com",
            Website = "www.sunnypaws.com",
            ImageUrl = "images/venues/home1.jpg",
            Type = VenueType.DayCare,
            AcceptedPets = new List<PetType> { PetType.Dog },
            Amenities = new List<string> { "Webcam access", "Play groups", "Nap rooms", "Training", "Grooming", "Report cards" },
            PetPolicy = "Temperament test required. Must be spayed/neutered for daycare. Current vaccinations required.",
            Hours = "6:30 AM - 7:00 PM Mon-Fri",
            Rating = 4.9,
            ReviewCount = 423,
            IsFeatured = false,
            PricePerHour = 35
        }
    };

    private static List<Review> GenerateMockReviews() => new()
    {
        new Review
        {
            Id = 1,
            VenueId = 1,
            UserId = 1,
            UserName = "Sarah M.",
            UserAvatar = "images/pets/dog1.png",
            PetName = "Max",
            PetType = PetType.Dog,
            Rating = 5,
            Comment = "Absolutely love this park! Max has made so many friends here. The separate areas for different sized dogs is a game changer. We come here every weekend! 🐕",
            DatePosted = DateTime.Now.AddDays(-5),
            Photos = new List<string> { "images/pets/dog1.png" },
            HelpfulCount = 24
        },
        new Review
        {
            Id = 2,
            VenueId = 1,
            UserId = 2,
            UserName = "Mike T.",
            UserAvatar = "images/pets/dog3.jpg",
            PetName = "Bella",
            PetType = PetType.Dog,
            Rating = 4,
            Comment = "Great park with lots of space. Bella loves the agility equipment! Only giving 4 stars because parking can be tough on weekends.",
            DatePosted = DateTime.Now.AddDays(-12),
            Photos = new List<string>(),
            HelpfulCount = 18
        },
        new Review
        {
            Id = 3,
            VenueId = 2,
            UserId = 3,
            UserName = "Emily R.",
            UserAvatar = "images/pets/cat1.jpg",
            PetName = "Whiskers",
            PetType = PetType.Cat,
            Rating = 5,
            Comment = "Such a cute café! They were so accommodating with my cat in her carrier. The lavender latte is to die for! ☕🐱",
            DatePosted = DateTime.Now.AddDays(-3),
            Photos = new List<string> { "images/pets/cat1.jpg" },
            HelpfulCount = 31
        },
        new Review
        {
            Id = 4,
            VenueId = 3,
            UserId = 4,
            UserName = "David L.",
            UserAvatar = "images/pets/dog4.png",
            PetName = "Rocky",
            PetType = PetType.Dog,
            Rating = 5,
            Comment = "Stayed here for a week and Rocky was treated like a king! The pet spa service was amazing. Will definitely book again! 👑",
            DatePosted = DateTime.Now.AddDays(-8),
            Photos = new List<string> { "images/pets/dog4.png" },
            HelpfulCount = 45
        },
        new Review
        {
            Id = 5,
            VenueId = 3,
            UserId = 5,
            UserName = "Lisa K.",
            UserAvatar = "images/pets/cat2.jpg",
            PetName = "Luna",
            PetType = PetType.Cat,
            Rating = 5,
            Comment = "Finally a hotel that truly welcomes cats! Luna had her own little bed and the staff gave her so much attention. Perfect stay!",
            DatePosted = DateTime.Now.AddDays(-15),
            Photos = new List<string>(),
            HelpfulCount = 28
        },
        new Review
        {
            Id = 6,
            VenueId = 4,
            UserId = 6,
            UserName = "James W.",
            UserAvatar = "images/pets/dog5.jpg",
            PetName = "Cooper",
            PetType = PetType.Dog,
            Rating = 4,
            Comment = "Excellent food and the pet menu is so creative! Cooper loved the grilled chicken bowl. The patio gets a bit chilly in winter though.",
            DatePosted = DateTime.Now.AddDays(-7),
            Photos = new List<string> { "images/pets/dog5.jpg" },
            HelpfulCount = 19
        },
        new Review
        {
            Id = 7,
            VenueId = 5,
            UserId = 7,
            UserName = "Amanda S.",
            UserAvatar = "images/pets/bunny.jpg",
            PetName = "Cinnamon",
            PetType = PetType.SmallPet,
            Rating = 5,
            Comment = "So happy to find a store that has supplies for bunnies too! The staff was super knowledgeable. Cinnamon approved! 🐰",
            DatePosted = DateTime.Now.AddDays(-2),
            Photos = new List<string> { "images/pets/bunny.jpg" },
            HelpfulCount = 22
        },
        new Review
        {
            Id = 8,
            VenueId = 6,
            UserId = 8,
            UserName = "Chris P.",
            UserAvatar = "images/pets/dog6.png",
            PetName = "Bailey",
            PetType = PetType.Dog,
            Rating = 5,
            Comment = "Best daycare ever! I love being able to watch Bailey play on the webcam during work. She comes home tired and happy every time! 🌟",
            DatePosted = DateTime.Now.AddDays(-1),
            Photos = new List<string> { "images/pets/dog6.png" },
            HelpfulCount = 37
        }
    };
}
