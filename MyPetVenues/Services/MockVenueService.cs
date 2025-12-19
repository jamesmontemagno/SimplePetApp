using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockVenueService
{
    private readonly List<PetVenue> _venues =
    [
        new()
        {
            Id = 1,
            Name = "Paws & Perks Cafe",
            Category = "Cafe",
            City = "Seattle, WA",
            Neighborhood = "Capitol Hill",
            Address = "1510 Pine St",
            Description = "Bright cafe with pet-friendly patio, free water bowls, and plenty of shade for pups after a long walk.",
            PetTypes = ["Dog", "Cat"],
            Amenities = ["Water bowls", "Shaded seating", "Treats at counter", "Leash required"],
            ImageUrl = "images/venues/cafe1.jpg",
            Website = "https://pawandperks.example",
            Contact = "hello@pawsperks.example",
            Hours = "Daily · 7a – 7p",
            ReservationsRequired = false,
            AverageRating = 4.7,
            ReviewCount = 18
        },
        new()
        {
            Id = 2,
            Name = "Maple Leaf Off-Leash Park",
            Category = "Park",
            City = "Seattle, WA",
            Neighborhood = "Maple Leaf",
            Address = "1021 NE 82nd St",
            Description = "Fully fenced off-leash park with double-gate entry, separate small-dog area, and agility features.",
            PetTypes = ["Dog"],
            Amenities = ["Off-leash area", "Shaded seating", "Waste bags", "Water bowls", "Agility zone"],
            ImageUrl = "images/venues/park1.jpg",
            Website = "https://seattleparks.example",
            Contact = "parks@city.example",
            Hours = "Daily · 6a – 10p",
            ReservationsRequired = false,
            AverageRating = 4.8,
            ReviewCount = 24
        },
        new()
        {
            Id = 3,
            Name = "Seaside Stay Hotel",
            Category = "Hotel",
            City = "Portland, OR",
            Neighborhood = "Pearl District",
            Address = "800 NW 12th Ave",
            Description = "Boutique hotel with pet welcome kit, late checkout for pet parents, and nearby walking trails.",
            PetTypes = ["Dog", "Cat", "Small pets"],
            Amenities = ["Pet fee waived", "Welcome kit", "Late checkout", "Nearby trails"],
            ImageUrl = "images/venues/hotel1.jpg",
            Website = "https://seasidestay.example",
            Contact = "stay@seaside.example",
            Hours = "Check-in 3p · Check-out 12p",
            ReservationsRequired = true,
            AverageRating = 4.6,
            ReviewCount = 12
        },
        new()
        {
            Id = 4,
            Name = "Mooch's Market",
            Category = "Pet Store",
            City = "Austin, TX",
            Neighborhood = "South Congress",
            Address = "2001 S Congress Ave",
            Description = "Pet boutique with in-store events, fresh treat bar, and grooming-friendly waiting nooks.",
            PetTypes = ["Dog", "Cat", "Small pets"],
            Amenities = ["Treat samples", "Events", "Indoor seating", "Air conditioning"],
            ImageUrl = "images/venues/moochs1.jpg",
            Website = "https://moochs.example",
            Contact = "team@moochs.example",
            Hours = "Daily · 10a – 8p",
            ReservationsRequired = false,
            AverageRating = 4.5,
            ReviewCount = 15
        },
        new()
        {
            Id = 5,
            Name = "Greenway Trailhead",
            Category = "Trail",
            City = "Boulder, CO",
            Neighborhood = "Chautauqua",
            Address = "102 Trailhead Rd",
            Description = "Scenic trail system with on-leash hikes, shaded creek stops, and clearly marked dog waste stations.",
            PetTypes = ["Dog"],
            Amenities = ["On-leash trail", "Water access", "Shaded seating", "Waste bags"],
            ImageUrl = "images/venues/home1.jpg",
            Website = "https://greenway.example",
            Contact = "info@greenway.example",
            Hours = "Daily · Sunrise – Sunset",
            ReservationsRequired = false,
            AverageRating = 4.4,
            ReviewCount = 9
        }
    ];

    private readonly Dictionary<int, List<VenueReview>> _reviews = new()
    {
        {
            1,
            new List<VenueReview>
            {
                new() { Author = "Kelly", PetType = "Dog", Rating = 5, Comment = "Plenty of shade and staff brought water without asking.", CreatedAt = DateTime.UtcNow.AddDays(-4) },
                new() { Author = "Marco", PetType = "Cat", Rating = 4, Comment = "Patio is great, but bring a mat for your cat.", CreatedAt = DateTime.UtcNow.AddDays(-10) },
            }
        },
        {
            2,
            new List<VenueReview>
            {
                new() { Author = "Priya", PetType = "Dog", Rating = 5, Comment = "Safe double gates and lots of space to run!", CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new() { Author = "Janet", PetType = "Dog", Rating = 4, Comment = "Weekend mornings can be busy; bring extra water.", CreatedAt = DateTime.UtcNow.AddDays(-12) },
            }
        },
        {
            3,
            new List<VenueReview>
            {
                new() { Author = "Luis", PetType = "Dog", Rating = 5, Comment = "Welcome kit was thoughtful; late checkout was honored.", CreatedAt = DateTime.UtcNow.AddDays(-6) },
                new() { Author = "Amber", PetType = "Cat", Rating = 4, Comment = "Room was quiet; would love clearer litter disposal guidance.", CreatedAt = DateTime.UtcNow.AddDays(-14) },
            }
        },
        {
            4,
            new List<VenueReview>
            {
                new() { Author = "Sam", PetType = "Dog", Rating = 5, Comment = "Event calendar is great and the treat bar is a hit.", CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new() { Author = "Jess", PetType = "Small pets", Rating = 4, Comment = "Staff is knowledgeable about small pets too.", CreatedAt = DateTime.UtcNow.AddDays(-8) },
            }
        },
        {
            5,
            new List<VenueReview>
            {
                new() { Author = "Lin", PetType = "Dog", Rating = 4, Comment = "Gorgeous views, on-leash only which keeps it orderly.", CreatedAt = DateTime.UtcNow.AddDays(-3) },
            }
        }
    };

    public IReadOnlyList<string> PetTypes => new[] { "Dog", "Cat", "Small pets" };
    public IReadOnlyList<string> Amenities => new[]
    {
        "Water bowls", "Shaded seating", "Treats at counter", "Off-leash area", "Waste bags", "Agility zone",
        "Pet fee waived", "Welcome kit", "Late checkout", "Nearby trails", "Treat samples", "Events",
        "Indoor seating", "Air conditioning", "On-leash trail", "Water access"
    };

    public Task<List<PetVenue>> GetVenuesAsync() =>
        Task.FromResult(_venues
            .OrderByDescending(v => v.AverageRating)
            .ThenBy(v => v.Name)
            .ToList());

    public Task<PetVenue?> GetVenueAsync(int id) =>
        Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));

    public Task<List<VenueReview>> GetReviewsAsync(int venueId)
    {
        _reviews.TryGetValue(venueId, out var reviews);
        return Task.FromResult(reviews?.OrderByDescending(r => r.CreatedAt).ToList() ?? []);
    }

    public Task<PetVenue> AddVenueAsync(PetVenue venue)
    {
        var nextId = _venues.Max(v => v.Id) + 1;
        venue.Id = nextId;
        venue.ReviewCount = 0;
        venue.AverageRating = 0;
        venue.ImageUrl = string.IsNullOrWhiteSpace(venue.ImageUrl) ? "images/venues/store1.jpg" : venue.ImageUrl;

        _venues.Add(venue);
        _reviews[nextId] = [];
        return Task.FromResult(venue);
    }

    public Task AddReviewAsync(int venueId, VenueReview review)
    {
        if (!_reviews.TryGetValue(venueId, out var reviews))
        {
            reviews = [];
            _reviews[venueId] = reviews;
        }

        reviews.Add(review);

        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue is not null)
        {
            var totalScore = (venue.AverageRating * venue.ReviewCount) + review.Rating;
            venue.ReviewCount += 1;
            venue.AverageRating = Math.Round(totalScore / venue.ReviewCount, 1);
        }

        return Task.CompletedTask;
    }
}
