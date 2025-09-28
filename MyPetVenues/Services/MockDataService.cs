using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockDataService
{
    private readonly List<Venue> _venues;
    private readonly List<Pet> _pets;

    public MockDataService()
    {
        _venues = InitializeVenues();
        _pets = InitializePets();
    }

    public Task<List<Venue>> GetVenuesAsync()
    {
        return Task.FromResult(_venues);
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        return Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));
    }

    public Task<List<Pet>> GetPetsAsync()
    {
        return Task.FromResult(_pets);
    }

    public Task<Pet?> GetPetByIdAsync(int id)
    {
        return Task.FromResult(_pets.FirstOrDefault(p => p.Id == id));
    }

    public Task<List<Venue>> GetFeaturedVenuesAsync()
    {
        return Task.FromResult(_venues.Where(v => v.IsFeatured).Take(3).ToList());
    }

    public Task<List<Pet>> GetFeaturedPetsAsync()
    {
        return Task.FromResult(_pets.Where(p => p.IsFeatured).Take(3).ToList());
    }

    public Task<bool> SubmitVenueRatingAsync(int venueId, int userId, int rating)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue == null || rating < 1 || rating > 5)
            return Task.FromResult(false);

        // Add or update user rating
        venue.UserRatings[userId] = rating;

        // Recalculate average rating
        if (venue.UserRatings.Any())
        {
            venue.Rating = venue.UserRatings.Values.Average();
            venue.ReviewCount = venue.UserRatings.Count;
        }

        return Task.FromResult(true);
    }

    private List<Venue> InitializeVenues()
    {
        return new List<Venue>
        {
            new Venue
            {
                Id = 1,
                Name = "Bark & Brew Cafe",
                Description = "A cozy neighborhood cafe where you and your furry friend can enjoy artisan coffee, fresh pastries, and a dedicated pet menu. Our spacious outdoor patio features plenty of shade and water stations.",
                Address = "123 Main Street, Seattle, WA 98101",
                Phone = "(206) 555-0123",
                Website = "https://barkandbrewcafe.com",
                Category = VenueCategory.Cafes,
                Rating = 4.8,
                ReviewCount = 127,
                ImageUrl = "images/venues/cafe1.jpg",
                GalleryImages = new List<string> { "images/venues/cafe1.jpg" },
                PetPolicy = "🐕 Dogs of all sizes welcome! 🐱 Cats in carriers are also welcome. Pets must be leashed or contained at all times. We provide complimentary water bowls and pet treats with every visit.",
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.PetMenu, Amenity.OutdoorSeating, Amenity.PetTreats, Amenity.ShadeAreas, Amenity.Parking },
                AcceptedSizes = new List<PetSize> { PetSize.AllSizes },
                AcceptedPets = new List<PetType> { PetType.Dogs, PetType.Cats },
                Hours = new Dictionary<string, string>
                {
                    { "Monday-Friday", "7:00 AM - 6:00 PM" },
                    { "Saturday-Sunday", "8:00 AM - 7:00 PM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 1, ReviewerName = "Sarah Johnson", Rating = 5, Comment = "Amazing place! They have a special puppuccino for dogs and the staff is so friendly. My golden retriever Max loves it here! 🐕", Date = DateTime.Now.AddDays(-5), PetName = "Max", HelpfulCount = 24 },
                    new Review { Id = 2, ReviewerName = "Mike Chen", Rating = 4.5, Comment = "Great atmosphere and my dog enjoyed the outdoor seating area. Coffee is excellent too!", Date = DateTime.Now.AddDays(-12), PetName = "Buddy", HelpfulCount = 18 },
                    new Review { Id = 3, ReviewerName = "Emily Rodriguez", Rating = 5, Comment = "The pet menu is adorable and they even remembered my dog's name on our second visit! Highly recommend. ❤️", Date = DateTime.Now.AddDays(-20), PetName = "Luna", HelpfulCount = 31 }
                },
                IsFeatured = true
            },
            new Venue
            {
                Id = 2,
                Name = "Paws & Trails Park",
                Description = "A beautiful 15-acre dog park featuring separate areas for small and large dogs, agility equipment, walking trails, and a seasonal dog beach. Perfect for socializing and exercise!",
                Address = "456 Park Avenue, Seattle, WA 98102",
                Phone = "(206) 555-0456",
                Website = "https://pawsandtrailspark.com",
                Category = VenueCategory.Parks,
                Rating = 4.9,
                ReviewCount = 342,
                ImageUrl = "images/venues/park1.jpg",
                GalleryImages = new List<string> { "images/venues/park1.jpg" },
                PetPolicy = "🎾 Dogs must be licensed and vaccinated. Off-leash in designated areas only. Owners must clean up after their pets. Park hours: Dawn to Dusk.",
                Amenities = new List<Amenity> { Amenity.OffLeashArea, Amenity.WaterBowls, Amenity.WasteStations, Amenity.ShadeAreas, Amenity.Parking, Amenity.DogRuns, Amenity.AgilityCourse },
                AcceptedSizes = new List<PetSize> { PetSize.AllSizes },
                AcceptedPets = new List<PetType> { PetType.Dogs },
                Hours = new Dictionary<string, string>
                {
                    { "Daily", "6:00 AM - 9:00 PM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 4, ReviewerName = "David Martinez", Rating = 5, Comment = "Best dog park in the city! Separate areas for different sized dogs is perfect. My husky loves the agility course! 🏃‍♂️", Date = DateTime.Now.AddDays(-3), PetName = "Koda", HelpfulCount = 45 },
                    new Review { Id = 5, ReviewerName = "Lisa Thompson", Rating = 4.8, Comment = "Clean, well-maintained, and plenty of space. My poodle has made so many friends here!", Date = DateTime.Now.AddDays(-8), PetName = "Coco", HelpfulCount = 29 },
                    new Review { Id = 6, ReviewerName = "James Wilson", Rating = 5, Comment = "The trails are scenic and the off-leash areas are safe. Highly recommend! 🌳", Date = DateTime.Now.AddDays(-15), PetName = "Charlie", HelpfulCount = 38 }
                },
                IsFeatured = true
            },
            new Venue
            {
                Id = 3,
                Name = "The Wagging Tail Hotel",
                Description = "Luxury pet-friendly hotel offering spacious suites, in-room pet amenities, a dedicated dog park, grooming services, and 24/7 pet sitting. Your pet's vacation starts here!",
                Address = "789 Hotel Boulevard, Seattle, WA 98104",
                Phone = "(206) 555-0789",
                Website = "https://waggingtailhotel.com",
                Category = VenueCategory.Hotels,
                Rating = 4.7,
                ReviewCount = 89,
                ImageUrl = "images/venues/hotel1.jpg",
                GalleryImages = new List<string> { "images/venues/hotel1.jpg" },
                PetPolicy = "🏨 Pets up to 50 lbs welcome (up to 2 pets per room). Pet fee: $50 per stay. We provide pet beds, bowls, and welcome treats. Pet sitting and grooming available for additional fees.",
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.PetTreats, Amenity.WasteStations, Amenity.Parking, Amenity.IndoorSeating },
                AcceptedSizes = new List<PetSize> { PetSize.Small, PetSize.Medium },
                AcceptedPets = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.SmallAnimals },
                Hours = new Dictionary<string, string>
                {
                    { "Daily", "24 Hours - Check-in: 3:00 PM, Check-out: 11:00 AM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 7, ReviewerName = "Amanda Foster", Rating = 5, Comment = "They treat pets like royalty! My cat had his own welcome basket with toys and treats. Will definitely return! 😻", Date = DateTime.Now.AddDays(-7), PetName = "Whiskers", HelpfulCount = 22 },
                    new Review { Id = 8, ReviewerName = "Robert Kim", Rating = 4.5, Comment = "Great location and very accommodating staff. The pet park on property was convenient.", Date = DateTime.Now.AddDays(-14), PetName = "Toby", HelpfulCount = 16 }
                },
                IsFeatured = true
            },
            new Venue
            {
                Id = 4,
                Name = "Paws & Claws Pet Store",
                Description = "Your one-stop shop for all pet supplies! From premium food and toys to accessories and grooming products. Knowledgeable staff ready to help with expert advice.",
                Address = "321 Commerce Street, Seattle, WA 98105",
                Phone = "(206) 555-0321",
                Website = "https://pawsandclawsstore.com",
                Category = VenueCategory.PetStores,
                Rating = 4.6,
                ReviewCount = 156,
                ImageUrl = "images/venues/store1.jpg",
                GalleryImages = new List<string> { "images/venues/store1.jpg" },
                PetPolicy = "🛍️ All well-behaved pets welcome on leash! Free treat bar for visiting pets. Monthly adoption events in partnership with local shelters.",
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.PetTreats, Amenity.IndoorSeating, Amenity.Parking },
                AcceptedSizes = new List<PetSize> { PetSize.AllSizes },
                AcceptedPets = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Birds, PetType.SmallAnimals },
                Hours = new Dictionary<string, string>
                {
                    { "Monday-Saturday", "9:00 AM - 8:00 PM" },
                    { "Sunday", "10:00 AM - 6:00 PM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 9, ReviewerName = "Jennifer Adams", Rating = 4.8, Comment = "Great selection and the staff really knows their stuff! They helped me find the perfect food for my picky eater. 🐈", Date = DateTime.Now.AddDays(-4), PetName = "Mittens", HelpfulCount = 19 },
                    new Review { Id = 10, ReviewerName = "Tom Harrison", Rating = 4.5, Comment = "Love the treat bar for pets! My dog gets excited every time we visit.", Date = DateTime.Now.AddDays(-11), PetName = "Duke", HelpfulCount = 14 }
                }
            },
            new Venue
            {
                Id = 5,
                Name = "Mooch's Pet Supplies",
                Description = "Family-owned pet store specializing in natural and organic pet products. We carry premium brands and offer personalized nutrition consultations.",
                Address = "555 Oak Street, Seattle, WA 98106",
                Phone = "(206) 555-0555",
                Website = "https://moochspetsupplies.com",
                Category = VenueCategory.PetStores,
                Rating = 4.7,
                ReviewCount = 98,
                ImageUrl = "images/venues/moochs1.jpg",
                GalleryImages = new List<string> { "images/venues/moochs1.jpg" },
                PetPolicy = "🥕 All pets welcome! We specialize in natural, holistic pet care. Bring your pet for free nutrition consultations every Saturday.",
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.PetTreats, Amenity.Parking },
                AcceptedSizes = new List<PetSize> { PetSize.AllSizes },
                AcceptedPets = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.SmallAnimals },
                Hours = new Dictionary<string, string>
                {
                    { "Monday-Friday", "10:00 AM - 7:00 PM" },
                    { "Saturday", "9:00 AM - 8:00 PM" },
                    { "Sunday", "11:00 AM - 5:00 PM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 11, ReviewerName = "Patricia Green", Rating = 5, Comment = "The nutrition consultation was invaluable! My dog's coat has never looked better. ✨", Date = DateTime.Now.AddDays(-6), PetName = "Bella", HelpfulCount = 27 },
                    new Review { Id = 12, ReviewerName = "Kevin Brown", Rating = 4.6, Comment = "Quality products and friendly service. A bit pricey but worth it for the quality.", Date = DateTime.Now.AddDays(-13), PetName = "Rocky", HelpfulCount = 15 }
                }
            },
            new Venue
            {
                Id = 6,
                Name = "Pet Paradise Resort",
                Description = "Upscale boarding facility and daycare with indoor/outdoor play areas, webcams for monitoring, luxury suites, and trained staff. Your pet's home away from home!",
                Address = "999 Resort Road, Seattle, WA 98107",
                Phone = "(206) 555-0999",
                Website = "https://petparadiseresort.com",
                Category = VenueCategory.Hotels,
                Rating = 4.9,
                ReviewCount = 213,
                ImageUrl = "images/venues/home1.jpg",
                GalleryImages = new List<string> { "images/venues/home1.jpg" },
                PetPolicy = "🏖️ Boarding and daycare for dogs and cats. All pets must be current on vaccinations. Temperament evaluation required for first-time guests. VIP suites available with premium bedding and TV!",
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.IndoorSeating, Amenity.OutdoorSeating, Amenity.WasteStations, Amenity.PetTreats, Amenity.Parking },
                AcceptedSizes = new List<PetSize> { PetSize.AllSizes },
                AcceptedPets = new List<PetType> { PetType.Dogs, PetType.Cats },
                Hours = new Dictionary<string, string>
                {
                    { "Monday-Friday", "7:00 AM - 7:00 PM" },
                    { "Saturday-Sunday", "8:00 AM - 6:00 PM" }
                },
                Reviews = new List<Review>
                {
                    new Review { Id = 13, ReviewerName = "Michelle Taylor", Rating = 5, Comment = "The webcams are awesome! I could check on my dog throughout the day. He came home happy and tired. Perfect! 📹", Date = DateTime.Now.AddDays(-2), PetName = "Zeus", HelpfulCount = 52 },
                    new Review { Id = 14, ReviewerName = "Steven Lee", Rating = 4.9, Comment = "Staff is professional and caring. My anxious cat did great here!", Date = DateTime.Now.AddDays(-9), PetName = "Shadow", HelpfulCount = 34 },
                    new Review { Id = 15, ReviewerName = "Rachel Moore", Rating = 5, Comment = "Cleanest facility I've seen. My pup loves daycare here! 🐾", Date = DateTime.Now.AddDays(-16), PetName = "Daisy", HelpfulCount = 41 }
                }
            }
        };
    }

    private List<Pet> InitializePets()
    {
        return new List<Pet>
        {
            new Pet
            {
                Id = 1,
                Name = "Max",
                Type = PetType.Dogs,
                Breed = "Golden Retriever",
                Age = 3,
                Size = PetSize.Large,
                ImageUrl = "images/pets/dog1.png",
                Bio = "Friendly and energetic golden retriever who loves making new friends at the dog park! Max enjoys swimming, playing fetch, and meeting new people.",
                Personality = new List<string> { "Friendly", "Energetic", "Playful", "Social" },
                OwnerName = "Sarah Johnson",
                FavoriteVenues = new List<string> { "Bark & Brew Cafe", "Paws & Trails Park" },
                IsFeatured = true
            },
            new Pet
            {
                Id = 2,
                Name = "Luna",
                Type = PetType.Dogs,
                Breed = "Husky Mix",
                Age = 2,
                Size = PetSize.Large,
                ImageUrl = "images/pets/dog3.jpg",
                Bio = "Beautiful husky mix with stunning blue eyes. Luna is an adventure seeker who loves hiking trails and snow days!",
                Personality = new List<string> { "Adventurous", "Independent", "Vocal", "Intelligent" },
                OwnerName = "Emily Rodriguez",
                FavoriteVenues = new List<string> { "Paws & Trails Park" },
                IsFeatured = true
            },
            new Pet
            {
                Id = 3,
                Name = "Whiskers",
                Type = PetType.Cats,
                Breed = "Maine Coon",
                Age = 4,
                Size = PetSize.Medium,
                ImageUrl = "images/pets/cat1.jpg",
                Bio = "Majestic Maine Coon with a gentle personality. Whiskers enjoys supervised outdoor adventures and cozy cafe visits in his carrier.",
                Personality = new List<string> { "Gentle", "Curious", "Affectionate", "Calm" },
                OwnerName = "Amanda Foster",
                FavoriteVenues = new List<string> { "The Wagging Tail Hotel" },
                IsFeatured = true
            },
            new Pet
            {
                Id = 4,
                Name = "Buddy",
                Type = PetType.Dogs,
                Breed = "Labrador Retriever",
                Age = 5,
                Size = PetSize.Large,
                ImageUrl = "images/pets/dog4.png",
                Bio = "Loyal lab who's always ready for an adventure. Buddy is great with kids and other dogs, making him the perfect park companion!",
                Personality = new List<string> { "Loyal", "Friendly", "Patient", "Food-motivated" },
                OwnerName = "Mike Chen",
                FavoriteVenues = new List<string> { "Bark & Brew Cafe", "Paws & Trails Park" }
            },
            new Pet
            {
                Id = 5,
                Name = "Charlie",
                Type = PetType.Dogs,
                Breed = "Beagle",
                Age = 4,
                Size = PetSize.Medium,
                ImageUrl = "images/pets/dog5.jpg",
                Bio = "Curious beagle with an excellent nose! Charlie loves exploring new places and following interesting scents on trail walks.",
                Personality = new List<string> { "Curious", "Determined", "Friendly", "Vocal" },
                OwnerName = "James Wilson",
                FavoriteVenues = new List<string> { "Paws & Trails Park" }
            },
            new Pet
            {
                Id = 6,
                Name = "Bella",
                Type = PetType.Dogs,
                Breed = "French Bulldog",
                Age = 2,
                Size = PetSize.Small,
                ImageUrl = "images/pets/dog6.png",
                Bio = "Adorable Frenchie with a big personality! Bella loves being the center of attention and making people smile wherever she goes.",
                Personality = new List<string> { "Charming", "Playful", "Affectionate", "Stubborn" },
                OwnerName = "Patricia Green",
                FavoriteVenues = new List<string> { "Bark & Brew Cafe", "Mooch's Pet Supplies" }
            },
            new Pet
            {
                Id = 7,
                Name = "Mittens",
                Type = PetType.Cats,
                Breed = "Tabby",
                Age = 3,
                Size = PetSize.Small,
                ImageUrl = "images/pets/cat2.jpg",
                Bio = "Sweet tabby cat who enjoys quiet moments and sunny windowsills. Mittens is a picky eater but very affectionate once she warms up to you.",
                Personality = new List<string> { "Sweet", "Reserved", "Affectionate", "Observant" },
                OwnerName = "Jennifer Adams",
                FavoriteVenues = new List<string> { "Paws & Claws Pet Store" }
            },
            new Pet
            {
                Id = 8,
                Name = "Rocky",
                Type = PetType.Dogs,
                Breed = "German Shepherd",
                Age = 6,
                Size = PetSize.Large,
                ImageUrl = "images/pets/dog7.jpg",
                Bio = "Intelligent and protective German Shepherd. Rocky is a trained service dog who loves learning new tricks and helping his owner.",
                Personality = new List<string> { "Intelligent", "Protective", "Loyal", "Disciplined" },
                OwnerName = "Kevin Brown",
                FavoriteVenues = new List<string> { "Mooch's Pet Supplies" }
            },
            new Pet
            {
                Id = 9,
                Name = "Daisy",
                Type = PetType.Dogs,
                Breed = "Corgi",
                Age = 3,
                Size = PetSize.Small,
                ImageUrl = "images/pets/dog8.jpg",
                Bio = "Energetic corgi with short legs and a big heart! Daisy loves playtime at daycare and making everyone laugh with her silly antics.",
                Personality = new List<string> { "Energetic", "Happy", "Social", "Entertaining" },
                OwnerName = "Rachel Moore",
                FavoriteVenues = new List<string> { "Pet Paradise Resort" }
            },
            new Pet
            {
                Id = 10,
                Name = "Oliver",
                Type = PetType.Cats,
                Breed = "Persian",
                Age = 5,
                Size = PetSize.Medium,
                ImageUrl = "images/pets/cat3.jpg",
                Bio = "Elegant Persian cat with luxurious fur. Oliver enjoys being pampered and has a refined taste in everything from food to sleeping spots.",
                Personality = new List<string> { "Dignified", "Calm", "Affectionate", "Particular" },
                OwnerName = "Sophia Martinez",
                FavoriteVenues = new List<string> { "The Wagging Tail Hotel" }
            },
            new Pet
            {
                Id = 11,
                Name = "Thumper",
                Type = PetType.SmallAnimals,
                Breed = "Holland Lop Rabbit",
                Age = 2,
                Size = PetSize.Small,
                ImageUrl = "images/pets/bunny.jpg",
                Bio = "Adorable lop-eared bunny who loves fresh veggies and hopping around! Thumper is litter trained and enjoys gentle cuddles.",
                Personality = new List<string> { "Gentle", "Curious", "Playful", "Sweet" },
                OwnerName = "Alex Thompson",
                FavoriteVenues = new List<string> { "Paws & Claws Pet Store" }
            },
            new Pet
            {
                Id = 12,
                Name = "Spike",
                Type = PetType.SmallAnimals,
                Breed = "African Pygmy Hedgehog",
                Age = 1,
                Size = PetSize.Small,
                ImageUrl = "images/pets/hedgehog.jpg",
                Bio = "Tiny hedgehog with a big personality! Spike loves mealworms, running on his wheel at night, and surprising everyone with how cute he is.",
                Personality = new List<string> { "Nocturnal", "Shy", "Unique", "Curious" },
                OwnerName = "Taylor Davis",
                FavoriteVenues = new List<string> { "Mooch's Pet Supplies" }
            }
        };
    }
}
