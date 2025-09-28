using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class VenueService
{
    private readonly List<Venue> _venues = new();

    public VenueService()
    {
        InitializeMockData();
    }

    private void InitializeMockData()
    {
        _venues.AddRange(new[]
        {
            new Venue
            {
                Id = 1,
                Name = "The Cozy Paw Café",
                Category = "Cafe",
                Description = "A warm and welcoming café where you and your furry friend can enjoy artisan coffee and homemade treats. We have a dedicated outdoor patio with water bowls and even a special pet menu!",
                Address = "123 Main Street",
                City = "Seattle",
                State = "WA",
                ZipCode = "98101",
                Phone = "(206) 555-0123",
                Website = "https://cozypawcafe.com",
                MainImageUrl = "images/venues/cafe1.jpg",
                ImageUrls = new List<string> { "images/venues/cafe1.jpg", "images/pets/dog1.png" },
                Amenities = new List<string> { "Water Bowls", "Outdoor Seating", "Pet Menu", "Waste Bags", "Shade Available" },
                PetPolicy = "All well-behaved pets welcome on leash. Must be friendly with other animals and people.",
                Hours = "Mon-Fri: 7AM-7PM, Sat-Sun: 8AM-8PM",
                Rating = 4.8,
                ReviewCount = 127,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 1,
                        VenueId = 1,
                        AuthorName = "Sarah Johnson",
                        AuthorPetName = "Max",
                        AuthorPetType = "Dog",
                        Content = "Absolutely love this place! Max and I come here every weekend. The staff is super friendly and they always bring water for Max without me asking. The outdoor patio is perfect!",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-15)
                    },
                    new Review
                    {
                        Id = 2,
                        VenueId = 1,
                        AuthorName = "Michael Chen",
                        AuthorPetName = "Bella",
                        AuthorPetType = "Dog",
                        Content = "Great atmosphere and good coffee. The patio area is nice but can get crowded on weekends. Overall a solid choice for pet owners.",
                        Rating = 4,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 4,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-8)
                    },
                    new Review
                    {
                        Id = 3,
                        VenueId = 1,
                        AuthorName = "Emma Rodriguez",
                        AuthorPetName = "Charlie",
                        AuthorPetType = "Dog",
                        Content = "My go-to spot for morning coffee with Charlie. They even have treats for dogs! The staff remembers our names and always makes us feel welcome.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-3)
                    }
                }
            },
            new Venue
            {
                Id = 2,
                Name = "Bark & Play Park",
                Category = "Park",
                Description = "A spacious dog park with separate areas for small and large dogs. Features include agility equipment, shaded rest areas, and a small pond for swimming. Perfect for socializing and exercise!",
                Address = "456 Park Avenue",
                City = "Seattle",
                State = "WA",
                ZipCode = "98102",
                Phone = "(206) 555-0456",
                MainImageUrl = "images/venues/park1.jpg",
                ImageUrls = new List<string> { "images/venues/park1.jpg", "images/pets/dog5.jpg" },
                Amenities = new List<string> { "Fenced Area", "Separate Small Dog Area", "Water Fountain", "Agility Equipment", "Swimming Pond", "Benches", "Waste Stations" },
                PetPolicy = "Dogs must be licensed and vaccinated. Aggressive behavior will result in removal. Please clean up after your pet.",
                Hours = "Daily: 6AM-9PM",
                Rating = 4.6,
                ReviewCount = 203,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 4,
                        VenueId = 2,
                        AuthorName = "David Thompson",
                        AuthorPetName = "Rocky",
                        AuthorPetType = "Dog",
                        Content = "Rocky absolutely loves this park! The pond is his favorite feature. Great community of dog owners here. The only downside is it can get muddy after rain.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 4,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-20)
                    },
                    new Review
                    {
                        Id = 5,
                        VenueId = 2,
                        AuthorName = "Lisa Martinez",
                        AuthorPetName = "Daisy",
                        AuthorPetType = "Dog",
                        Content = "Perfect park for small dogs! Daisy feels safe in the small dog section. Well maintained and lots of friendly pups.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-5)
                    }
                }
            },
            new Venue
            {
                Id = 3,
                Name = "Pawsitive Vibes Pet Store",
                Category = "Shop",
                Description = "Your one-stop shop for all things pet! From premium food to toys and accessories, we have everything your pet needs. Bring your pet in to try treats and test out toys before you buy!",
                Address = "789 Commerce Street",
                City = "Seattle",
                State = "WA",
                ZipCode = "98103",
                Phone = "(206) 555-0789",
                Website = "https://pawsitivevibes.com",
                MainImageUrl = "images/venues/store1.jpg",
                ImageUrls = new List<string> { "images/venues/store1.jpg" },
                Amenities = new List<string> { "Air Conditioned", "Water Bowls", "Sample Treats", "Toy Testing Area", "Grooming Supplies", "Wide Aisles" },
                PetPolicy = "All pets welcome! Must be leashed or in carrier. We love meeting our customers' furry friends!",
                Hours = "Mon-Sat: 9AM-8PM, Sun: 10AM-6PM",
                Rating = 4.7,
                ReviewCount = 156,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 6,
                        VenueId = 3,
                        AuthorName = "Jennifer Lee",
                        AuthorPetName = "Whiskers",
                        AuthorPetType = "Cat",
                        Content = "Finally a pet store that's truly welcoming to cats! The staff helped me find the perfect food for Whiskers' sensitive stomach. Great selection and prices.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-12)
                    },
                    new Review
                    {
                        Id = 7,
                        VenueId = 3,
                        AuthorName = "Robert Kim",
                        AuthorPetName = "Buddy",
                        AuthorPetType = "Dog",
                        Content = "Love that Buddy can come shopping with me! The staff always gives him treats and helps us find what we need. Prices are reasonable too.",
                        Rating = 4,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 4,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-6)
                    }
                }
            },
            new Venue
            {
                Id = 4,
                Name = "Pet Paradise Hotel & Spa",
                Category = "Hotel",
                Description = "Luxury accommodations for you and your pet! Our pet-friendly hotel offers spacious rooms, a dedicated pet spa, walking services, and a rooftop dog park. Your pet's vacation starts here!",
                Address = "321 Harbor Boulevard",
                City = "Seattle",
                State = "WA",
                ZipCode = "98104",
                Phone = "(206) 555-0321",
                Website = "https://petparadisehotel.com",
                MainImageUrl = "images/venues/hotel1.jpg",
                ImageUrls = new List<string> { "images/venues/hotel1.jpg" },
                Amenities = new List<string> { "Pet Beds Provided", "Food/Water Bowls", "Rooftop Dog Park", "Pet Spa", "Walking Service", "Pet Sitting", "Welcome Treats", "24/7 Concierge" },
                PetPolicy = "All pets welcome! No size restrictions. Additional pet fee: $50 per night per pet. Maximum 2 pets per room.",
                Hours = "Check-in: 3PM, Check-out: 11AM",
                Rating = 4.9,
                ReviewCount = 89,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 8,
                        VenueId = 4,
                        AuthorName = "Amanda White",
                        AuthorPetName = "Luna",
                        AuthorPetType = "Dog",
                        Content = "The best pet-friendly hotel we've ever stayed at! Luna was treated like royalty. The rooftop park is amazing and the staff genuinely cares about the pets. Worth every penny!",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-25)
                    },
                    new Review
                    {
                        Id = 9,
                        VenueId = 4,
                        AuthorName = "James Wilson",
                        AuthorPetName = "Oliver",
                        AuthorPetType = "Cat",
                        Content = "Traveled with my cat Oliver and was worried he'd be stressed. The staff was incredible, the room was quiet and comfortable. They even provided a litter box! Highly recommend.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 5,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-10)
                    }
                }
            },
            new Venue
            {
                Id = 5,
                Name = "Mooch's Burger Joint",
                Category = "Restaurant",
                Description = "Classic American burgers and shakes with a pet-friendly twist! Our outdoor patio welcomes furry friends, and we offer a special 'Pup-Burger' made with plain ground beef, no seasoning – perfectly safe for dogs!",
                Address = "555 Burger Lane",
                City = "Seattle",
                State = "WA",
                ZipCode = "98105",
                Phone = "(206) 555-0555",
                Website = "https://moochsburgers.com",
                MainImageUrl = "images/venues/moochs1.jpg",
                ImageUrls = new List<string> { "images/venues/moochs1.jpg" },
                Amenities = new List<string> { "Outdoor Patio", "Pet Menu", "Water Bowls", "Shaded Seating", "Waste Bags", "Tie-up Posts" },
                PetPolicy = "Dogs welcome on our outdoor patio only. Must remain leashed and well-behaved. Please notify staff if ordering from our pet menu!",
                Hours = "Daily: 11AM-10PM",
                Rating = 4.5,
                ReviewCount = 178,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 10,
                        VenueId = 5,
                        AuthorName = "Rachel Green",
                        AuthorPetName = "Zeus",
                        AuthorPetType = "Dog",
                        Content = "Zeus went crazy for the Pup-Burger! And my bacon cheeseburger was incredible too. Love that we can enjoy a meal together. Staff is super friendly!",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 4,
                        AmenitiesRating = 5,
                        CreatedAt = DateTime.UtcNow.AddDays(-7)
                    },
                    new Review
                    {
                        Id = 11,
                        VenueId = 5,
                        AuthorName = "Tom Anderson",
                        AuthorPetName = "Sadie",
                        AuthorPetType = "Dog",
                        Content = "Good burgers and a nice patio area. Can get a bit noisy during peak hours which made Sadie a little anxious, but overall a good experience.",
                        Rating = 4,
                        PetFriendlinessRating = 4,
                        CleanlinessRating = 4,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-2)
                    }
                }
            },
            new Venue
            {
                Id = 6,
                Name = "Home & Garden Pet Emporium",
                Category = "Shop",
                Description = "A unique blend of home goods and pet supplies! Shop for your home while your pet explores our interactive play area. We specialize in eco-friendly and sustainable pet products.",
                Address = "888 Garden Way",
                City = "Seattle",
                State = "WA",
                ZipCode = "98106",
                Phone = "(206) 555-0888",
                Website = "https://homegardenpetemporium.com",
                MainImageUrl = "images/venues/home1.jpg",
                ImageUrls = new List<string> { "images/venues/home1.jpg" },
                Amenities = new List<string> { "Pet Play Area", "Water Station", "Waste Stations", "Air Conditioned", "Eco-Friendly Products", "Pet Training Classes" },
                PetPolicy = "All friendly, leashed pets welcome! Aggressive behavior not tolerated. Clean-up supplies provided throughout the store.",
                Hours = "Mon-Sat: 9AM-7PM, Sun: 10AM-5PM",
                Rating = 4.4,
                ReviewCount = 92,
                Reviews = new List<Review>
                {
                    new Review
                    {
                        Id = 12,
                        VenueId = 6,
                        AuthorName = "Patricia Brown",
                        AuthorPetName = "Milo",
                        AuthorPetType = "Dog",
                        Content = "Love the eco-friendly focus! Milo had fun in the play area while I shopped. Great selection of sustainable pet products. Staff is knowledgeable and helpful.",
                        Rating = 5,
                        PetFriendlinessRating = 5,
                        CleanlinessRating = 4,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-18)
                    },
                    new Review
                    {
                        Id = 13,
                        VenueId = 6,
                        AuthorName = "Kevin Davis",
                        AuthorPetName = "Mittens",
                        AuthorPetType = "Cat",
                        Content = "Nice store with good products. Mittens was comfortable in her carrier. Prices are a bit high but quality is excellent. Would come back.",
                        Rating = 4,
                        PetFriendlinessRating = 4,
                        CleanlinessRating = 5,
                        AmenitiesRating = 4,
                        CreatedAt = DateTime.UtcNow.AddDays(-4)
                    }
                }
            }
        });
    }

    public Task<List<Venue>> GetAllVenuesAsync()
    {
        return Task.FromResult(_venues.OrderByDescending(v => v.Rating).ToList());
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        return Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));
    }

    public Task<List<Venue>> GetVenuesByCategoryAsync(string category)
    {
        if (string.IsNullOrWhiteSpace(category) || category.Equals("All", StringComparison.OrdinalIgnoreCase))
        {
            return GetAllVenuesAsync();
        }

        var filteredVenues = _venues
            .Where(v => v.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(v => v.Rating)
            .ToList();

        return Task.FromResult(filteredVenues);
    }

    public Task<List<string>> GetCategoriesAsync()
    {
        var categories = _venues
            .Select(v => v.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        return Task.FromResult(categories);
    }

    public Task<List<Venue>> SearchVenuesAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return GetAllVenuesAsync();
        }

        var results = _venues
            .Where(v => 
                v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                (v.City != null && v.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
            .OrderByDescending(v => v.Rating)
            .ToList();

        return Task.FromResult(results);
    }
}
