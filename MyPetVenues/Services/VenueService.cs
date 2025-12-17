using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IVenueService
{
    Task<IEnumerable<Venue>> GetAllVenuesAsync();
    Task<IEnumerable<Venue>> GetFeaturedVenuesAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<IEnumerable<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType, List<Amenity>? amenities);
    Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(VenueCategory category);
}

public class VenueService : IVenueService
{
    private readonly List<Venue> _venues;

    public VenueService()
    {
        _venues = GenerateMockVenues();
    }

    public Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        return Task.FromResult<IEnumerable<Venue>>(_venues);
    }

    public Task<IEnumerable<Venue>> GetFeaturedVenuesAsync()
    {
        return Task.FromResult<IEnumerable<Venue>>(_venues.Where(v => v.IsFeatured).Take(6));
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        return Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));
    }

    public Task<IEnumerable<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType, List<Amenity>? amenities)
    {
        var query = _venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(v => 
                v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (category.HasValue)
        {
            query = query.Where(v => v.Category == category.Value);
        }

        if (petType.HasValue)
        {
            query = query.Where(v => v.AllowedPets.Contains(petType.Value) || v.AllowedPets.Contains(PetType.All));
        }

        if (amenities is { Count: > 0 })
        {
            query = query.Where(v => amenities.All(a => v.Amenities.Contains(a)));
        }

        return Task.FromResult(query);
    }

    public Task<IEnumerable<Venue>> GetVenuesByCategoryAsync(VenueCategory category)
    {
        return Task.FromResult<IEnumerable<Venue>>(_venues.Where(v => v.Category == category));
    }

    private static List<Venue> GenerateMockVenues()
    {
        return
        [
            new Venue
            {
                Id = 1,
                Name = "Pawsome Park",
                Description = "A beautiful off-leash dog park with agility equipment, shaded areas, and a separate section for small dogs. Perfect for your furry friend to run free and make new friends! 🐕",
                Address = "123 Bark Street",
                City = "San Francisco",
                ImageUrl = "images/venues/park1.jpg",
                Category = VenueCategory.Park,
                Amenities = [Amenity.OffLeashArea, Amenity.FencedArea, Amenity.WaterBowls, Amenity.WasteBags, Amenity.AgilityEquipment, Amenity.ShadedAreas],
                AllowedPets = [PetType.Dogs],
                Phone = "(555) 123-4567",
                Website = "https://pawsomepark.example.com",
                Hours = "6:00 AM - 10:00 PM Daily",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(1, 4.8, 24)
            },
            new Venue
            {
                Id = 2,
                Name = "The Barking Bean Café",
                Description = "Cozy café with a pet-friendly patio, special pup cups, and homemade dog treats. Enjoy your latte while your pup enjoys theirs! ☕🐾",
                Address = "456 Woof Avenue",
                City = "San Francisco",
                ImageUrl = "images/venues/cafe1.jpg",
                Category = VenueCategory.Cafe,
                Amenities = [Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.PetTreats, Amenity.PetMenu],
                AllowedPets = [PetType.Dogs, PetType.Cats, PetType.SmallAnimals],
                Phone = "(555) 234-5678",
                Website = "https://barkingbean.example.com",
                Hours = "7:00 AM - 8:00 PM Daily",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(2, 4.6, 18)
            },
            new Venue
            {
                Id = 3,
                Name = "Mooch's Pet Hotel & Spa",
                Description = "Luxury pet hotel offering overnight stays, grooming services, and spa treatments. Your pet deserves a vacation too! 🏨✨",
                Address = "789 Purr Lane",
                City = "Oakland",
                ImageUrl = "images/venues/moochs1.jpg",
                Category = VenueCategory.Hotel,
                Amenities = [Amenity.IndoorPetFriendly, Amenity.PetWashStation, Amenity.PetTreats, Amenity.WaterBowls],
                AllowedPets = [PetType.All],
                Phone = "(555) 345-6789",
                Website = "https://moochshotel.example.com",
                Hours = "24/7",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(3, 4.9, 32)
            },
            new Venue
            {
                Id = 4,
                Name = "Happy Tails Pet Store",
                Description = "Your one-stop shop for all pet needs! We welcome pets to shop with their owners and offer free treats at the door. 🛒🐾",
                Address = "321 Tail Wagging Way",
                City = "San Francisco",
                ImageUrl = "images/venues/store1.jpg",
                Category = VenueCategory.Store,
                Amenities = [Amenity.IndoorPetFriendly, Amenity.PetTreats, Amenity.WaterBowls, Amenity.ParkingAvailable],
                AllowedPets = [PetType.All],
                Phone = "(555) 456-7890",
                Website = "https://happytails.example.com",
                Hours = "9:00 AM - 9:00 PM Daily",
                IsFeatured = false,
                Reviews = GenerateReviewsForVenue(4, 4.5, 15)
            },
            new Venue
            {
                Id = 5,
                Name = "Sunset Beach Dog Beach",
                Description = "Miles of sandy beach where dogs can run free, splash in the waves, and dig to their heart's content! A true paradise for water-loving pups. 🏖️🌊",
                Address = "Ocean Boulevard",
                City = "Santa Cruz",
                ImageUrl = "images/venues/home1.jpg",
                Category = VenueCategory.Beach,
                Amenities = [Amenity.OffLeashArea, Amenity.WasteBags, Amenity.ParkingAvailable, Amenity.WaterBowls],
                AllowedPets = [PetType.Dogs],
                Phone = "(555) 567-8901",
                Hours = "Sunrise to Sunset",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(5, 4.7, 28)
            },
            new Venue
            {
                Id = 6,
                Name = "Paws & Plates Restaurant",
                Description = "Upscale dining with a dedicated pet menu crafted by our chef. Because date night should include your furry companion! 🍽️🐕",
                Address = "555 Gourmet Drive",
                City = "San Francisco",
                ImageUrl = "images/venues/hotel1.jpg",
                Category = VenueCategory.Restaurant,
                Amenities = [Amenity.OutdoorSeating, Amenity.PetMenu, Amenity.WaterBowls, Amenity.PetTreats, Amenity.WheelchairAccessible],
                AllowedPets = [PetType.Dogs, PetType.Cats],
                Phone = "(555) 678-9012",
                Website = "https://pawsandplates.example.com",
                Hours = "11:00 AM - 10:00 PM Daily",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(6, 4.4, 21)
            },
            new Venue
            {
                Id = 7,
                Name = "Furry Friends Daycare",
                Description = "A safe, fun environment for your pets while you're at work. Supervised play, nap time, and lots of love included! 🏠💕",
                Address = "888 Care Circle",
                City = "Berkeley",
                ImageUrl = "images/venues/cafe1.jpg",
                Category = VenueCategory.DayCare,
                Amenities = [Amenity.IndoorPetFriendly, Amenity.FencedArea, Amenity.WaterBowls, Amenity.PetTreats, Amenity.WasteBags],
                AllowedPets = [PetType.Dogs, PetType.Cats],
                Phone = "(555) 789-0123",
                Website = "https://furryfriendsdaycare.example.com",
                Hours = "6:30 AM - 7:00 PM Mon-Fri",
                IsFeatured = false,
                Reviews = GenerateReviewsForVenue(7, 4.8, 19)
            },
            new Venue
            {
                Id = 8,
                Name = "Whiskers & Wags Grooming",
                Description = "Professional grooming services for all breeds. From bath & brush to full makeovers, we'll have your pet looking fabulous! ✂️🛁",
                Address = "777 Style Street",
                City = "San Francisco",
                ImageUrl = "images/venues/store1.jpg",
                Category = VenueCategory.Grooming,
                Amenities = [Amenity.PetWashStation, Amenity.IndoorPetFriendly, Amenity.ParkingAvailable, Amenity.WheelchairAccessible],
                AllowedPets = [PetType.Dogs, PetType.Cats],
                Phone = "(555) 890-1234",
                Website = "https://whiskersandwags.example.com",
                Hours = "8:00 AM - 6:00 PM Tue-Sat",
                IsFeatured = true,
                Reviews = GenerateReviewsForVenue(8, 4.6, 27)
            }
        ];
    }

    private static List<Review> GenerateReviewsForVenue(int venueId, double avgRating, int count)
    {
        var reviewers = new[] 
        { 
            ("Sarah M.", "images/pets/dog1.png", "Max", PetType.Dogs),
            ("Mike T.", "images/pets/cat1.jpg", "Whiskers", PetType.Cats),
            ("Emily R.", "images/pets/dog3.jpg", "Bella", PetType.Dogs),
            ("James L.", "images/pets/hedgehog.jpg", "Spike", PetType.SmallAnimals),
            ("Lisa K.", "images/pets/dog4.png", "Charlie", PetType.Dogs),
            ("David W.", "images/pets/cat2.jpg", "Luna", PetType.Cats),
            ("Anna P.", "images/pets/bunny.jpg", "Fluffy", PetType.SmallAnimals),
            ("Chris B.", "images/pets/dog5.jpg", "Rocky", PetType.Dogs)
        };

        var comments = new[]
        {
            "Absolutely loved this place! My pet was so happy here. Will definitely be coming back! 🌟",
            "Great atmosphere and super pet-friendly staff. They even gave my fur baby a treat! 🐾",
            "Perfect spot for pet owners. Clean, welcoming, and the amenities are top-notch! ✨",
            "My dog made so many friends here! The staff was incredibly helpful and attentive. 💕",
            "Best pet-friendly venue in the area. Highly recommend for all pet parents! 🏆",
            "Such a wonderful experience. My cat usually doesn't like new places but felt right at home here. 😺",
            "The staff went above and beyond to make us feel welcome. Five stars! ⭐⭐⭐⭐⭐",
            "Amazing place! Great facilities and very clean. My pet can't wait to come back! 🎉"
        };

        var reviews = new List<Review>();
        var random = new Random(venueId * 100);
        
        for (int i = 0; i < Math.Min(count, 8); i++)
        {
            var reviewer = reviewers[i % reviewers.Length];
            var rating = Math.Max(3, Math.Min(5, (int)Math.Round(avgRating + (random.NextDouble() - 0.5))));
            
            reviews.Add(new Review
            {
                Id = venueId * 100 + i,
                VenueId = venueId,
                UserName = reviewer.Item1,
                UserAvatar = reviewer.Item2,
                Rating = rating,
                Comment = comments[i % comments.Length],
                DatePosted = DateTime.Now.AddDays(-random.Next(1, 90)),
                StaffFriendlinessRating = Math.Max(3, Math.Min(5, rating + random.Next(-1, 2))),
                CleanlinessRating = Math.Max(3, Math.Min(5, rating + random.Next(-1, 2))),
                PetAmenitiesRating = Math.Max(3, Math.Min(5, rating + random.Next(-1, 2))),
                HelpfulCount = random.Next(0, 25),
                PetName = reviewer.Item3,
                PetType = reviewer.Item4
            });
        }

        return reviews.OrderByDescending(r => r.DatePosted).ToList();
    }
}
