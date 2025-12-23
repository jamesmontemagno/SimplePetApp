using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockDataService
{
    private readonly List<Amenity> _amenities;
    private readonly List<User> _users;
    private readonly List<Venue> _venues;
    private readonly List<Review> _reviews;
    
    public MockDataService()
    {
        _amenities = InitializeAmenities();
        _users = InitializeUsers();
        _venues = InitializeVenues();
        _reviews = InitializeReviews();
        
        // Calculate ratings for venues
        CalculateVenueRatings();
    }
    
    public List<Amenity> GetAmenities() => _amenities;
    public List<User> GetUsers() => _users;
    public List<Venue> GetVenues() => _venues;
    public List<Review> GetReviews() => _reviews;
    
    public Venue? GetVenueById(Guid id) => _venues.FirstOrDefault(v => v.Id == id);
    public List<Review> GetReviewsForVenue(Guid venueId) => 
        _reviews.Where(r => r.VenueId == venueId).OrderByDescending(r => r.DateCreated).ToList();
    
    public Task<List<Venue>> GetVenuesAsync() => Task.FromResult(_venues);
    public Task<Venue?> GetVenueByIdAsync(Guid id) => Task.FromResult(GetVenueById(id));
    public Task<List<Review>> GetReviewsForVenueAsync(Guid venueId) => Task.FromResult(GetReviewsForVenue(venueId));
    public Task<List<Review>> GetAllReviewsAsync() => Task.FromResult(_reviews.OrderByDescending(r => r.DateCreated).ToList());
    
    public Task AddVenueAsync(Venue venue)
    {
        venue.Id = Guid.NewGuid();
        venue.DateAdded = DateTime.Now;
        _venues.Add(venue);
        return Task.CompletedTask;
    }
    
    public Task AddReviewAsync(Review review)
    {
        review.Id = Guid.NewGuid();
        review.DateCreated = DateTime.Now;
        _reviews.Add(review);
        CalculateVenueRatings();
        return Task.CompletedTask;
    }
    
    private void CalculateVenueRatings()
    {
        foreach (var venue in _venues)
        {
            var venueReviews = _reviews.Where(r => r.VenueId == venue.Id).ToList();
            venue.ReviewCount = venueReviews.Count;
            venue.Rating = venueReviews.Any() ? venueReviews.Average(r => r.Rating) : 0;
        }
    }
    
    private List<Amenity> InitializeAmenities()
    {
        return new List<Amenity>
        {
            new() { Id = Guid.NewGuid(), Name = "Water Bowls", Icon = "💧", Category = AmenityCategory.Water },
            new() { Id = Guid.NewGuid(), Name = "Water Fountain", Icon = "⛲", Category = AmenityCategory.Water },
            new() { Id = Guid.NewGuid(), Name = "Pet Menu", Icon = "🍖", Category = AmenityCategory.Food },
            new() { Id = Guid.NewGuid(), Name = "Treats Available", Icon = "🦴", Category = AmenityCategory.Food },
            new() { Id = Guid.NewGuid(), Name = "Off-Leash Area", Icon = "🏃", Category = AmenityCategory.Recreation },
            new() { Id = Guid.NewGuid(), Name = "Fenced Area", Icon = "🚧", Category = AmenityCategory.Safety },
            new() { Id = Guid.NewGuid(), Name = "Waste Stations", Icon = "🗑️", Category = AmenityCategory.Hygiene },
            new() { Id = Guid.NewGuid(), Name = "Pet Washing Station", Icon = "🚿", Category = AmenityCategory.Hygiene },
            new() { Id = Guid.NewGuid(), Name = "Shade/Shelter", Icon = "⛱️", Category = AmenityCategory.Comfort },
            new() { Id = Guid.NewGuid(), Name = "Seating Area", Icon = "🪑", Category = AmenityCategory.Comfort },
            new() { Id = Guid.NewGuid(), Name = "Indoor Space", Icon = "🏠", Category = AmenityCategory.Comfort },
            new() { Id = Guid.NewGuid(), Name = "Outdoor Space", Icon = "🌳", Category = AmenityCategory.Recreation },
            new() { Id = Guid.NewGuid(), Name = "Grooming Services", Icon = "✂️", Category = AmenityCategory.Services },
            new() { Id = Guid.NewGuid(), Name = "Veterinary Care", Icon = "⚕️", Category = AmenityCategory.Services },
            new() { Id = Guid.NewGuid(), Name = "Pet Daycare", Icon = "🏫", Category = AmenityCategory.Services }
        };
    }
    
    private List<User> InitializeUsers()
    {
        return new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Sarah Johnson", Email = "sarah@email.com", AvatarUrl = "/images/pets/dog1.png", JoinDate = DateTime.Now.AddMonths(-8), ReviewCount = 5,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Max", Type = PetType.Dog, Breed = "Golden Retriever", Age = 3, PhotoUrl = "/images/pets/dog1.png" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Michael Chen", Email = "michael@email.com", AvatarUrl = "/images/pets/cat1.jpg", JoinDate = DateTime.Now.AddMonths(-6), ReviewCount = 3,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Whiskers", Type = PetType.Cat, Breed = "Tabby", Age = 2, PhotoUrl = "/images/pets/cat1.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Emily Rodriguez", Email = "emily@email.com", AvatarUrl = "/images/pets/dog3.jpg", JoinDate = DateTime.Now.AddMonths(-10), ReviewCount = 7,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Bella", Type = PetType.Dog, Breed = "Labrador", Age = 4, PhotoUrl = "/images/pets/dog3.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "David Kim", Email = "david@email.com", AvatarUrl = "/images/pets/dog5.jpg", JoinDate = DateTime.Now.AddMonths(-5), ReviewCount = 4,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Rocky", Type = PetType.Dog, Breed = "German Shepherd", Age = 5, PhotoUrl = "/images/pets/dog5.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Jessica Brown", Email = "jessica@email.com", AvatarUrl = "/images/pets/cat2.jpg", JoinDate = DateTime.Now.AddMonths(-7), ReviewCount = 6,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Luna", Type = PetType.Cat, Breed = "Persian", Age = 1, PhotoUrl = "/images/pets/cat2.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Robert Taylor", Email = "robert@email.com", AvatarUrl = "/images/pets/dog8.jpg", JoinDate = DateTime.Now.AddMonths(-4), ReviewCount = 3,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Duke", Type = PetType.Dog, Breed = "Beagle", Age = 6, PhotoUrl = "/images/pets/dog8.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Amanda White", Email = "amanda@email.com", AvatarUrl = "/images/pets/bunny.jpg", JoinDate = DateTime.Now.AddMonths(-9), ReviewCount = 2,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Fluffy", Type = PetType.Rabbit, Breed = "Holland Lop", Age = 2, PhotoUrl = "/images/pets/bunny.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Christopher Lee", Email = "chris@email.com", AvatarUrl = "/images/pets/dog6.png", JoinDate = DateTime.Now.AddMonths(-3), ReviewCount = 5,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Charlie", Type = PetType.Dog, Breed = "Poodle", Age = 3, PhotoUrl = "/images/pets/dog6.png" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Rachel Green", Email = "rachel@email.com", AvatarUrl = "/images/pets/cat3.jpg", JoinDate = DateTime.Now.AddMonths(-11), ReviewCount = 8,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Mittens", Type = PetType.Cat, Breed = "Siamese", Age = 4, PhotoUrl = "/images/pets/cat3.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Thomas Anderson", Email = "thomas@email.com", AvatarUrl = "/images/pets/dog7.jpg", JoinDate = DateTime.Now.AddMonths(-2), ReviewCount = 4,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Buddy", Type = PetType.Dog, Breed = "Husky", Age = 2, PhotoUrl = "/images/pets/dog7.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Lisa Martinez", Email = "lisa@email.com", AvatarUrl = "/images/pets/hedgehog.jpg", JoinDate = DateTime.Now.AddMonths(-6), ReviewCount = 3,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Spike", Type = PetType.Hedgehog, Breed = "African Pygmy", Age = 1, PhotoUrl = "/images/pets/hedgehog.jpg" } }
            },
            new() { Id = Guid.NewGuid(), Name = "Daniel Wilson", Email = "daniel@email.com", AvatarUrl = "/images/pets/dog4.png", JoinDate = DateTime.Now.AddMonths(-5), ReviewCount = 6,
                Pets = new List<Pet> { new() { Id = Guid.NewGuid(), Name = "Cooper", Type = PetType.Dog, Breed = "Corgi", Age = 3, PhotoUrl = "/images/pets/dog4.png" } }
            }
        };
    }
    
    private List<Venue> InitializeVenues()
    {
        var waterBowls = _amenities.First(a => a.Name == "Water Bowls");
        var petMenu = _amenities.First(a => a.Name == "Pet Menu");
        var treats = _amenities.First(a => a.Name == "Treats Available");
        var offLeash = _amenities.First(a => a.Name == "Off-Leash Area");
        var fenced = _amenities.First(a => a.Name == "Fenced Area");
        var waste = _amenities.First(a => a.Name == "Waste Stations");
        var shade = _amenities.First(a => a.Name == "Shade/Shelter");
        var seating = _amenities.First(a => a.Name == "Seating Area");
        var indoor = _amenities.First(a => a.Name == "Indoor Space");
        var outdoor = _amenities.First(a => a.Name == "Outdoor Space");
        
        return new List<Venue>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pawsitive Vibes Cafe",
                Description = "A cozy cafe where you and your furry friend can enjoy artisan coffee and fresh-baked treats. Our outdoor patio is fully pet-friendly with water bowls and a special pet menu!",
                Type = VenueType.Cafe,
                Address = "123 Main Street, Downtown",
                Phone = "(555) 123-4567",
                Email = "hello@pawsitivecafe.com",
                Website = "www.pawsitivecafe.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, treats, seating, outdoor },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-6)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Bark Park Central",
                Description = "A spacious dog park with separate areas for small and large dogs. Features include agility equipment, plenty of shade, and water stations throughout the park.",
                Type = VenueType.Park,
                Address = "456 Park Avenue, North Side",
                Phone = "(555) 234-5678",
                Email = "info@barkpark.com",
                Website = "www.barkparkcentral.com",
                ImageUrl = "/images/venues/park1.jpg",
                Amenities = new List<Amenity> { waterBowls, offLeash, fenced, waste, shade, outdoor },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-8)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pet Paradise Store",
                Description = "Your one-stop shop for all pet supplies! From premium food to fun toys, we have everything your pet needs. Pets are welcome to browse with you!",
                Type = VenueType.Store,
                Address = "789 Commerce Blvd, Shopping District",
                Phone = "(555) 345-6789",
                Email = "shop@petparadise.com",
                Website = "www.petparadisestore.com",
                ImageUrl = "/images/venues/store1.jpg",
                Amenities = new List<Amenity> { waterBowls, treats, indoor, seating },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit, PetType.Bird },
                DateAdded = DateTime.Now.AddMonths(-10)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "The Pampered Pet Hotel",
                Description = "Luxury boarding for your beloved pets. Individual suites, daily playtime, webcam access, and veterinary care on-site. Your pet's home away from home!",
                Type = VenueType.Hotel,
                Address = "321 Luxury Lane, West End",
                Phone = "(555) 456-7890",
                Email = "reservations@pamperedpet.com",
                Website = "www.pamperedpethotel.com",
                ImageUrl = "/images/venues/hotel1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, indoor, outdoor, _amenities.First(a => a.Name == "Grooming Services"), _amenities.First(a => a.Name == "Pet Daycare") },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-12)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tail Waggers Beach",
                Description = "A beautiful sandy beach dedicated to dogs! Let your pup splash in the waves, make new friends, and enjoy the sun. Open year-round with seasonal hours.",
                Type = VenueType.Beach,
                Address = "555 Coastal Highway, Beachfront",
                Phone = "(555) 567-8901",
                Email = "info@tailwaggersbeach.com",
                Website = "www.tailwaggersbeach.com",
                ImageUrl = "/images/venues/park1.jpg",
                Amenities = new List<Amenity> { waterBowls, waste, shade, outdoor, offLeash },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-5)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Whiskers & Wags Restaurant",
                Description = "Fine dining that welcomes your four-legged companions! Enjoy gourmet cuisine on our pet-friendly patio while your pet enjoys our special menu.",
                Type = VenueType.Restaurant,
                Address = "888 Gourmet Street, Arts District",
                Phone = "(555) 678-9012",
                Email = "dine@whiskersandwags.com",
                Website = "www.whiskersandwags.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, treats, seating, outdoor },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-7)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Furry Friends Trail",
                Description = "A scenic 3-mile hiking trail perfect for you and your dog. Well-maintained paths, beautiful views, and plenty of rest stops along the way.",
                Type = VenueType.Trail,
                Address = "1200 Mountain Road, Nature Reserve",
                Phone = "(555) 789-0123",
                Email = "trails@furryfriends.com",
                Website = "www.furryfriendsrail.com",
                ImageUrl = "/images/venues/park1.jpg",
                Amenities = new List<Amenity> { waterBowls, waste, shade, outdoor },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-9)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Paws & Claws Clinic",
                Description = "Comprehensive veterinary care with a focus on preventive medicine. Our caring staff treats your pet like family. Emergency services available.",
                Type = VenueType.Clinic,
                Address = "444 Healthcare Drive, Medical District",
                Phone = "(555) 890-1234",
                Email = "care@pawsandclaws.com",
                Website = "www.pawsandclawsclinic.com",
                ImageUrl = "/images/venues/home1.jpg",
                Amenities = new List<Amenity> { waterBowls, indoor, seating, _amenities.First(a => a.Name == "Veterinary Care") },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit, PetType.Bird, PetType.Hamster, PetType.GuineaPig, PetType.Hedgehog, PetType.Reptile },
                DateAdded = DateTime.Now.AddMonths(-15)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "The Dog House Cafe",
                Description = "A rustic cafe with a large outdoor area perfect for dogs. Serving breakfast and lunch with a side of tail wags!",
                Type = VenueType.Cafe,
                Address = "777 Rustic Road, Countryside",
                Phone = "(555) 901-2345",
                Email = "bark@doghousecafe.com",
                Website = "www.doghousecafe.com",
                ImageUrl = "/images/venues/moochs1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, treats, outdoor, seating },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-4)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Kitty Corner Store",
                Description = "Specializing in everything cats! From premium cat food to the latest toys and furniture. Cat-friendly shopping environment.",
                Type = VenueType.Store,
                Address = "999 Feline Avenue, Cat District",
                Phone = "(555) 012-3456",
                Email = "meow@kittycorner.com",
                Website = "www.kittycornerstore.com",
                ImageUrl = "/images/venues/store1.jpg",
                Amenities = new List<Amenity> { waterBowls, treats, indoor },
                AllowedPets = new List<PetType> { PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-6)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Happy Tails Park",
                Description = "A community favorite! This park features walking paths, picnic areas, and a dedicated small dog section. Perfect for socializing your pup.",
                Type = VenueType.Park,
                Address = "222 Community Way, Suburbs",
                Phone = "(555) 123-7890",
                Email = "info@happytailspark.com",
                Website = "www.happytailspark.com",
                ImageUrl = "/images/venues/park1.jpg",
                Amenities = new List<Amenity> { waterBowls, offLeash, fenced, waste, shade, seating, outdoor },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-11)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cozy Critters Boutique",
                Description = "Unique and stylish accessories for pets of all types. Handmade collars, beds, clothing and more. Supporting local artisans!",
                Type = VenueType.Store,
                Address = "333 Boutique Lane, Fashion District",
                Phone = "(555) 234-8901",
                Email = "shop@cozycritters.com",
                Website = "www.cozycrittersboutique.com",
                ImageUrl = "/images/venues/moochs1.jpg",
                Amenities = new List<Amenity> { waterBowls, treats, indoor, seating },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit },
                DateAdded = DateTime.Now.AddMonths(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Biscuit & Brew",
                Description = "Coffee for you, treats for your pup! A neighborhood cafe with a strong community vibe and delicious homemade dog biscuits.",
                Type = VenueType.Cafe,
                Address = "666 Neighborhood Street, Old Town",
                Phone = "(555) 345-9012",
                Email = "hello@biscuitbrew.com",
                Website = "www.biscuitandbrew.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, treats, outdoor, seating, indoor },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-8)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pet Haven Hotel & Spa",
                Description = "The ultimate luxury experience for your pet! Includes grooming, massage, swimming pool, and 24/7 care. Vacation for your pet while you vacation!",
                Type = VenueType.Hotel,
                Address = "1111 Resort Boulevard, Luxury District",
                Phone = "(555) 456-0123",
                Email = "luxury@pethaven.com",
                Website = "www.pethavenhotelspa.com",
                ImageUrl = "/images/venues/hotel1.jpg",
                Amenities = new List<Amenity> { waterBowls, petMenu, indoor, outdoor, _amenities.First(a => a.Name == "Grooming Services"), _amenities.First(a => a.Name == "Pet Washing Station"), _amenities.First(a => a.Name == "Pet Daycare") },
                AllowedPets = new List<PetType> { PetType.Dog, PetType.Cat },
                DateAdded = DateTime.Now.AddMonths(-14)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Riverside Dog Park",
                Description = "Beautiful riverside location with trails and a dedicated dog park area. Great for swimming, hiking, and socializing. Free parking available.",
                Type = VenueType.Park,
                Address = "888 River Road, Waterfront",
                Phone = "(555) 567-1234",
                Email = "info@riversidepark.com",
                Website = "www.riversidedogpark.com",
                ImageUrl = "/images/venues/park1.jpg",
                Amenities = new List<Amenity> { waterBowls, offLeash, fenced, waste, shade, outdoor, _amenities.First(a => a.Name == "Water Fountain") },
                AllowedPets = new List<PetType> { PetType.Dog },
                DateAdded = DateTime.Now.AddMonths(-7)
            }
        };
    }
    
    private List<Review> InitializeReviews()
    {
        var reviews = new List<Review>();
        var random = new Random(42); // Fixed seed for consistent data
        
        // Pawsitive Vibes Cafe reviews
        var cafe1 = _venues.First(v => v.Name == "Pawsitive Vibes Cafe");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe1.Id,
            UserId = _users[0].Id,
            User = _users[0],
            Rating = 5,
            Title = "Perfect spot for coffee with my pup!",
            Comment = "Max and I come here every weekend. The staff is so friendly and they always bring him fresh water and a treat. The coffee is amazing too! Highly recommend the outdoor patio.",
            PetType = PetType.Dog,
            HelpfulCount = 12,
            DateCreated = DateTime.Now.AddDays(-15)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe1.Id,
            UserId = _users[4].Id,
            User = _users[4],
            Rating = 4,
            Title = "Great atmosphere!",
            Comment = "Luna enjoyed lounging on the patio while I enjoyed a latte. Only wish they had more vegan options.",
            PetType = PetType.Cat,
            HelpfulCount = 8,
            DateCreated = DateTime.Now.AddDays(-22)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe1.Id,
            UserId = _users[7].Id,
            User = _users[7],
            Rating = 5,
            Title = "Charlie's favorite place!",
            Comment = "We've been coming here for months. The pet menu is creative and the pastries are delicious. Love supporting a pet-friendly business!",
            PetType = PetType.Dog,
            HelpfulCount = 15,
            DateCreated = DateTime.Now.AddDays(-30)
        });
        
        // Bark Park Central reviews
        var park1 = _venues.First(v => v.Name == "Bark Park Central");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park1.Id,
            UserId = _users[2].Id,
            User = _users[2],
            Rating = 5,
            Title = "Best dog park in the city!",
            Comment = "Bella absolutely loves it here! The separate areas for different sized dogs is perfect. Always clean and well-maintained with plenty of water stations.",
            PetType = PetType.Dog,
            HelpfulCount = 25,
            DateCreated = DateTime.Now.AddDays(-10)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park1.Id,
            UserId = _users[3].Id,
            User = _users[3],
            Rating = 4,
            Title = "Great socialization for Rocky",
            Comment = "Rocky made so many new friends here! The agility equipment is a nice touch. Gets a bit crowded on weekends though.",
            PetType = PetType.Dog,
            HelpfulCount = 18,
            DateCreated = DateTime.Now.AddDays(-18)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park1.Id,
            UserId = _users[9].Id,
            User = _users[9],
            Rating = 5,
            Title = "Our go-to park!",
            Comment = "Buddy runs here every morning. Great community of dog owners. The fenced area gives me peace of mind.",
            PetType = PetType.Dog,
            HelpfulCount = 20,
            DateCreated = DateTime.Now.AddDays(-5)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park1.Id,
            UserId = _users[11].Id,
            User = _users[11],
            Rating = 5,
            Title = "Cooper's paradise!",
            Comment = "This park has everything! Clean, safe, fun, and plenty of shade. We come here daily. The waste stations everywhere make cleanup easy.",
            PetType = PetType.Dog,
            HelpfulCount = 14,
            DateCreated = DateTime.Now.AddDays(-12)
        });
        
        // Pet Paradise Store reviews
        var store1 = _venues.First(v => v.Name == "Pet Paradise Store");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = store1.Id,
            UserId = _users[1].Id,
            User = _users[1],
            Rating = 5,
            Title = "One-stop shop!",
            Comment = "Found everything I needed for Whiskers. Great selection of toys and the staff is very knowledgeable. Whiskers enjoyed browsing too!",
            PetType = PetType.Cat,
            HelpfulCount = 10,
            DateCreated = DateTime.Now.AddDays(-20)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = store1.Id,
            UserId = _users[6].Id,
            User = _users[6],
            Rating = 4,
            Title = "Great variety for all pets",
            Comment = "They even had supplies for Fluffy! Not many stores cater to rabbits. Prices are reasonable too.",
            PetType = PetType.Rabbit,
            HelpfulCount = 7,
            DateCreated = DateTime.Now.AddDays(-25)
        });
        
        // The Pampered Pet Hotel reviews
        var hotel1 = _venues.First(v => v.Name == "The Pampered Pet Hotel");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = hotel1.Id,
            UserId = _users[0].Id,
            User = _users[0],
            Rating = 5,
            Title = "Max loved his stay!",
            Comment = "Boarded Max here for a week and he was so happy! The webcam feature let me check on him anytime. He came home clean, happy, and well-exercised. Worth every penny!",
            PetType = PetType.Dog,
            HelpfulCount = 22,
            DateCreated = DateTime.Now.AddDays(-35)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = hotel1.Id,
            UserId = _users[4].Id,
            User = _users[4],
            Rating = 5,
            Title = "Luxury accommodations!",
            Comment = "Luna stayed here while we were on vacation. The individual suites are amazing and she got daily playtime. The staff sent us photos every day. Highly recommend!",
            PetType = PetType.Cat,
            HelpfulCount = 19,
            DateCreated = DateTime.Now.AddDays(-40)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = hotel1.Id,
            UserId = _users[7].Id,
            User = _users[7],
            Rating = 4,
            Title = "Great care for Charlie",
            Comment = "Charlie seemed happy when we picked him up. The facilities are top-notch. Only minor issue was a small scheduling mix-up but they handled it professionally.",
            PetType = PetType.Dog,
            HelpfulCount = 11,
            DateCreated = DateTime.Now.AddDays(-28)
        });
        
        // Whiskers & Wags Restaurant reviews
        var restaurant1 = _venues.First(v => v.Name == "Whiskers & Wags Restaurant");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = restaurant1.Id,
            UserId = _users[8].Id,
            User = _users[8],
            Rating = 5,
            Title = "Fine dining with Mittens!",
            Comment = "Never thought I could bring Mittens to a nice restaurant! The food is exquisite and they have a special pet menu. Very accommodating staff.",
            PetType = PetType.Cat,
            HelpfulCount = 16,
            DateCreated = DateTime.Now.AddDays(-8)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = restaurant1.Id,
            UserId = _users[2].Id,
            User = _users[2],
            Rating = 5,
            Title = "Special occasion spot",
            Comment = "Celebrated my birthday here with Bella. The patio is beautiful and the food is restaurant-quality. Bella got her own special meal!",
            PetType = PetType.Dog,
            HelpfulCount = 13,
            DateCreated = DateTime.Now.AddDays(-14)
        });
        
        // The Dog House Cafe reviews
        var cafe2 = _venues.First(v => v.Name == "The Dog House Cafe");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe2.Id,
            UserId = _users[5].Id,
            User = _users[5],
            Rating = 5,
            Title = "Rustic charm with great food",
            Comment = "Duke and I stop here after our morning walks. The outdoor area is huge and the breakfast is delicious. Great prices too!",
            PetType = PetType.Dog,
            HelpfulCount = 9,
            DateCreated = DateTime.Now.AddDays(-6)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe2.Id,
            UserId = _users[11].Id,
            User = _users[11],
            Rating = 4,
            Title = "Cozy and welcoming",
            Comment = "Cooper loves the spacious outdoor area. Food is good, service is friendly. Can get busy on weekends.",
            PetType = PetType.Dog,
            HelpfulCount = 7,
            DateCreated = DateTime.Now.AddDays(-11)
        });
        
        // Happy Tails Park reviews
        var park2 = _venues.First(v => v.Name == "Happy Tails Park");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park2.Id,
            UserId = _users[9].Id,
            User = _users[9],
            Rating = 5,
            Title = "Community favorite for a reason!",
            Comment = "Buddy has made lifelong friends here! The small dog section is great for puppies. Picnic areas are perfect for family outings.",
            PetType = PetType.Dog,
            HelpfulCount = 17,
            DateCreated = DateTime.Now.AddDays(-19)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park2.Id,
            UserId = _users[3].Id,
            User = _users[3],
            Rating = 5,
            Title = "Well-maintained and clean",
            Comment = "Rocky loves the walking paths. The park is always clean and there are waste stations everywhere. Great place for dogs of all sizes!",
            PetType = PetType.Dog,
            HelpfulCount = 15,
            DateCreated = DateTime.Now.AddDays(-24)
        });
        
        // Biscuit & Brew reviews
        var cafe3 = _venues.First(v => v.Name == "Biscuit & Brew");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe3.Id,
            UserId = _users[0].Id,
            User = _users[0],
            Rating = 5,
            Title = "Best homemade dog biscuits!",
            Comment = "Max goes crazy for their homemade biscuits! Great coffee, friendly staff, and a real neighborhood vibe. This is our second home.",
            PetType = PetType.Dog,
            HelpfulCount = 21,
            DateCreated = DateTime.Now.AddDays(-7)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = cafe3.Id,
            UserId = _users[1].Id,
            User = _users[1],
            Rating = 4,
            Title = "Good coffee and cat-friendly!",
            Comment = "Whiskers enjoyed sitting on my lap while I had coffee. Not many places welcome cats. The indoor seating is a nice option when it's cold.",
            PetType = PetType.Cat,
            HelpfulCount = 9,
            DateCreated = DateTime.Now.AddDays(-16)
        });
        
        // Riverside Dog Park reviews
        var park3 = _venues.First(v => v.Name == "Riverside Dog Park");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park3.Id,
            UserId = _users[2].Id,
            User = _users[2],
            Rating = 5,
            Title = "Swimming paradise!",
            Comment = "Bella loves swimming here! The riverside location is beautiful and there are great trails too. Perfect for active dogs.",
            PetType = PetType.Dog,
            HelpfulCount = 23,
            DateCreated = DateTime.Now.AddDays(-9)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = park3.Id,
            UserId = _users[7].Id,
            User = _users[7],
            Rating = 5,
            Title = "Scenic and fun!",
            Comment = "Charlie and I hike the trails every weekend. The views are amazing and the dog park area is well-designed. Free parking is a bonus!",
            PetType = PetType.Dog,
            HelpfulCount = 18,
            DateCreated = DateTime.Now.AddDays(-13)
        });
        
        // Pet Haven Hotel & Spa reviews
        var hotel2 = _venues.First(v => v.Name == "Pet Haven Hotel & Spa");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = hotel2.Id,
            UserId = _users[4].Id,
            User = _users[4],
            Rating = 5,
            Title = "Ultimate luxury for Luna!",
            Comment = "Luna got the full spa treatment - grooming, massage, and swimming! She came home looking and feeling amazing. This place is incredible!",
            PetType = PetType.Cat,
            HelpfulCount = 26,
            DateCreated = DateTime.Now.AddDays(-21)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = hotel2.Id,
            UserId = _users[11].Id,
            User = _users[11],
            Rating = 5,
            Title = "Worth every penny!",
            Comment = "Cooper had the time of his life! The 24/7 care and webcam access gave me peace of mind. He didn't even want to leave!",
            PetType = PetType.Dog,
            HelpfulCount = 24,
            DateCreated = DateTime.Now.AddDays(-27)
        });
        
        // Furry Friends Trail reviews
        var trail1 = _venues.First(v => v.Name == "Furry Friends Trail");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = trail1.Id,
            UserId = _users[9].Id,
            User = _users[9],
            Rating = 4,
            Title = "Great hiking trail",
            Comment = "The 3-mile trail is perfect for Buddy. Well-maintained with beautiful views. Bring water for longer hikes!",
            PetType = PetType.Dog,
            HelpfulCount = 12,
            DateCreated = DateTime.Now.AddDays(-17)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = trail1.Id,
            UserId = _users[3].Id,
            User = _users[3],
            Rating = 5,
            Title = "Rocky's favorite trail!",
            Comment = "We hike this trail twice a week. The scenery is gorgeous and there are plenty of rest stops. Perfect for dogs who love adventure!",
            PetType = PetType.Dog,
            HelpfulCount = 14,
            DateCreated = DateTime.Now.AddDays(-23)
        });
        
        // Paws & Claws Clinic reviews
        var clinic1 = _venues.First(v => v.Name == "Paws & Claws Clinic");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = clinic1.Id,
            UserId = _users[10].Id,
            User = _users[10],
            Rating = 5,
            Title = "Excellent care for Spike!",
            Comment = "Finding a vet that knows about hedgehogs is hard! Dr. Smith is amazing and the staff is so caring. They treat Spike like family.",
            PetType = PetType.Hedgehog,
            HelpfulCount = 15,
            DateCreated = DateTime.Now.AddDays(-26)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = clinic1.Id,
            UserId = _users[1].Id,
            User = _users[1],
            Rating = 5,
            Title = "Trust them completely",
            Comment = "Whiskers has been a patient here for 2 years. They've handled everything from routine checkups to emergencies. Highly recommend!",
            PetType = PetType.Cat,
            HelpfulCount = 19,
            DateCreated = DateTime.Now.AddDays(-31)
        });
        
        // Kitty Corner Store reviews
        var store2 = _venues.First(v => v.Name == "Kitty Corner Store");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = store2.Id,
            UserId = _users[8].Id,
            User = _users[8],
            Rating = 5,
            Title = "Cat heaven!",
            Comment = "Mittens and I love browsing here. They have everything a cat could want - premium food, unique toys, amazing furniture. Staff knows their stuff!",
            PetType = PetType.Cat,
            HelpfulCount = 11,
            DateCreated = DateTime.Now.AddDays(-29)
        });
        
        // Cozy Critters Boutique reviews
        var store3 = _venues.First(v => v.Name == "Cozy Critters Boutique");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = store3.Id,
            UserId = _users[6].Id,
            User = _users[6],
            Rating = 5,
            Title = "Unique handmade items!",
            Comment = "Found the most adorable handmade collar for Fluffy! Supporting local artisans and my bunny looks fabulous. Will definitely be back!",
            PetType = PetType.Rabbit,
            HelpfulCount = 8,
            DateCreated = DateTime.Now.AddDays(-4)
        });
        
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = store3.Id,
            UserId = _users[11].Id,
            User = _users[11],
            Rating = 4,
            Title = "Stylish accessories",
            Comment = "Cooper's new bed is so cozy and stylish! A bit pricey but the quality is excellent. Great selection for fashion-forward pets.",
            PetType = PetType.Dog,
            HelpfulCount = 6,
            DateCreated = DateTime.Now.AddDays(-32)
        });
        
        // Tail Waggers Beach reviews
        var beach1 = _venues.First(v => v.Name == "Tail Waggers Beach");
        reviews.Add(new Review
        {
            Id = Guid.NewGuid(),
            VenueId = beach1.Id,
            UserId = _users[2].Id,
            User = _users[2],
            Rating = 5,
            Title = "Beach day with Bella!",
            Comment = "Bella absolutely loves this beach! She played in the waves for hours and made so many friends. Can't wait to come back!",
            PetType = PetType.Dog,
            HelpfulCount = 20,
            DateCreated = DateTime.Now.AddDays(-3)
        });
        
        return reviews;
    }
}
