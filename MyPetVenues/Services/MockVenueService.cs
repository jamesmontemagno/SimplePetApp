using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockVenueService : IVenueService
{
    private readonly List<Venue> _venues;
    private int _nextVenueId;
    private int _nextReviewId;

    public MockVenueService()
    {
        _nextVenueId = 16;
        _nextReviewId = 50;
        _venues = InitializeVenues();
    }

    private List<Venue> InitializeVenues()
    {
        return new List<Venue>
        {
            new Venue
            {
                Id = 1,
                Name = "Pawsitive Cafe",
                Category = VenueCategory.Cafe,
                Location = "123 Bark Street, Downtown",
                Description = "A cozy cafe where you can enjoy artisan coffee while your furry friend relaxes by your side. We offer a special pet menu with treats and refreshments for dogs and cats!",
                Phone = "(555) 123-4567",
                Website = "https://pawsitivecafe.example.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats },
                Amenities = new List<Amenity> { Amenity.WaterBowls, Amenity.OutdoorSeating, Amenity.PetMenu, Amenity.Treats, Amenity.Shade },
                CreatedDate = DateTime.Now.AddMonths(-6),
                Reviews = new List<Review>
                {
                    new Review { Id = 1, VenueId = 1, ReviewerName = "Sarah M.", Rating = 5, Comment = "Absolutely love this place! My golden retriever Max always gets excited when we pull up. The staff is so friendly and they have the best pup-cakes!", ReviewDate = DateTime.Now.AddDays(-15) },
                    new Review { Id = 2, VenueId = 1, ReviewerName = "Mike T.", Rating = 5, Comment = "Great atmosphere and my cat Luna actually enjoyed it. They have comfy cushions for pets and the outdoor seating is perfect.", ReviewDate = DateTime.Now.AddDays(-8) },
                    new Review { Id = 3, VenueId = 1, ReviewerName = "Emma L.", Rating = 4, Comment = "Nice cafe, good coffee. Can get a bit crowded on weekends but overall a great experience with my pup.", ReviewDate = DateTime.Now.AddDays(-3) }
                }
            },
            new Venue
            {
                Id = 2,
                Name = "Bark Park Central",
                Category = VenueCategory.Park,
                Location = "456 Green Avenue, Central Park",
                Description = "A spacious park with dedicated off-leash areas for dogs of all sizes. Features include agility equipment, shaded seating areas, and water stations throughout the park.",
                Phone = "(555) 234-5678",
                ImageUrl = "/images/venues/park1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs },
                Amenities = new List<Amenity> { Amenity.OffLeashArea, Amenity.WasteBags, Amenity.WaterBowls, Amenity.Outdoor, Amenity.Shade, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-12),
                Reviews = new List<Review>
                {
                    new Review { Id = 4, VenueId = 2, ReviewerName = "David K.", Rating = 5, Comment = "Best dog park in the city! Well-maintained, plenty of space, and the community here is wonderful. My husky loves running around with new friends!", ReviewDate = DateTime.Now.AddDays(-20) },
                    new Review { Id = 5, VenueId = 2, ReviewerName = "Jennifer R.", Rating = 5, Comment = "Clean, safe, and so much fun for dogs! The separate areas for small and large dogs is a great feature.", ReviewDate = DateTime.Now.AddDays(-12) },
                    new Review { Id = 6, VenueId = 2, ReviewerName = "Alex P.", Rating = 4, Comment = "Great park, wish there were more benches for owners, but overall excellent experience.", ReviewDate = DateTime.Now.AddDays(-5) }
                }
            },
            new Venue
            {
                Id = 3,
                Name = "The Pet Palace Hotel",
                Category = VenueCategory.Hotel,
                Location = "789 Luxury Lane, Uptown",
                Description = "Luxury accommodations for you and your pets! We welcome all well-behaved animals with special amenities including pet beds, food bowls, and a concierge service for pet needs.",
                Phone = "(555) 345-6789",
                Website = "https://petpalacehotel.example.com",
                ImageUrl = "/images/venues/hotel1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.SmallAnimals },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.WaterBowls, Amenity.Treats, Amenity.Parking, Amenity.PetWashStation },
                CreatedDate = DateTime.Now.AddMonths(-18),
                Reviews = new List<Review>
                {
                    new Review { Id = 7, VenueId = 3, ReviewerName = "Patricia W.", Rating = 5, Comment = "Stayed here with my cat Whiskers during a business trip. The staff went above and beyond to make us both comfortable. Highly recommend!", ReviewDate = DateTime.Now.AddDays(-30) },
                    new Review { Id = 8, VenueId = 3, ReviewerName = "Robert H.", Rating = 4, Comment = "Very pet-friendly hotel with great amenities. A bit pricey but worth it for the peace of mind.", ReviewDate = DateTime.Now.AddDays(-18) }
                }
            },
            new Venue
            {
                Id = 4,
                Name = "Furry Friends Pet Store",
                Category = VenueCategory.Store,
                Location = "321 Commerce Street, Shopping District",
                Description = "Your one-stop shop for all pet needs! Bring your pets while you shop for toys, food, and accessories. We offer treats for visiting pets and knowledgeable staff to help you choose the best products.",
                Phone = "(555) 456-7890",
                Website = "https://furryfriendspets.example.com",
                ImageUrl = "/images/venues/store1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.Birds, PetType.SmallAnimals, PetType.Reptiles },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.WaterBowls, Amenity.Treats, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-24),
                Reviews = new List<Review>
                {
                    new Review { Id = 9, VenueId = 4, ReviewerName = "Lisa M.", Rating = 5, Comment = "Love shopping here with my bunny! They have such a great selection and the staff is always helpful.", ReviewDate = DateTime.Now.AddDays(-10) },
                    new Review { Id = 10, VenueId = 4, ReviewerName = "Tom S.", Rating = 5, Comment = "Best pet store around! My parrot loves the attention from the staff.", ReviewDate = DateTime.Now.AddDays(-6) }
                }
            },
            new Venue
            {
                Id = 5,
                Name = "Coastal Paws Beach",
                Category = VenueCategory.Park,
                Location = "Beach Road, Coastal Area",
                Description = "A beautiful beach area where dogs can run, swim, and play in the sand! Open dawn to dusk with plenty of space for exercise and socialization.",
                Phone = "(555) 567-8901",
                ImageUrl = "/images/venues/park1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs },
                Amenities = new List<Amenity> { Amenity.Outdoor, Amenity.OffLeashArea, Amenity.WaterBowls, Amenity.WasteBags, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-8),
                Reviews = new List<Review>
                {
                    new Review { Id = 11, VenueId = 5, ReviewerName = "Amanda B.", Rating = 5, Comment = "My lab absolutely LOVES this beach! She swims for hours. Best place ever!", ReviewDate = DateTime.Now.AddDays(-7) },
                    new Review { Id = 12, VenueId = 5, ReviewerName = "Chris D.", Rating = 4, Comment = "Great beach for dogs. Gets busy on weekends but there's plenty of space.", ReviewDate = DateTime.Now.AddDays(-4) }
                }
            },
            new Venue
            {
                Id = 6,
                Name = "Meow & Chow Restaurant",
                Category = VenueCategory.Restaurant,
                Location = "555 Dining Plaza, Food District",
                Description = "Fine dining that welcomes your feline and canine friends! Our outdoor patio is pet-friendly and we offer a gourmet pet menu alongside our regular menu.",
                Phone = "(555) 678-9012",
                Website = "https://meowandchow.example.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats },
                Amenities = new List<Amenity> { Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.PetMenu, Amenity.Treats, Amenity.Shade, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-10),
                Reviews = new List<Review>
                {
                    new Review { Id = 13, VenueId = 6, ReviewerName = "Nicole F.", Rating = 5, Comment = "Fantastic food and my dog got his own meal! The service is impeccable.", ReviewDate = DateTime.Now.AddDays(-14) },
                    new Review { Id = 14, VenueId = 6, ReviewerName = "Kevin J.", Rating = 5, Comment = "Brought my cat here and she actually behaved! The atmosphere is calm and welcoming.", ReviewDate = DateTime.Now.AddDays(-9) }
                }
            },
            new Venue
            {
                Id = 7,
                Name = "Happy Tails Veterinary Clinic",
                Category = VenueCategory.Veterinary,
                Location = "777 Health Street, Medical District",
                Description = "Comprehensive veterinary care for all types of pets. Our caring staff and modern facilities ensure your pet gets the best medical attention. Emergency services available 24/7.",
                Phone = "(555) 789-0123",
                Website = "https://happytailsvet.example.com",
                ImageUrl = "/images/venues/home1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.Birds, PetType.SmallAnimals, PetType.Reptiles },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.WaterBowls, Amenity.Parking, Amenity.Treats },
                CreatedDate = DateTime.Now.AddMonths(-36),
                Reviews = new List<Review>
                {
                    new Review { Id = 15, VenueId = 7, ReviewerName = "Karen W.", Rating = 5, Comment = "Dr. Smith saved my cat's life! The entire team is compassionate and knowledgeable.", ReviewDate = DateTime.Now.AddDays(-25) },
                    new Review { Id = 16, VenueId = 7, ReviewerName = "Steven L.", Rating = 5, Comment = "Best vet in town. They truly care about animals.", ReviewDate = DateTime.Now.AddDays(-11) }
                }
            },
            new Venue
            {
                Id = 8,
                Name = "Pampered Paws Grooming",
                Category = VenueCategory.Grooming,
                Location = "888 Beauty Boulevard, Spa District",
                Description = "Professional grooming services for dogs and cats. From basic baths to full spa treatments, we make your pets look and feel their best!",
                Phone = "(555) 890-1234",
                Website = "https://pamperedpawsgrooming.example.com",
                ImageUrl = "/images/venues/store1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.WaterBowls, Amenity.PetWashStation, Amenity.Treats, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-15),
                Reviews = new List<Review>
                {
                    new Review { Id = 17, VenueId = 8, ReviewerName = "Diana R.", Rating = 5, Comment = "My poodle always looks amazing after visiting! The groomers are skilled and gentle.", ReviewDate = DateTime.Now.AddDays(-13) },
                    new Review { Id = 18, VenueId = 8, ReviewerName = "Mark T.", Rating = 4, Comment = "Good grooming service, a bit expensive but quality work.", ReviewDate = DateTime.Now.AddDays(-8) }
                }
            },
            new Venue
            {
                Id = 9,
                Name = "Urban Trail Dog Park",
                Category = VenueCategory.Park,
                Location = "999 Trail Head Road, North Side",
                Description = "A scenic trail park perfect for hiking with your dog. Miles of trails through wooded areas with streams and scenic overlooks. Leash required but lots of space to explore!",
                Phone = "(555) 901-2345",
                ImageUrl = "/images/venues/park1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs },
                Amenities = new List<Amenity> { Amenity.Outdoor, Amenity.WasteBags, Amenity.WaterBowls, Amenity.Shade, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-20),
                Reviews = new List<Review>
                {
                    new Review { Id = 19, VenueId = 9, ReviewerName = "Brian K.", Rating = 5, Comment = "Beautiful trails! My German Shepherd loves the workout. Great for active dogs.", ReviewDate = DateTime.Now.AddDays(-16) },
                    new Review { Id = 20, VenueId = 9, ReviewerName = "Michelle A.", Rating = 5, Comment = "Peaceful and well-maintained. Perfect for morning walks with my beagle.", ReviewDate = DateTime.Now.AddDays(-12) }
                }
            },
            new Venue
            {
                Id = 10,
                Name = "Whiskers & Wags Cafe",
                Category = VenueCategory.Cafe,
                Location = "1010 Cozy Corner, Old Town",
                Description = "A charming neighborhood cafe with a pet-friendly patio. Enjoy homemade pastries and specialty coffee while your pet lounges beside you. Board games and books available!",
                Phone = "(555) 012-3456",
                Website = "https://whiskersandwags.example.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats },
                Amenities = new List<Amenity> { Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.Treats, Amenity.Shade },
                CreatedDate = DateTime.Now.AddMonths(-7),
                Reviews = new List<Review>
                {
                    new Review { Id = 21, VenueId = 10, ReviewerName = "Rachel S.", Rating = 5, Comment = "Such a cute and cozy place! The staff loves animals and the pastries are delicious.", ReviewDate = DateTime.Now.AddDays(-19) },
                    new Review { Id = 22, VenueId = 10, ReviewerName = "Jason M.", Rating = 4, Comment = "Nice atmosphere, good coffee. My dog enjoyed relaxing on the patio.", ReviewDate = DateTime.Now.AddDays(-6) }
                }
            },
            new Venue
            {
                Id = 11,
                Name = "Pet Haven Hotel & Spa",
                Category = VenueCategory.Hotel,
                Location = "1111 Vacation Drive, Resort Area",
                Description = "A luxury pet-friendly resort where both you and your pets can relax! Features pet spa services, grooming, and special play areas. All pets welcome!",
                Phone = "(555) 123-7890",
                Website = "https://pethavenhotel.example.com",
                ImageUrl = "/images/venues/hotel1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.Birds, PetType.SmallAnimals },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.Outdoor, Amenity.WaterBowls, Amenity.Treats, Amenity.PetWashStation, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-14),
                Reviews = new List<Review>
                {
                    new Review { Id = 23, VenueId = 11, ReviewerName = "Elizabeth H.", Rating = 5, Comment = "Absolutely wonderful! My cat and I had the best vacation. The spa services for pets are amazing!", ReviewDate = DateTime.Now.AddDays(-28) },
                    new Review { Id = 24, VenueId = 11, ReviewerName = "Daniel C.", Rating = 5, Comment = "Worth every penny! My rabbit was treated like royalty.", ReviewDate = DateTime.Now.AddDays(-21) }
                }
            },
            new Venue
            {
                Id = 12,
                Name = "Mooch's Pet Emporium",
                Category = VenueCategory.Store,
                Location = "1212 Market Street, Downtown",
                Description = "A unique pet store offering exotic pet supplies, custom pet furniture, and artisanal pet foods. All pets welcome to browse with you!",
                Phone = "(555) 234-8901",
                Website = "https://moochspets.example.com",
                ImageUrl = "/images/venues/moochs1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.Birds, PetType.SmallAnimals, PetType.Reptiles },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.WaterBowls, Amenity.Treats, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-22),
                Reviews = new List<Review>
                {
                    new Review { Id = 25, VenueId = 12, ReviewerName = "Sophia G.", Rating = 5, Comment = "Love this store! They have everything for my hedgehog and the staff is super knowledgeable.", ReviewDate = DateTime.Now.AddDays(-17) },
                    new Review { Id = 26, VenueId = 12, ReviewerName = "William B.", Rating = 5, Comment = "Great selection of unique items. My parrot loves coming here!", ReviewDate = DateTime.Now.AddDays(-9) }
                }
            },
            new Venue
            {
                Id = 13,
                Name = "Sunset Bistro & Bar",
                Category = VenueCategory.Restaurant,
                Location = "1313 Waterfront Drive, Marina",
                Description = "Upscale dining with stunning sunset views and a pet-friendly patio. Our chef prepares special meals for four-legged guests upon request.",
                Phone = "(555) 345-9012",
                Website = "https://sunsetbistro.example.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats },
                Amenities = new List<Amenity> { Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.PetMenu, Amenity.Treats, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-9),
                Reviews = new List<Review>
                {
                    new Review { Id = 27, VenueId = 13, ReviewerName = "Olivia N.", Rating = 5, Comment = "Romantic dinner spot that welcomes my Chihuahua! Food is excellent and the view is breathtaking.", ReviewDate = DateTime.Now.AddDays(-22) },
                    new Review { Id = 28, VenueId = 13, ReviewerName = "James P.", Rating = 5, Comment = "Best restaurant experience with my pet. Highly recommended!", ReviewDate = DateTime.Now.AddDays(-15) }
                }
            },
            new Venue
            {
                Id = 14,
                Name = "Paws & Claws Community Center",
                Category = VenueCategory.Home,
                Location = "1414 Community Lane, Suburbs",
                Description = "A community center dedicated to pet owners! Host meetups, training classes, adoption events, and pet birthday parties. Indoor and outdoor spaces available for rent.",
                Phone = "(555) 456-0123",
                Website = "https://pawsandclawscenter.example.com",
                ImageUrl = "/images/venues/home1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs, PetType.Cats, PetType.Rabbits, PetType.SmallAnimals },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.Outdoor, Amenity.WaterBowls, Amenity.Treats, Amenity.Parking, Amenity.Shade },
                CreatedDate = DateTime.Now.AddMonths(-11),
                Reviews = new List<Review>
                {
                    new Review { Id = 29, VenueId = 14, ReviewerName = "Angela T.", Rating = 5, Comment = "Hosted my dog's birthday party here! The staff helped make it special. Great facilities!", ReviewDate = DateTime.Now.AddDays(-26) },
                    new Review { Id = 30, VenueId = 14, ReviewerName = "Ryan F.", Rating = 4, Comment = "Good community center with lots of activities for pets. Could use more outdoor space.", ReviewDate = DateTime.Now.AddDays(-14) }
                }
            },
            new Venue
            {
                Id = 15,
                Name = "The Wagging Tail Pub",
                Category = VenueCategory.Restaurant,
                Location = "1515 Pub Street, Entertainment District",
                Description = "A lively pub atmosphere where dogs are part of the family! Enjoy craft beers, pub food, and live music on weekends. Dog-friendly menu available.",
                Phone = "(555) 567-1234",
                Website = "https://waggintailpub.example.com",
                ImageUrl = "/images/venues/cafe1.jpg",
                PetTypesAllowed = new List<PetType> { PetType.Dogs },
                Amenities = new List<Amenity> { Amenity.Indoor, Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.PetMenu, Amenity.Treats, Amenity.Parking },
                CreatedDate = DateTime.Now.AddMonths(-5),
                Reviews = new List<Review>
                {
                    new Review { Id = 31, VenueId = 15, ReviewerName = "Tyler J.", Rating = 5, Comment = "Great vibe! My dog loves the attention from other patrons. Food and beer are top-notch!", ReviewDate = DateTime.Now.AddDays(-11) },
                    new Review { Id = 32, VenueId = 15, ReviewerName = "Melissa K.", Rating = 5, Comment = "Fun place to hang out with my pup! The live music nights are awesome.", ReviewDate = DateTime.Now.AddDays(-5) }
                }
            }
        };
    }

    public Task<List<Venue>> GetAllVenuesAsync()
    {
        return Task.FromResult(_venues.OrderByDescending(v => v.CreatedDate).ToList());
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == id);
        return Task.FromResult(venue);
    }

    public Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueCategory? category, PetType? petType)
    {
        var query = _venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(v =>
                v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Location.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        if (category.HasValue)
        {
            query = query.Where(v => v.Category == category.Value);
        }

        if (petType.HasValue)
        {
            query = query.Where(v => v.PetTypesAllowed.Contains(petType.Value));
        }

        return Task.FromResult(query.OrderByDescending(v => v.AverageRating).ToList());
    }

    public Task<Venue> AddVenueAsync(Venue venue)
    {
        venue.Id = _nextVenueId++;
        venue.CreatedDate = DateTime.Now;
        venue.Reviews = new List<Review>();
        _venues.Add(venue);
        return Task.FromResult(venue);
    }

    public Task<Review> AddReviewAsync(int venueId, Review review)
    {
        var venue = _venues.FirstOrDefault(v => v.Id == venueId);
        if (venue == null)
        {
            throw new ArgumentException("Venue not found", nameof(venueId));
        }

        review.Id = _nextReviewId++;
        review.VenueId = venueId;
        review.ReviewDate = DateTime.Now;
        venue.Reviews.Add(review);
        
        return Task.FromResult(review);
    }
}
