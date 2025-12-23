using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockDataService
{
    private readonly List<Amenity> _amenities;
    private readonly List<Venue> _venues;
    private readonly List<Pet> _pets;
    private readonly List<User> _users;

    public MockDataService()
    {
        _amenities = InitializeAmenities();
        _venues = InitializeVenues();
        _pets = InitializePets();
        _users = InitializeUsers();
    }

    #region Amenities

    private static List<Amenity> InitializeAmenities() =>
    [
        new() { Id = 1, Name = "Water Bowls", Icon = AmenityIcons.WaterBowl, Description = "Fresh water available for pets" },
        new() { Id = 2, Name = "Treats Available", Icon = AmenityIcons.Treats, Description = "Complimentary treats for well-behaved pets" },
        new() { Id = 3, Name = "Outdoor Seating", Icon = AmenityIcons.OutdoorSeating, Description = "Pet-friendly outdoor patio area" },
        new() { Id = 4, Name = "Pet Beds", Icon = AmenityIcons.PetBeds, Description = "Comfortable resting spots for pets" },
        new() { Id = 5, Name = "Washing Station", Icon = AmenityIcons.WashingStation, Description = "Self-service pet washing facility" },
        new() { Id = 6, Name = "Pet Menu", Icon = AmenityIcons.PetMenu, Description = "Special menu items for pets" },
        new() { Id = 7, Name = "Parking", Icon = AmenityIcons.Parking, Description = "Convenient parking available" },
        new() { Id = 8, Name = "Vet On-Site", Icon = AmenityIcons.VetOnSite, Description = "Veterinary services available" },
        new() { Id = 9, Name = "Off-Leash Area", Icon = AmenityIcons.OffLeashArea, Description = "Designated off-leash play area" },
        new() { Id = 10, Name = "Air Conditioned", Icon = AmenityIcons.AirConditioned, Description = "Climate controlled indoor space" },
        new() { Id = 11, Name = "Free WiFi", Icon = AmenityIcons.WiFi, Description = "Complimentary WiFi for guests" },
        new() { Id = 12, Name = "Play Area", Icon = AmenityIcons.PlayArea, Description = "Dedicated play equipment for pets" },
        new() { Id = 13, Name = "Fenced Area", Icon = AmenityIcons.Fenced, Description = "Secure fenced enclosure" },
        new() { Id = 14, Name = "Pet-Friendly Staff", Icon = AmenityIcons.PetFriendlyStaff, Description = "Staff trained in pet care" },
        new() { Id = 15, Name = "Waste Stations", Icon = AmenityIcons.WasteStations, Description = "Pet waste bags and disposal" },
        new() { Id = 16, Name = "Photo Spot", Icon = AmenityIcons.PhotoSpot, Description = "Instagram-worthy photo locations" }
    ];

    public List<Amenity> GetAllAmenities() => _amenities;
    
    public Amenity? GetAmenityById(int id) => _amenities.FirstOrDefault(a => a.Id == id);

    #endregion

    #region Venues

    private List<Venue> InitializeVenues()
    {
        var amenities = _amenities;
        
        return
        [
            new()
            {
                Id = 1,
                Name = "Pawsome Park",
                Description = "A beautiful 20-acre park with dedicated dog areas, walking trails, and shaded rest spots. Perfect for dogs of all sizes with separate areas for small and large breeds. Features agility equipment and a splash pad for hot summer days!",
                Address = "123 Bark Avenue",
                City = "Seattle",
                State = "WA",
                ZipCode = "98101",
                Phone = "(206) 555-PAWS",
                Website = "https://pawsomepark.example.com",
                Category = VenueCategory.Park,
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat],
                Amenities = [amenities[0], amenities[8], amenities[12], amenities[14], amenities[15]],
                Hours = "6:00 AM - 10:00 PM Daily",
                IsFeatured = true,
                DateAdded = DateTime.Now.AddMonths(-6),
                Reviews = GenerateParkReviews()
            },
            new()
            {
                Id = 2,
                Name = "The Barking Bean Café",
                Description = "A cozy coffee shop where your furry friends are always welcome! We serve artisan coffee, fresh pastries, and even have a special 'Puppuccino' for your pups. Outdoor patio seating with water bowls at every table.",
                Address = "456 Furry Lane",
                City = "Portland",
                State = "OR",
                ZipCode = "97201",
                Phone = "(503) 555-BEAN",
                Website = "https://barkingbean.example.com",
                Category = VenueCategory.Cafe,
                ImageUrl = "images/venues/cafe1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat, PetType.SmallAnimal],
                Amenities = [amenities[0], amenities[1], amenities[2], amenities[5], amenities[10], amenities[13]],
                Hours = "7:00 AM - 8:00 PM Mon-Sat, 8:00 AM - 6:00 PM Sun",
                IsFeatured = true,
                DateAdded = DateTime.Now.AddMonths(-3),
                Reviews = GenerateCafeReviews()
            },
            new()
            {
                Id = 3,
                Name = "Mooch's Pet Emporium",
                Description = "Your one-stop shop for all things pet! From premium food and toys to grooming supplies and stylish accessories. Our knowledgeable staff are pet parents themselves and love helping you find the perfect products.",
                Address = "789 Whisker Way",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94102",
                Phone = "(415) 555-PETS",
                Website = "https://moochspet.example.com",
                Category = VenueCategory.Store,
                ImageUrl = "images/venues/moochs1.jpg",
                AcceptedPetTypes = [PetType.All],
                Amenities = [amenities[0], amenities[1], amenities[6], amenities[9], amenities[13]],
                Hours = "9:00 AM - 9:00 PM Daily",
                IsFeatured = true,
                DateAdded = DateTime.Now.AddMonths(-8),
                Reviews = GenerateStoreReviews()
            },
            new()
            {
                Id = 4,
                Name = "The Paw Palace Hotel",
                Description = "Luxury accommodations for you and your four-legged family member! Our pet-friendly suites feature plush pet beds, room service with a pet menu, and a rooftop dog park. Concierge pet-sitting available.",
                Address = "101 Luxury Drive",
                City = "Las Vegas",
                State = "NV",
                ZipCode = "89109",
                Phone = "(702) 555-LUXE",
                Website = "https://pawpalace.example.com",
                Category = VenueCategory.Hotel,
                ImageUrl = "images/venues/hotel1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat],
                Amenities = [amenities[0], amenities[1], amenities[3], amenities[4], amenities[5], amenities[6], amenities[9], amenities[10], amenities[13]],
                Hours = "24/7 Front Desk",
                IsFeatured = true,
                DateAdded = DateTime.Now.AddMonths(-4),
                Reviews = GenerateHotelReviews()
            },
            new()
            {
                Id = 5,
                Name = "Cozy Paws Home & Garden",
                Description = "A charming home and garden center that welcomes all pets! Browse our selection of plants, home décor, and outdoor furniture with your furry companion by your side. Dog park on premises!",
                Address = "222 Garden Grove",
                City = "Austin",
                State = "TX",
                ZipCode = "78701",
                Phone = "(512) 555-HOME",
                Website = "https://cozypaws.example.com",
                Category = VenueCategory.Store,
                ImageUrl = "images/venues/home1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat, PetType.Bird],
                Amenities = [amenities[0], amenities[1], amenities[2], amenities[6], amenities[14]],
                Hours = "8:00 AM - 7:00 PM Daily",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-2),
                Reviews = GenerateHomeStoreReviews()
            },
            new()
            {
                Id = 6,
                Name = "Whisker's Wellness Vet Clinic",
                Description = "Full-service veterinary clinic offering preventive care, dental services, surgery, and emergency care. Our Fear Free certified team makes visits stress-free for pets and owners alike.",
                Address = "333 Health Street",
                City = "Denver",
                State = "CO",
                ZipCode = "80202",
                Phone = "(303) 555-VET1",
                Website = "https://whiskerwellness.example.com",
                Category = VenueCategory.Veterinary,
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = [PetType.All],
                Amenities = [amenities[0], amenities[1], amenities[6], amenities[7], amenities[9], amenities[13]],
                Hours = "8:00 AM - 6:00 PM Mon-Fri, 9:00 AM - 4:00 PM Sat",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-12),
                Reviews = GenerateVetReviews()
            },
            new()
            {
                Id = 7,
                Name = "Tail Trails Adventure Park",
                Description = "Miles of scenic hiking trails perfect for you and your adventurous pup! Varying difficulty levels from easy strolls to challenging climbs. Water stations throughout and stunning viewpoints.",
                Address = "444 Mountain Road",
                City = "Boulder",
                State = "CO",
                ZipCode = "80302",
                Phone = "(303) 555-HIKE",
                Website = "https://tailtrails.example.com",
                Category = VenueCategory.Trail,
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = [PetType.Dog],
                Amenities = [amenities[0], amenities[8], amenities[14], amenities[15]],
                Hours = "Sunrise to Sunset",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-5),
                Reviews = GenerateTrailReviews()
            },
            new()
            {
                Id = 8,
                Name = "Fluffy's Day Spa & Grooming",
                Description = "Pamper your pet with our luxurious grooming services! From basic baths to full spa treatments, nail trims, and breed-specific styling. We use only premium, pet-safe products.",
                Address = "555 Beauty Boulevard",
                City = "Miami",
                State = "FL",
                ZipCode = "33101",
                Phone = "(305) 555-GROOM",
                Website = "https://fluffysspa.example.com",
                Category = VenueCategory.Grooming,
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat, PetType.Rabbit],
                Amenities = [amenities[0], amenities[1], amenities[4], amenities[9], amenities[13], amenities[15]],
                Hours = "9:00 AM - 7:00 PM Tue-Sat",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-7),
                Reviews = GenerateGroomingReviews()
            },
            new()
            {
                Id = 9,
                Name = "Sandy Paws Beach",
                Description = "The perfect dog beach! Soft sand, gentle waves, and tons of space for your pup to run and play. Fenced off-leash area with fresh water stations. Sunset views are incredible!",
                Address = "666 Ocean Drive",
                City = "San Diego",
                State = "CA",
                ZipCode = "92101",
                Phone = "(619) 555-SAND",
                Website = "https://sandypaws.example.com",
                Category = VenueCategory.Beach,
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = [PetType.Dog],
                Amenities = [amenities[0], amenities[4], amenities[8], amenities[12], amenities[14], amenities[15]],
                Hours = "6:00 AM - 8:00 PM Daily",
                IsFeatured = true,
                DateAdded = DateTime.Now.AddMonths(-9),
                Reviews = GenerateBeachReviews()
            },
            new()
            {
                Id = 10,
                Name = "Happy Tails Daycare",
                Description = "Premium dog daycare with indoor and outdoor play areas, climate control, and 24/7 webcam access. Our trained staff ensure your pup has the best day ever with structured play and nap times.",
                Address = "777 Playful Place",
                City = "Chicago",
                State = "IL",
                ZipCode = "60601",
                Phone = "(312) 555-PLAY",
                Website = "https://happytailsdc.example.com",
                Category = VenueCategory.DayCare,
                ImageUrl = "images/venues/home1.jpg",
                AcceptedPetTypes = [PetType.Dog],
                Amenities = [amenities[0], amenities[1], amenities[3], amenities[8], amenities[9], amenities[11], amenities[12], amenities[13]],
                Hours = "6:30 AM - 7:30 PM Mon-Fri, 8:00 AM - 5:00 PM Sat",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-10),
                Reviews = GenerateDaycareReviews()
            },
            new()
            {
                Id = 11,
                Name = "Purrfect Bites Restaurant",
                Description = "An upscale dining experience that welcomes well-behaved pets on our gorgeous garden patio. Our chef has created a special pet menu featuring gourmet treats made with locally-sourced ingredients.",
                Address = "888 Gourmet Row",
                City = "Nashville",
                State = "TN",
                ZipCode = "37201",
                Phone = "(615) 555-DINE",
                Website = "https://purrfectbites.example.com",
                Category = VenueCategory.Restaurant,
                ImageUrl = "images/venues/cafe1.jpg",
                AcceptedPetTypes = [PetType.Dog, PetType.Cat],
                Amenities = [amenities[0], amenities[1], amenities[2], amenities[3], amenities[5], amenities[6], amenities[13]],
                Hours = "11:00 AM - 10:00 PM Daily",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddMonths(-1),
                Reviews = GenerateRestaurantReviews()
            },
            new()
            {
                Id = 12,
                Name = "Exotic Pets Paradise",
                Description = "The premier destination for exotic pet owners! Our store and clinic cater specifically to birds, reptiles, small mammals, and other exotic companions. Specialized care and products you won't find anywhere else.",
                Address = "999 Unique Lane",
                City = "Phoenix",
                State = "AZ",
                ZipCode = "85001",
                Phone = "(602) 555-RARE",
                Website = "https://exoticpets.example.com",
                Category = VenueCategory.Store,
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = [PetType.Bird, PetType.Reptile, PetType.SmallAnimal, PetType.Exotic, PetType.Fish],
                Amenities = [amenities[0], amenities[6], amenities[7], amenities[9], amenities[13]],
                Hours = "10:00 AM - 8:00 PM Mon-Sat, 11:00 AM - 6:00 PM Sun",
                IsFeatured = false,
                DateAdded = DateTime.Now.AddDays(-15),
                Reviews = GenerateExoticStoreReviews()
            }
        ];
    }

    private static List<Review> GenerateParkReviews() =>
    [
        new()
        {
            Id = 1, VenueId = 1, UserId = 1, UserName = "Sarah Mitchell", UserImageUrl = "images/pets/dog1.png",
            Rating = 5, Comment = "Absolutely love this park! My golden retriever Max has made so many friends here. The separate areas for small and large dogs is perfect.",
            Date = DateTime.Now.AddDays(-5), HelpfulCount = 24, PetName = "Max", PetType = PetType.Dog
        },
        new()
        {
            Id = 2, VenueId = 1, UserId = 2, UserName = "Mike Johnson", UserImageUrl = "images/pets/dog3.jpg",
            Rating = 4, Comment = "Great park with lots of space. Wish there were more shaded areas during summer, but overall excellent!",
            Date = DateTime.Now.AddDays(-12), HelpfulCount = 15, PetName = "Buddy", PetType = PetType.Dog
        },
        new()
        {
            Id = 3, VenueId = 1, UserId = 3, UserName = "Emma Wilson", UserImageUrl = "images/pets/cat1.jpg",
            Rating = 5, Comment = "Even brought my cat here in a stroller! The walking trails are beautiful and well-maintained.",
            Date = DateTime.Now.AddDays(-20), HelpfulCount = 8, PetName = "Whiskers", PetType = PetType.Cat
        }
    ];

    private static List<Review> GenerateCafeReviews() =>
    [
        new()
        {
            Id = 4, VenueId = 2, UserId = 4, UserName = "Jessica Brown", UserImageUrl = "images/pets/dog4.png",
            Rating = 5, Comment = "The puppuccino was a hit! My corgi couldn't stop wagging her tail. Great coffee for humans too 😊",
            Date = DateTime.Now.AddDays(-3), HelpfulCount = 32, PetName = "Luna", PetType = PetType.Dog
        },
        new()
        {
            Id = 5, VenueId = 2, UserId = 5, UserName = "David Lee", UserImageUrl = "images/pets/dog5.jpg",
            Rating = 4, Comment = "Cozy atmosphere and pet-friendly staff. Gets a bit crowded on weekends but worth the wait.",
            Date = DateTime.Now.AddDays(-8), HelpfulCount = 18, PetName = "Rocky", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateStoreReviews() =>
    [
        new()
        {
            Id = 6, VenueId = 3, UserId = 1, UserName = "Sarah Mitchell", UserImageUrl = "images/pets/dog1.png",
            Rating = 5, Comment = "Best pet store in the city! Amazing selection and the staff really knows their stuff. Max always gets excited when we pull up.",
            Date = DateTime.Now.AddDays(-7), HelpfulCount = 45, PetName = "Max", PetType = PetType.Dog
        },
        new()
        {
            Id = 7, VenueId = 3, UserId = 6, UserName = "Lisa Chen", UserImageUrl = "images/pets/cat2.jpg",
            Rating = 5, Comment = "Finally found a store that carries the specialty food my picky cat loves! The treats they give at checkout are adorable.",
            Date = DateTime.Now.AddDays(-14), HelpfulCount = 28, PetName = "Mittens", PetType = PetType.Cat
        },
        new()
        {
            Id = 8, VenueId = 3, UserId = 7, UserName = "Tom Garcia", UserImageUrl = "images/pets/hedgehog.jpg",
            Rating = 4, Comment = "They even have supplies for my hedgehog! Hard to find exotic pet supplies elsewhere.",
            Date = DateTime.Now.AddDays(-30), HelpfulCount = 12, PetName = "Spike", PetType = PetType.Exotic
        }
    ];

    private static List<Review> GenerateHotelReviews() =>
    [
        new()
        {
            Id = 9, VenueId = 4, UserId = 4, UserName = "Jessica Brown", UserImageUrl = "images/pets/dog4.png",
            Rating = 5, Comment = "Truly luxury for pet parents! The rooftop dog park was amazing and room service had a doggy menu. Luna slept like a queen.",
            Date = DateTime.Now.AddDays(-10), HelpfulCount = 56, PetName = "Luna", PetType = PetType.Dog
        },
        new()
        {
            Id = 10, VenueId = 4, UserId = 8, UserName = "Robert Kim", UserImageUrl = "images/pets/cat3.jpg",
            Rating = 5, Comment = "Worth every penny. They even had a cat tree in the room when we checked in! Excellent attention to detail.",
            Date = DateTime.Now.AddDays(-25), HelpfulCount = 41, PetName = "Shadow", PetType = PetType.Cat
        }
    ];

    private static List<Review> GenerateHomeStoreReviews() =>
    [
        new()
        {
            Id = 11, VenueId = 5, UserId = 2, UserName = "Mike Johnson", UserImageUrl = "images/pets/dog3.jpg",
            Rating = 4, Comment = "Love that I can bring Buddy while shopping for plants. The attached dog park is a nice bonus!",
            Date = DateTime.Now.AddDays(-6), HelpfulCount = 19, PetName = "Buddy", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateVetReviews() =>
    [
        new()
        {
            Id = 12, VenueId = 6, UserId = 6, UserName = "Lisa Chen", UserImageUrl = "images/pets/cat2.jpg",
            Rating = 5, Comment = "Dr. Martinez is amazing! My anxious cat Mittens actually purred during her exam. Fear Free certified and it shows!",
            Date = DateTime.Now.AddDays(-15), HelpfulCount = 38, PetName = "Mittens", PetType = PetType.Cat
        },
        new()
        {
            Id = 13, VenueId = 6, UserId = 1, UserName = "Sarah Mitchell", UserImageUrl = "images/pets/dog1.png",
            Rating = 5, Comment = "Emergency services saved Max's life. Can't thank this team enough. Forever grateful!",
            Date = DateTime.Now.AddDays(-45), HelpfulCount = 72, PetName = "Max", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateTrailReviews() =>
    [
        new()
        {
            Id = 14, VenueId = 7, UserId = 5, UserName = "David Lee", UserImageUrl = "images/pets/dog5.jpg",
            Rating = 5, Comment = "Perfect for active dogs! Rocky and I did the summit trail - challenging but the views are incredible. Water stations are well-placed.",
            Date = DateTime.Now.AddDays(-4), HelpfulCount = 29, PetName = "Rocky", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateGroomingReviews() =>
    [
        new()
        {
            Id = 15, VenueId = 8, UserId = 4, UserName = "Jessica Brown", UserImageUrl = "images/pets/dog4.png",
            Rating = 5, Comment = "Luna looks like a show dog every time! The groomers are patient and skilled. Love the blueberry facial treatment!",
            Date = DateTime.Now.AddDays(-11), HelpfulCount = 34, PetName = "Luna", PetType = PetType.Dog
        },
        new()
        {
            Id = 16, VenueId = 8, UserId = 9, UserName = "Amy Taylor", UserImageUrl = "images/pets/bunny.jpg",
            Rating = 4, Comment = "They even groom rabbits! My bunny Cinnamon got a gentle nail trim and brushing. Very specialized care.",
            Date = DateTime.Now.AddDays(-22), HelpfulCount = 16, PetName = "Cinnamon", PetType = PetType.Rabbit
        }
    ];

    private static List<Review> GenerateBeachReviews() =>
    [
        new()
        {
            Id = 17, VenueId = 9, UserId = 2, UserName = "Mike Johnson", UserImageUrl = "images/pets/dog3.jpg",
            Rating = 5, Comment = "Dog paradise! Buddy spent hours splashing in the waves. The sunset is magical and there are plenty of waste stations.",
            Date = DateTime.Now.AddDays(-2), HelpfulCount = 52, PetName = "Buddy", PetType = PetType.Dog
        },
        new()
        {
            Id = 18, VenueId = 9, UserId = 5, UserName = "David Lee", UserImageUrl = "images/pets/dog5.jpg",
            Rating = 5, Comment = "Best dog beach in California! Rocky made so many friends. The fenced area gives peace of mind.",
            Date = DateTime.Now.AddDays(-16), HelpfulCount = 43, PetName = "Rocky", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateDaycareReviews() =>
    [
        new()
        {
            Id = 19, VenueId = 10, UserId = 1, UserName = "Sarah Mitchell", UserImageUrl = "images/pets/dog1.png",
            Rating = 5, Comment = "Max comes home tired and happy every time! Love the webcam feature - I peek at him playing throughout the day.",
            Date = DateTime.Now.AddDays(-9), HelpfulCount = 38, PetName = "Max", PetType = PetType.Dog
        },
        new()
        {
            Id = 20, VenueId = 10, UserId = 4, UserName = "Jessica Brown", UserImageUrl = "images/pets/dog4.png",
            Rating = 4, Comment = "Luna was nervous at first but the staff were so patient. Now she gets excited every morning! Slightly pricey but worth it.",
            Date = DateTime.Now.AddDays(-35), HelpfulCount = 25, PetName = "Luna", PetType = PetType.Dog
        }
    ];

    private static List<Review> GenerateRestaurantReviews() =>
    [
        new()
        {
            Id = 21, VenueId = 11, UserId = 8, UserName = "Robert Kim", UserImageUrl = "images/pets/cat3.jpg",
            Rating = 5, Comment = "The garden patio is gorgeous! Shadow sat in his stroller like a king while we enjoyed an amazing meal. Pet menu is gourmet!",
            Date = DateTime.Now.AddDays(-1), HelpfulCount = 28, PetName = "Shadow", PetType = PetType.Cat
        }
    ];

    private static List<Review> GenerateExoticStoreReviews() =>
    [
        new()
        {
            Id = 22, VenueId = 12, UserId = 7, UserName = "Tom Garcia", UserImageUrl = "images/pets/hedgehog.jpg",
            Rating = 5, Comment = "Finally! A store that understands exotic pets. The vet on-site specializes in hedgehogs. Spike got a health check while I shopped.",
            Date = DateTime.Now.AddDays(-3), HelpfulCount = 22, PetName = "Spike", PetType = PetType.Exotic
        }
    ];

    public List<Venue> GetAllVenues() => _venues;

    public List<Venue> GetFeaturedVenues() => _venues.Where(v => v.IsFeatured).ToList();

    public Venue? GetVenueById(int id) => _venues.FirstOrDefault(v => v.Id == id);

    public List<Venue> GetVenuesByCategory(VenueCategory category) => 
        _venues.Where(v => v.Category == category).ToList();

    public List<Venue> GetVenuesByPetType(PetType petType) =>
        _venues.Where(v => v.AcceptedPetTypes.Contains(petType) || v.AcceptedPetTypes.Contains(PetType.All)).ToList();

    public List<Venue> SearchVenues(string query) =>
        _venues.Where(v => 
            v.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            v.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            v.City.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

    public List<Venue> GetRecentVenues(int count = 6) =>
        _venues.OrderByDescending(v => v.DateAdded).Take(count).ToList();

    public List<Venue> GetTopRatedVenues(int count = 6) =>
        _venues.OrderByDescending(v => v.AverageRating).Take(count).ToList();

    public void AddVenue(Venue venue)
    {
        venue.Id = _venues.Max(v => v.Id) + 1;
        venue.DateAdded = DateTime.Now;
        _venues.Add(venue);
    }

    public void AddReview(int venueId, Review review)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue != null)
        {
            review.Id = _venues.SelectMany(v => v.Reviews).Max(r => r.Id) + 1;
            review.VenueId = venueId;
            review.Date = DateTime.Now;
            venue.Reviews.Add(review);
        }
    }

    #endregion

    #region Pets

    private static List<Pet> InitializePets() =>
    [
        new()
        {
            Id = 1, Name = "Max", Type = PetType.Dog, Breed = "Golden Retriever", Age = 4,
            ImageUrl = "images/pets/dog1.png", OwnerId = 1,
            Bio = "Max is a friendly golden who loves making new friends at the park! His favorite activities include fetch, swimming, and stealing socks.",
            FavoriteActivities = ["Fetch", "Swimming", "Park visits", "Car rides"],
            VisitedVenueIds = [1, 3, 6, 10], DateAdded = DateTime.Now.AddYears(-3)
        },
        new()
        {
            Id = 2, Name = "Luna", Type = PetType.Dog, Breed = "Pembroke Welsh Corgi", Age = 2,
            ImageUrl = "images/pets/dog4.png", OwnerId = 4,
            Bio = "Luna is a sassy corgi princess who rules the house! She enjoys treats, belly rubs, and supervising everyone's activities.",
            FavoriteActivities = ["Treat time", "Belly rubs", "Herding cats"],
            VisitedVenueIds = [2, 4, 8, 10], DateAdded = DateTime.Now.AddYears(-1)
        },
        new()
        {
            Id = 3, Name = "Buddy", Type = PetType.Dog, Breed = "Labrador Retriever", Age = 5,
            ImageUrl = "images/pets/dog3.jpg", OwnerId = 2,
            Bio = "Buddy is the ultimate good boy! Loves everyone and everything, especially beach days and long hikes.",
            FavoriteActivities = ["Beach trips", "Hiking", "Meeting new dogs"],
            VisitedVenueIds = [1, 5, 7, 9], DateAdded = DateTime.Now.AddYears(-4)
        },
        new()
        {
            Id = 4, Name = "Whiskers", Type = PetType.Cat, Breed = "Maine Coon", Age = 6,
            ImageUrl = "images/pets/cat1.jpg", OwnerId = 3,
            Bio = "Whiskers is a majestic fluffball who enjoys birdwatching from the stroller and judging humans.",
            FavoriteActivities = ["Birdwatching", "Napping", "Judging"],
            VisitedVenueIds = [1, 3], DateAdded = DateTime.Now.AddYears(-5)
        },
        new()
        {
            Id = 5, Name = "Mittens", Type = PetType.Cat, Breed = "Siamese", Age = 3,
            ImageUrl = "images/pets/cat2.jpg", OwnerId = 6,
            Bio = "Mittens is chatty and curious! She loves exploring new places (safely in her backpack) and meeting other cats.",
            FavoriteActivities = ["Talking", "Exploring", "Sunbathing"],
            VisitedVenueIds = [3, 6], DateAdded = DateTime.Now.AddYears(-2)
        },
        new()
        {
            Id = 6, Name = "Shadow", Type = PetType.Cat, Breed = "Black Domestic Shorthair", Age = 4,
            ImageUrl = "images/pets/cat3.jpg", OwnerId = 8,
            Bio = "Shadow is a mysterious gentleman who enjoys fine dining and luxury accommodations.",
            FavoriteActivities = ["Dining", "Napping", "Being mysterious"],
            VisitedVenueIds = [4, 11], DateAdded = DateTime.Now.AddYears(-3)
        },
        new()
        {
            Id = 7, Name = "Spike", Type = PetType.Exotic, Breed = "African Pygmy Hedgehog", Age = 2,
            ImageUrl = "images/pets/hedgehog.jpg", OwnerId = 7,
            Bio = "Spike is a tiny adventurer with a big personality! He loves exploring (safely) and eating mealworms.",
            FavoriteActivities = ["Exploring", "Snacking", "Rolling into a ball"],
            VisitedVenueIds = [3, 12], DateAdded = DateTime.Now.AddYears(-1)
        },
        new()
        {
            Id = 8, Name = "Cinnamon", Type = PetType.Rabbit, Breed = "Holland Lop", Age = 3,
            ImageUrl = "images/pets/bunny.jpg", OwnerId = 9,
            Bio = "Cinnamon is a fluffy bun who loves head rubs and fresh vegetables! Very photogenic.",
            FavoriteActivities = ["Binkying", "Eating veggies", "Getting brushed"],
            VisitedVenueIds = [8], DateAdded = DateTime.Now.AddYears(-2)
        },
        new()
        {
            Id = 9, Name = "Rocky", Type = PetType.Dog, Breed = "German Shepherd", Age = 3,
            ImageUrl = "images/pets/dog5.jpg", OwnerId = 5,
            Bio = "Rocky is an athletic pup who needs lots of exercise! He excels at hiking and agility training.",
            FavoriteActivities = ["Hiking", "Agility", "Tug of war"],
            VisitedVenueIds = [7, 9], DateAdded = DateTime.Now.AddYears(-2)
        }
    ];

    public List<Pet> GetAllPets() => _pets;

    public Pet? GetPetById(int id) => _pets.FirstOrDefault(p => p.Id == id);

    public List<Pet> GetPetsByOwner(int ownerId) => _pets.Where(p => p.OwnerId == ownerId).ToList();

    public List<Pet> GetPetsByType(PetType type) => _pets.Where(p => p.Type == type).ToList();

    public void AddPet(Pet pet)
    {
        pet.Id = _pets.Max(p => p.Id) + 1;
        pet.DateAdded = DateTime.Now;
        _pets.Add(pet);
    }

    public void UpdatePet(Pet pet)
    {
        var existing = _pets.FirstOrDefault(p => p.Id == pet.Id);
        if (existing != null)
        {
            var index = _pets.IndexOf(existing);
            _pets[index] = pet;
        }
    }

    public void DeletePet(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet != null)
        {
            _pets.Remove(pet);
        }
    }

    #endregion

    #region Users

    private static List<User> InitializeUsers() =>
    [
        new() { Id = 1, Name = "Sarah Mitchell", Email = "sarah@example.com", ImageUrl = "images/pets/dog1.png", 
            Bio = "Dog mom to Max the Golden! Love exploring pet-friendly spots.", 
            PetIds = [1], FavoriteVenueIds = [1, 3, 4], JoinDate = DateTime.Now.AddYears(-2), ReviewCount = 3, VenuesAdded = 1 },
        new() { Id = 2, Name = "Mike Johnson", Email = "mike@example.com", ImageUrl = "images/pets/dog3.jpg",
            Bio = "Adventure seeker with my Lab Buddy. Always looking for new trails!",
            PetIds = [3], FavoriteVenueIds = [1, 7, 9], JoinDate = DateTime.Now.AddYears(-1), ReviewCount = 3, VenuesAdded = 0 },
        new() { Id = 3, Name = "Emma Wilson", Email = "emma@example.com", ImageUrl = "images/pets/cat1.jpg",
            Bio = "Cat lady and proud! Whiskers approves of selected venues only.",
            PetIds = [4], FavoriteVenueIds = [1], JoinDate = DateTime.Now.AddMonths(-8), ReviewCount = 1, VenuesAdded = 0 },
        new() { Id = 4, Name = "Jessica Brown", Email = "jessica@example.com", ImageUrl = "images/pets/dog4.png",
            Bio = "Corgi mom living the dream with Luna 🐾",
            PetIds = [2], FavoriteVenueIds = [2, 4, 8], JoinDate = DateTime.Now.AddYears(-1), ReviewCount = 4, VenuesAdded = 2 },
        new() { Id = 5, Name = "David Lee", Email = "david@example.com", ImageUrl = "images/pets/dog5.jpg",
            Bio = "Rocky and I hike every weekend! Share our favorite spots.",
            PetIds = [9], FavoriteVenueIds = [7, 9], JoinDate = DateTime.Now.AddMonths(-6), ReviewCount = 3, VenuesAdded = 1 },
        new() { Id = 6, Name = "Lisa Chen", Email = "lisa@example.com", ImageUrl = "images/pets/cat2.jpg",
            Bio = "Mittens is my best travel buddy in her cat backpack!",
            PetIds = [5], FavoriteVenueIds = [3, 6], JoinDate = DateTime.Now.AddMonths(-10), ReviewCount = 2, VenuesAdded = 0 },
        new() { Id = 7, Name = "Tom Garcia", Email = "tom@example.com", ImageUrl = "images/pets/hedgehog.jpg",
            Bio = "Exotic pet dad - proving hedgehogs are the best pets!",
            PetIds = [7], FavoriteVenueIds = [3, 12], JoinDate = DateTime.Now.AddMonths(-4), ReviewCount = 2, VenuesAdded = 1 },
        new() { Id = 8, Name = "Robert Kim", Email = "robert@example.com", ImageUrl = "images/pets/cat3.jpg",
            Bio = "Shadow and I appreciate the finer things in life.",
            PetIds = [6], FavoriteVenueIds = [4, 11], JoinDate = DateTime.Now.AddMonths(-7), ReviewCount = 2, VenuesAdded = 0 },
        new() { Id = 9, Name = "Amy Taylor", Email = "amy@example.com", ImageUrl = "images/pets/bunny.jpg",
            Bio = "Bunny mom! Cinnamon is the cutest Holland Lop you'll ever meet.",
            PetIds = [8], FavoriteVenueIds = [8], JoinDate = DateTime.Now.AddMonths(-5), ReviewCount = 1, VenuesAdded = 0 }
    ];

    public List<User> GetAllUsers() => _users;

    public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

    // Current user for demo purposes
    public User GetCurrentUser() => _users[0]; // Sarah Mitchell

    #endregion

    #region Statistics

    public (int VenueCount, int ReviewCount, int PetCount) GetStatistics()
    {
        return (
            _venues.Count,
            _venues.Sum(v => v.Reviews.Count),
            _pets.Count
        );
    }

    public List<Review> GetRecentReviews(int count = 5) =>
        _venues.SelectMany(v => v.Reviews)
            .OrderByDescending(r => r.Date)
            .Take(count)
            .ToList();

    #endregion
}
