using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockVenueService : IVenueService, IReviewService
{
    private readonly List<Venue> _venues;
    private readonly List<Review> _reviews;
    private int _nextVenueId = 11;
    private int _nextReviewId = 31;

    public MockVenueService()
    {
        _venues = InitializeVenues();
        _reviews = InitializeReviews();
    }

    private List<Venue> InitializeVenues()
    {
        return new List<Venue>
        {
            new Venue
            {
                Id = 1,
                Name = "Pawsome Park",
                Description = "A beautiful 20-acre dog park featuring separate areas for large and small dogs, agility equipment, and plenty of shade trees. Perfect for socializing your furry friend!",
                Type = VenueType.Park,
                Address = "123 Bark Avenue",
                City = "San Francisco",
                State = "CA",
                ZipCode = "94102",
                Phone = "(415) 555-BARK",
                Website = "https://pawsomepark.example.com",
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog },
                Amenities = new List<Amenity> { Amenity.FencedArea, Amenity.OffLeashAllowed, Amenity.WaterBowls, Amenity.WasteStations, Amenity.ShadedAreas, Amenity.PlayArea, Amenity.DogPark },
                OperatingHours = "Daily: 6:00 AM - 10:00 PM",
                AverageRating = 4.8m,
                ReviewCount = 156,
                DateAdded = DateTime.Now.AddMonths(-8)
            },
            new Venue
            {
                Id = 2,
                Name = "The Barking Bean Café",
                Description = "A cozy coffee shop where you can enjoy artisan coffee and pastries with your well-behaved pup. We have a special doggy menu too!",
                Type = VenueType.Cafe,
                Address = "456 Woof Street",
                City = "Seattle",
                State = "WA",
                ZipCode = "98101",
                Phone = "(206) 555-CAFE",
                Website = "https://barkingbean.example.com",
                ImageUrl = "images/venues/cafe1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat },
                Amenities = new List<Amenity> { Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.TreatBar, Amenity.PetMenu, Amenity.AirConditioned },
                OperatingHours = "Mon-Fri: 7:00 AM - 7:00 PM, Sat-Sun: 8:00 AM - 8:00 PM",
                AverageRating = 4.6m,
                ReviewCount = 89,
                DateAdded = DateTime.Now.AddMonths(-6)
            },
            new Venue
            {
                Id = 3,
                Name = "Paws & Relax Hotel",
                Description = "Luxury pet-friendly accommodations where your furry family members are treated like royalty. Includes pet sitting, grooming services, and a special pet room service menu.",
                Type = VenueType.Hotel,
                Address = "789 Cuddle Lane",
                City = "Portland",
                State = "OR",
                ZipCode = "97201",
                Phone = "(503) 555-STAY",
                Website = "https://pawsrelax.example.com",
                ImageUrl = "images/venues/hotel1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Bird, PetType.SmallMammal },
                Amenities = new List<Amenity> { Amenity.AirConditioned, Amenity.PetMenu, Amenity.GroomingServices, Amenity.BoardingAvailable, Amenity.PlayArea, Amenity.WaterBowls },
                OperatingHours = "24/7 Front Desk",
                AverageRating = 4.9m,
                ReviewCount = 234,
                DateAdded = DateTime.Now.AddMonths(-12)
            },
            new Venue
            {
                Id = 4,
                Name = "Whiskers & Wags Pet Store",
                Description = "Your one-stop shop for all pet supplies! From premium food to toys, accessories, and everything in between. Pets welcome to help choose their favorites!",
                Type = VenueType.Store,
                Address = "321 Treats Boulevard",
                City = "Austin",
                State = "TX",
                ZipCode = "78701",
                Phone = "(512) 555-PETS",
                Website = "https://whiskersandwags.example.com",
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Bird, PetType.Rabbit, PetType.Reptile, PetType.Fish, PetType.SmallMammal },
                Amenities = new List<Amenity> { Amenity.PetSupplies, Amenity.TreatBar, Amenity.AirConditioned, Amenity.ParkingAvailable, Amenity.WheelchairAccessible },
                OperatingHours = "Mon-Sat: 9:00 AM - 9:00 PM, Sun: 10:00 AM - 6:00 PM",
                AverageRating = 4.5m,
                ReviewCount = 67,
                DateAdded = DateTime.Now.AddMonths(-4)
            },
            new Venue
            {
                Id = 5,
                Name = "Mooch's Backyard Haven",
                Description = "A private backyard rental perfect for pet parties, training sessions, or just a safe space for your pet to run free. Fully fenced with agility equipment available.",
                Type = VenueType.Home,
                Address = "555 Private Place",
                City = "Denver",
                State = "CO",
                ZipCode = "80202",
                Phone = "(303) 555-PLAY",
                Website = "https://moochsbackyard.example.com",
                ImageUrl = "images/venues/moochs1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Rabbit },
                Amenities = new List<Amenity> { Amenity.FencedArea, Amenity.OffLeashAllowed, Amenity.PlayArea, Amenity.ShadedAreas, Amenity.WaterBowls, Amenity.ParkingAvailable },
                OperatingHours = "By Reservation: 8:00 AM - 8:00 PM",
                AverageRating = 4.7m,
                ReviewCount = 45,
                DateAdded = DateTime.Now.AddMonths(-3)
            },
            new Venue
            {
                Id = 6,
                Name = "Sunny Paws Beach",
                Description = "The only dog-friendly beach in the area! Miles of sandy shores where your pup can splash, play fetch, and make new friends. Lifeguard on duty during summer months.",
                Type = VenueType.Beach,
                Address = "Ocean Drive",
                City = "San Diego",
                State = "CA",
                ZipCode = "92101",
                Phone = "(619) 555-WAVE",
                Website = "https://sunnypawsbeach.example.com",
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog },
                Amenities = new List<Amenity> { Amenity.OffLeashAllowed, Amenity.WasteStations, Amenity.WaterBowls, Amenity.PetWashStation, Amenity.ParkingAvailable },
                OperatingHours = "Sunrise to Sunset",
                AverageRating = 4.4m,
                ReviewCount = 198,
                DateAdded = DateTime.Now.AddMonths(-10)
            },
            new Venue
            {
                Id = 7,
                Name = "Tail Waggers Trail",
                Description = "A scenic 5-mile hiking trail through beautiful forest, perfect for adventurous dogs and their owners. Multiple difficulty levels available.",
                Type = VenueType.Trail,
                Address = "Mountain View Road",
                City = "Boulder",
                State = "CO",
                ZipCode = "80301",
                Phone = "(303) 555-HIKE",
                Website = "https://tailwaggerstrail.example.com",
                ImageUrl = "images/venues/park1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog },
                Amenities = new List<Amenity> { Amenity.WasteStations, Amenity.ShadedAreas, Amenity.ParkingAvailable },
                OperatingHours = "Daily: Dawn to Dusk",
                AverageRating = 4.6m,
                ReviewCount = 112,
                DateAdded = DateTime.Now.AddMonths(-7)
            },
            new Venue
            {
                Id = 8,
                Name = "Happy Tails Veterinary Clinic",
                Description = "Compassionate veterinary care for all your pets. From routine checkups to emergency services, our experienced team is here for your furry family.",
                Type = VenueType.Veterinary,
                Address = "888 Health Way",
                City = "Phoenix",
                State = "AZ",
                ZipCode = "85001",
                Phone = "(602) 555-VETS",
                Website = "https://happytailsvet.example.com",
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat, PetType.Bird, PetType.Rabbit, PetType.Reptile, PetType.SmallMammal },
                Amenities = new List<Amenity> { Amenity.AirConditioned, Amenity.ParkingAvailable, Amenity.WheelchairAccessible, Amenity.CatRoom },
                OperatingHours = "Mon-Fri: 8:00 AM - 6:00 PM, Sat: 9:00 AM - 2:00 PM, Emergency: 24/7",
                AverageRating = 4.8m,
                ReviewCount = 289,
                DateAdded = DateTime.Now.AddMonths(-14)
            },
            new Venue
            {
                Id = 9,
                Name = "Fluffy's Grooming Spa",
                Description = "Pamper your pet with our premium grooming services. From basic baths to full spa treatments, we'll have your pet looking and feeling fabulous!",
                Type = VenueType.Grooming,
                Address = "234 Glamour Street",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90001",
                Phone = "(213) 555-GROOM",
                Website = "https://fluffysspa.example.com",
                ImageUrl = "images/venues/store1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog, PetType.Cat },
                Amenities = new List<Amenity> { Amenity.GroomingServices, Amenity.PetWashStation, Amenity.AirConditioned, Amenity.TreatBar, Amenity.ParkingAvailable },
                OperatingHours = "Tue-Sat: 9:00 AM - 6:00 PM",
                AverageRating = 4.7m,
                ReviewCount = 178,
                DateAdded = DateTime.Now.AddMonths(-9)
            },
            new Venue
            {
                Id = 10,
                Name = "The Puppy Pub & Grill",
                Description = "A family-friendly restaurant with a spacious dog-friendly patio. Enjoy craft beers, delicious food, and great company while your pup relaxes by your side.",
                Type = VenueType.Restaurant,
                Address = "567 Dining Drive",
                City = "Nashville",
                State = "TN",
                ZipCode = "37201",
                Phone = "(615) 555-GRUB",
                Website = "https://puppypub.example.com",
                ImageUrl = "images/venues/cafe1.jpg",
                AcceptedPetTypes = new List<PetType> { PetType.Dog },
                Amenities = new List<Amenity> { Amenity.OutdoorSeating, Amenity.WaterBowls, Amenity.PetMenu, Amenity.ParkingAvailable, Amenity.WheelchairAccessible },
                OperatingHours = "Mon-Thu: 11:00 AM - 10:00 PM, Fri-Sat: 11:00 AM - 12:00 AM, Sun: 10:00 AM - 9:00 PM",
                AverageRating = 4.5m,
                ReviewCount = 134,
                DateAdded = DateTime.Now.AddMonths(-5)
            }
        };
    }

    private List<Review> InitializeReviews()
    {
        return new List<Review>
        {
            // Reviews for Pawsome Park (Id: 1)
            new Review { Id = 1, VenueId = 1, ReviewerName = "Sarah M.", Rating = 5, Comment = "Best dog park in the city! My golden retriever Max loves the agility course. Great community of dog owners here.", DatePosted = DateTime.Now.AddDays(-5), PetType = PetType.Dog, PetName = "Max", PetImageUrl = "images/pets/dog1.png" },
            new Review { Id = 2, VenueId = 1, ReviewerName = "Mike T.", Rating = 5, Comment = "Wonderful place! Clean, well-maintained, and plenty of space for dogs to run. The separate small dog area is a great touch.", DatePosted = DateTime.Now.AddDays(-12), PetType = PetType.Dog, PetName = "Buddy", PetImageUrl = "images/pets/dog3.jpg" },
            new Review { Id = 3, VenueId = 1, ReviewerName = "Jennifer L.", Rating = 4, Comment = "Love this park! Only giving 4 stars because it can get crowded on weekends. Weekday visits are perfect though.", DatePosted = DateTime.Now.AddDays(-20), PetType = PetType.Dog, PetName = "Luna", PetImageUrl = "images/pets/dog4.png" },

            // Reviews for The Barking Bean Café (Id: 2)
            new Review { Id = 4, VenueId = 2, ReviewerName = "Amanda K.", Rating = 5, Comment = "The puppuccino was a hit! My dog couldn't stop wagging her tail. Great coffee for humans too!", DatePosted = DateTime.Now.AddDays(-3), PetType = PetType.Dog, PetName = "Bella", PetImageUrl = "images/pets/dog5.jpg" },
            new Review { Id = 5, VenueId = 2, ReviewerName = "David R.", Rating = 4, Comment = "Cozy atmosphere and they really made my cat feel welcome. Not many places are cat-friendly!", DatePosted = DateTime.Now.AddDays(-8), PetType = PetType.Cat, PetName = "Whiskers", PetImageUrl = "images/pets/cat1.jpg" },
            new Review { Id = 6, VenueId = 2, ReviewerName = "Emma S.", Rating = 5, Comment = "My favorite spot for remote work! The staff always greets my pup by name. The outdoor seating is perfect.", DatePosted = DateTime.Now.AddDays(-15), PetType = PetType.Dog, PetName = "Charlie", PetImageUrl = "images/pets/dog6.png" },

            // Reviews for Paws & Relax Hotel (Id: 3)
            new Review { Id = 7, VenueId = 3, ReviewerName = "Robert J.", Rating = 5, Comment = "Truly pet-friendly! The pet room service menu was adorable and my dog was so pampered. Will definitely stay again.", DatePosted = DateTime.Now.AddDays(-2), PetType = PetType.Dog, PetName = "Duke", PetImageUrl = "images/pets/dog7.jpg" },
            new Review { Id = 8, VenueId = 3, ReviewerName = "Lisa M.", Rating = 5, Comment = "We travel with our cat and this is by far the best hotel experience we've had. The cat amenities were perfect!", DatePosted = DateTime.Now.AddDays(-10), PetType = PetType.Cat, PetName = "Mittens", PetImageUrl = "images/pets/cat2.jpg" },
            new Review { Id = 9, VenueId = 3, ReviewerName = "Chris P.", Rating = 5, Comment = "Amazing pet sitting service! Went out for dinner and came back to a happy, well-cared-for pup.", DatePosted = DateTime.Now.AddDays(-18), PetType = PetType.Dog, PetName = "Rocky", PetImageUrl = "images/pets/dog8.jpg" },
            new Review { Id = 10, VenueId = 3, ReviewerName = "Nina H.", Rating = 4, Comment = "Beautiful hotel, very accommodating to pets. A bit pricey but worth it for the peace of mind.", DatePosted = DateTime.Now.AddDays(-25), PetType = PetType.Cat, PetName = "Shadow", PetImageUrl = "images/pets/cat3.jpg" },

            // Reviews for Whiskers & Wags Pet Store (Id: 4)
            new Review { Id = 11, VenueId = 4, ReviewerName = "Tom B.", Rating = 5, Comment = "Great selection of toys and treats! My dog loved picking out his own birthday present.", DatePosted = DateTime.Now.AddDays(-4), PetType = PetType.Dog, PetName = "Oscar", PetImageUrl = "images/pets/dog1.png" },
            new Review { Id = 12, VenueId = 4, ReviewerName = "Rachel G.", Rating = 4, Comment = "Helpful staff who really know their products. Prices are reasonable and my bunny enjoys visiting!", DatePosted = DateTime.Now.AddDays(-11), PetType = PetType.Rabbit, PetName = "Hoppy", PetImageUrl = "images/pets/bunny.jpg" },
            new Review { Id = 13, VenueId = 4, ReviewerName = "Kevin W.", Rating = 4, Comment = "One of the few stores that has good reptile supplies. My bearded dragon approves!", DatePosted = DateTime.Now.AddDays(-22), PetType = PetType.Reptile, PetName = "Spike", PetImageUrl = "images/pets/hedgehog.jpg" },

            // Reviews for Mooch's Backyard Haven (Id: 5)
            new Review { Id = 14, VenueId = 5, ReviewerName = "Patricia N.", Rating = 5, Comment = "Rented this for my dog's birthday party - it was perfect! Fully fenced and so much space to play.", DatePosted = DateTime.Now.AddDays(-6), PetType = PetType.Dog, PetName = "Daisy", PetImageUrl = "images/pets/dog4.png" },
            new Review { Id = 15, VenueId = 5, ReviewerName = "Mark D.", Rating = 5, Comment = "Great for training sessions! Love having a private space where my pup can practice without distractions.", DatePosted = DateTime.Now.AddDays(-14), PetType = PetType.Dog, PetName = "Zeus", PetImageUrl = "images/pets/dog5.jpg" },
            new Review { Id = 16, VenueId = 5, ReviewerName = "Susan C.", Rating = 4, Comment = "Nice backyard space! Booking process was easy. Only wish there was a water feature for hot days.", DatePosted = DateTime.Now.AddDays(-28), PetType = PetType.Dog, PetName = "Cooper", PetImageUrl = "images/pets/dog6.png" },

            // Reviews for Sunny Paws Beach (Id: 6)
            new Review { Id = 17, VenueId = 6, ReviewerName = "Brian F.", Rating = 5, Comment = "My lab was in heaven! Finally a beach where dogs can run free. The wash station is a lifesaver.", DatePosted = DateTime.Now.AddDays(-1), PetType = PetType.Dog, PetName = "Sandy", PetImageUrl = "images/pets/dog7.jpg" },
            new Review { Id = 18, VenueId = 6, ReviewerName = "Andrea M.", Rating = 4, Comment = "Beautiful beach! Gets crowded on hot days but that's expected. My dog made so many friends!", DatePosted = DateTime.Now.AddDays(-9), PetType = PetType.Dog, PetName = "Blue", PetImageUrl = "images/pets/dog8.jpg" },
            new Review { Id = 19, VenueId = 6, ReviewerName = "Steve L.", Rating = 4, Comment = "Great spot! Parking can be tricky on weekends but the beach itself is wonderful for dogs.", DatePosted = DateTime.Now.AddDays(-16), PetType = PetType.Dog, PetName = "Maverick", PetImageUrl = "images/pets/dog3.jpg" },

            // Reviews for Tail Waggers Trail (Id: 7)
            new Review { Id = 20, VenueId = 7, ReviewerName = "Kelly R.", Rating = 5, Comment = "Perfect trail for hiking with dogs! Well-marked paths and beautiful scenery. My husky loved it!", DatePosted = DateTime.Now.AddDays(-7), PetType = PetType.Dog, PetName = "Ghost", PetImageUrl = "images/pets/dog1.png" },
            new Review { Id = 21, VenueId = 7, ReviewerName = "Jason H.", Rating = 5, Comment = "Great workout for both me and my energetic pup! Lots of shade and water spots along the trail.", DatePosted = DateTime.Now.AddDays(-13), PetType = PetType.Dog, PetName = "Ranger", PetImageUrl = "images/pets/dog4.png" },
            new Review { Id = 22, VenueId = 7, ReviewerName = "Michelle P.", Rating = 4, Comment = "Beautiful trail! Some sections are steep, so not ideal for older dogs. Otherwise fantastic!", DatePosted = DateTime.Now.AddDays(-21), PetType = PetType.Dog, PetName = "Willow", PetImageUrl = "images/pets/dog5.jpg" },

            // Reviews for Happy Tails Veterinary Clinic (Id: 8)
            new Review { Id = 23, VenueId = 8, ReviewerName = "Linda S.", Rating = 5, Comment = "Dr. Johnson is amazing! She always takes time to explain everything and my pets actually like going here.", DatePosted = DateTime.Now.AddDays(-4), PetType = PetType.Cat, PetName = "Oreo", PetImageUrl = "images/pets/cat1.jpg" },
            new Review { Id = 24, VenueId = 8, ReviewerName = "George K.", Rating = 5, Comment = "Saved my dog's life during an emergency. The 24/7 service is a godsend. Can't recommend enough!", DatePosted = DateTime.Now.AddDays(-11), PetType = PetType.Dog, PetName = "Buster", PetImageUrl = "images/pets/dog6.png" },
            new Review { Id = 25, VenueId = 8, ReviewerName = "Amy T.", Rating = 4, Comment = "Great vet clinic! Prices are fair and staff is wonderful. Wait times can be long during busy periods.", DatePosted = DateTime.Now.AddDays(-19), PetType = PetType.Cat, PetName = "Luna", PetImageUrl = "images/pets/cat2.jpg" },

            // Reviews for Fluffy's Grooming Spa (Id: 9)
            new Review { Id = 26, VenueId = 9, ReviewerName = "Diana W.", Rating = 5, Comment = "My poodle looks absolutely stunning after every visit! The groomers are so skilled and patient.", DatePosted = DateTime.Now.AddDays(-2), PetType = PetType.Dog, PetName = "Princess", PetImageUrl = "images/pets/dog7.jpg" },
            new Review { Id = 27, VenueId = 9, ReviewerName = "Paul M.", Rating = 5, Comment = "Finally found a groomer who can handle my anxious dog! They were so gentle and understanding.", DatePosted = DateTime.Now.AddDays(-8), PetType = PetType.Dog, PetName = "Teddy", PetImageUrl = "images/pets/dog8.jpg" },
            new Review { Id = 28, VenueId = 9, ReviewerName = "Cathy L.", Rating = 4, Comment = "Great grooming services! Book in advance as they get busy. The cat grooming is top-notch.", DatePosted = DateTime.Now.AddDays(-17), PetType = PetType.Cat, PetName = "Fluffy", PetImageUrl = "images/pets/cat3.jpg" },

            // Reviews for The Puppy Pub & Grill (Id: 10)
            new Review { Id = 29, VenueId = 10, ReviewerName = "Ryan O.", Rating = 5, Comment = "Best dog-friendly restaurant in town! The patio is spacious and they even have a dog menu!", DatePosted = DateTime.Now.AddDays(-3), PetType = PetType.Dog, PetName = "Tucker", PetImageUrl = "images/pets/dog1.png" },
            new Review { Id = 30, VenueId = 10, ReviewerName = "Jessica B.", Rating = 4, Comment = "Great food and atmosphere! My dog loves the pup-peroni pizza. Wish indoor seating was pet-friendly too.", DatePosted = DateTime.Now.AddDays(-10), PetType = PetType.Dog, PetName = "Molly", PetImageUrl = "images/pets/dog3.jpg" }
        };
    }

    public Task<List<Venue>> GetVenuesAsync()
    {
        return Task.FromResult(_venues.ToList());
    }

    public Task<Venue?> GetVenueByIdAsync(int id)
    {
        return Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));
    }

    public Task<List<Venue>> SearchVenuesAsync(string? searchTerm, VenueType? venueType, PetType? petType, Amenity? amenity)
    {
        var query = _venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.ToLower();
            query = query.Where(v =>
                v.Name.ToLower().Contains(term) ||
                v.Description.ToLower().Contains(term) ||
                v.City.ToLower().Contains(term) ||
                v.State.ToLower().Contains(term));
        }

        if (venueType.HasValue)
        {
            query = query.Where(v => v.Type == venueType.Value);
        }

        if (petType.HasValue)
        {
            query = query.Where(v => v.AcceptedPetTypes.Contains(petType.Value));
        }

        if (amenity.HasValue)
        {
            query = query.Where(v => v.Amenities.Contains(amenity.Value));
        }

        return Task.FromResult(query.OrderByDescending(v => v.AverageRating).ToList());
    }

    public Task<List<Venue>> GetFeaturedVenuesAsync(int count = 6)
    {
        return Task.FromResult(_venues
            .OrderByDescending(v => v.AverageRating)
            .ThenByDescending(v => v.ReviewCount)
            .Take(count)
            .ToList());
    }

    public Task AddVenueAsync(Venue venue)
    {
        venue.Id = _nextVenueId++;
        venue.DateAdded = DateTime.Now;
        venue.AverageRating = 0;
        venue.ReviewCount = 0;
        _venues.Add(venue);
        return Task.CompletedTask;
    }

    public Task<List<Review>> GetReviewsByVenueIdAsync(int venueId)
    {
        return Task.FromResult(_reviews
            .Where(r => r.VenueId == venueId)
            .OrderByDescending(r => r.DatePosted)
            .ToList());
    }

    public Task<List<Review>> GetRecentReviewsAsync(int count = 5)
    {
        return Task.FromResult(_reviews
            .OrderByDescending(r => r.DatePosted)
            .Take(count)
            .ToList());
    }

    public Task AddReviewAsync(Review review)
    {
        review.Id = _nextReviewId++;
        review.DatePosted = DateTime.Now;
        _reviews.Add(review);

        // Update venue statistics
        var venue = _venues.FirstOrDefault(v => v.Id == review.VenueId);
        if (venue != null)
        {
            var venueReviews = _reviews.Where(r => r.VenueId == review.VenueId).ToList();
            venue.ReviewCount = venueReviews.Count;
            venue.AverageRating = (decimal)venueReviews.Average(r => r.Rating);
        }

        return Task.CompletedTask;
    }
}
