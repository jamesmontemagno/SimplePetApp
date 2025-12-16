using MyPetVenues.Models;

namespace MyPetVenues.Services;

/// <summary>
/// Mock implementation of IVenueRepository for development/testing.
/// Single Responsibility: Only handles data storage and retrieval.
/// </summary>
public class MockVenueRepository : IVenueRepository
{
    private readonly List<Venue> _venues;

    public MockVenueRepository()
    {
        _venues = GenerateMockVenues();
    }

    public IReadOnlyList<Venue> GetAll() => _venues.AsReadOnly();

    public Venue? GetById(int id) => _venues.FirstOrDefault(v => v.Id == id);

    private static List<Venue> GenerateMockVenues()
    {
        return new List<Venue>
        {
            CreateVenue(1, "Paws & Coffee", VenueType.Cafe, "San Francisco", "CA",
                "A cozy neighborhood cafe where your furry friend is always welcome! We serve artisan coffee, fresh pastries, and even have a special pet treat menu. Our spacious patio is perfect for lazy Sunday mornings with your pup.",
                "123 Bark Street", "94102", "(415) 555-0123", "https://pawsandcoffee.example.com",
                "images/venues/cafe1.jpg",
                new[] { "Water Bowls", "Pet Treats", "Patio Seating", "Shaded Area", "Pet Menu" },
                new[] { "Dogs", "Cats", "Small Pets" },
                4.8, 234, "Mon-Fri: 7AM-7PM, Sat-Sun: 8AM-8PM", true),

            CreateVenue(2, "Sunny Paws Dog Park", VenueType.Park, "San Francisco", "CA",
                "The city's premier off-leash dog park featuring separate areas for large and small dogs, agility equipment, and a splash pad for hot summer days. Fully fenced with double-gate entry for safety.",
                "456 Fetch Avenue", "94110", "(415) 555-0456", "https://sunnypawspark.example.com",
                "images/venues/park1.jpg",
                new[] { "Off-Leash Area", "Water Stations", "Waste Bags", "Wash Station", "Agility Equipment", "Splash Pad", "Shaded Area", "Benches" },
                new[] { "Dogs" },
                4.9, 567, "Daily: 6AM-10PM", true),

            CreateVenue(3, "Pet Paradise Hotel", VenueType.Hotel, "Los Angeles", "CA",
                "Luxury accommodations that truly welcome pets! Every room comes with a pet bed, food bowls, and a welcome treat bag. Our grounds include a private dog park and pet spa services.",
                "789 Luxury Lane", "90210", "(310) 555-0789", "https://petparadisehotel.example.com",
                "images/venues/hotel1.jpg",
                new[] { "Pet Beds", "Room Service", "Dog Park", "Pet Spa", "Pet Sitting", "No Pet Fee", "Welcome Treats" },
                new[] { "Dogs", "Cats" },
                4.7, 189, "24/7 Front Desk", true),

            CreateVenue(4, "Furry Friends Pet Supply", VenueType.Store, "Seattle", "WA",
                "Your one-stop shop for all pet supplies! Bring your pet to try on gear, sample treats, and get expert advice from our trained staff. We carry premium brands and local artisan pet products.",
                "321 Treat Trail", "98101", "(206) 555-0321", "https://furryfriendssupply.example.com",
                "images/venues/store1.jpg",
                new[] { "Free Treats", "Pet Scale", "Fitting Area", "Self-Service Wash", "Training Classes" },
                new[] { "Dogs", "Cats", "Birds", "Small Pets", "Reptiles" },
                4.6, 312, "Mon-Sat: 9AM-9PM, Sun: 10AM-6PM", true),

            CreateVenue(5, "Mooch's Bar & Grill", VenueType.Restaurant, "Austin", "TX",
                "Family-friendly restaurant with an extensive pet menu! Our covered patio is designed with pets in mind, featuring cooling mats in summer and heat lamps in winter. Famous for our 'Pup-peroni Pizza' dog treat!",
                "555 Woof Way", "78701", "(512) 555-0555", "https://moochsbarandgrill.example.com",
                "images/venues/moochs1.jpg",
                new[] { "Pet Menu", "Water Bowls", "Outdoor Seating", "Cooling Mats", "Heat Lamps", "Tie-Up Stations" },
                new[] { "Dogs", "Cats" },
                4.5, 445, "Daily: 11AM-11PM", true),

            CreateVenue(6, "Pet Haven Boarding", VenueType.Boarding, "Denver", "CO",
                "Premium pet boarding with 24/7 care and live webcam access so you never miss your furry friend. We offer private suites, group play sessions, and spa treatments.",
                "888 Snuggle Street", "80202", "(303) 555-0888", "https://pethavenboarding.example.com",
                "images/venues/home1.jpg",
                new[] { "Webcam Access", "Private Suites", "Group Play", "Grooming", "Training", "Medication Administration", "24/7 Staff" },
                new[] { "Dogs", "Cats" },
                4.9, 278, "Drop-off: 7AM-7PM, Pick-up: 7AM-7PM", true),

            CreateVenue(7, "Bark Beach", VenueType.Beach, "San Diego", "CA",
                "The only dedicated dog beach in the area! Miles of sandy shores where dogs can run free, swim, and play. Freshwater rinse stations available. Beautiful sunset views!",
                "1 Ocean Drive", "92109", "(619) 555-0001", "https://barkbeach.example.com",
                "images/venues/park1.jpg",
                new[] { "Off-Leash Area", "Rinse Stations", "Waste Bags", "Parking", "Restrooms", "Lifeguard" },
                new[] { "Dogs" },
                4.8, 892, "Daily: Sunrise-Sunset", true),

            CreateVenue(8, "The Pampered Pup Spa", VenueType.Grooming, "Miami", "FL",
                "Full-service grooming salon and spa for dogs. From basic baths to luxury spa packages with aromatherapy and massage. All natural, pet-safe products used.",
                "222 Glamour Grove", "33139", "(305) 555-0222", "https://pamperedpupspa.example.com",
                "images/venues/store1.jpg",
                new[] { "Full Grooming", "Nail Trimming", "Teeth Cleaning", "Aromatherapy", "Pet Massage", "Organic Products" },
                new[] { "Dogs", "Cats" },
                4.7, 156, "Tue-Sat: 9AM-6PM", true),

            CreateVenue(9, "Whiskers Cat Cafe", VenueType.Cafe, "Portland", "OR",
                "A unique cafe experience where you can enjoy your latte surrounded by adoptable cats! Reservation required for the cat lounge. All cats are from local rescues.",
                "777 Meow Lane", "97204", "(503) 555-0777", "https://whiskerscatcafe.example.com",
                "images/venues/cafe1.jpg",
                new[] { "Cat Lounge", "Adoption Services", "Coffee & Tea", "Cat Toys", "Photo Opportunities" },
                new[] { "Cats" },
                4.9, 423, "Wed-Mon: 10AM-8PM (Closed Tuesdays)", true),

            CreateVenue(10, "Happy Tails Vet Clinic", VenueType.VetClinic, "Chicago", "IL",
                "Fear-free certified veterinary clinic dedicated to making vet visits stress-free for pets. We offer treats, calming pheromones, and separate waiting areas for cats and dogs.",
                "444 Wellness Way", "60601", "(312) 555-0444", "https://happytailsvet.example.com",
                "images/venues/home1.jpg",
                new[] { "Fear-Free Certified", "Separate Cat Area", "Treats", "Calming Pheromones", "Emergency Services", "Online Booking" },
                new[] { "Dogs", "Cats", "Birds", "Small Pets", "Reptiles" },
                4.8, 534, "Mon-Fri: 8AM-8PM, Sat: 9AM-5PM, Sun: Emergency Only", true),

            CreateVenue(11, "Canine Creek Trail", VenueType.Park, "Boulder", "CO",
                "A beautiful 5-mile hiking trail that welcomes leashed dogs. Features multiple water crossings, scenic overlooks, and shaded rest areas. Moderate difficulty level.",
                "Trail Head: 999 Nature Road", "80302", "(303) 555-0999", "https://caninecreektrail.example.com",
                "images/venues/park1.jpg",
                new[] { "Hiking Trail", "Water Access", "Waste Bags", "Parking", "Scenic Views", "Shaded Areas" },
                new[] { "Dogs" },
                4.6, 289, "Daily: Dawn-Dusk", false),

            CreateVenue(12, "Biscuit Boutique Bakery", VenueType.Store, "Nashville", "TN",
                "Artisan dog bakery offering fresh-baked treats, birthday cakes, and custom orders. All ingredients are human-grade and locally sourced. Dogs welcome to sniff and choose!",
                "333 Biscuit Boulevard", "37203", "(615) 555-0333", "https://biscuitboutique.example.com",
                "images/venues/store1.jpg",
                new[] { "Fresh Treats", "Custom Cakes", "Birthday Parties", "Free Samples", "Gift Wrapping" },
                new[] { "Dogs", "Cats" },
                4.9, 167, "Tue-Sun: 10AM-6PM", true)
        };
    }

    private static Venue CreateVenue(
        int id, string name, VenueType type, string city, string state,
        string description, string address, string zipCode, string phone, string website,
        string imageUrl, string[] amenities, string[] petTypes,
        double rating, int reviewCount, string hours, bool isVerified)
    {
        return new Venue
        {
            Id = id,
            Name = name,
            Type = type,
            City = city,
            State = state,
            Description = description,
            Address = address,
            ZipCode = zipCode,
            Phone = phone,
            Website = website,
            ImageUrl = imageUrl,
            Amenities = amenities.ToList(),
            PetTypesAllowed = petTypes.ToList(),
            Rating = rating,
            ReviewCount = reviewCount,
            Hours = hours,
            IsVerified = isVerified,
            Reviews = GenerateReviews(id)
        };
    }

    private static List<Review> GenerateReviews(int venueId)
    {
        var reviewTemplates = new List<(string Author, string Avatar, string Content, double Rating, string PetName, string PetType)>
        {
            ("Sarah M.", "🧑‍🦰", "Absolutely loved this place! The staff was so welcoming to my dog and even brought out a special treat. Will definitely be back!", 5.0, "Buddy", "Golden Retriever"),
            ("Mike T.", "👨", "Great experience overall. Clean facilities and pet-friendly atmosphere. Only minor issue was limited parking on weekends.", 4.5, "Max", "German Shepherd"),
            ("Emily R.", "👩", "My cat was nervous at first but the calm environment really helped. Staff was patient and knowledgeable. Highly recommend!", 5.0, "Whiskers", "Tabby Cat"),
            ("James L.", "👨‍🦱", "Perfect spot for pet parents! They really understand what pet owners need. The amenities are top-notch.", 4.8, "Luna", "Labrador"),
            ("Ashley K.", "👩‍🦳", "We come here every week with our pup. It's become our favorite spot in the city. The other pet parents are friendly too!", 5.0, "Charlie", "Beagle"),
            ("David H.", "🧔", "Good place but can get crowded on weekends. Best to visit during off-peak hours if your pet gets anxious around others.", 4.0, "Rocky", "Pitbull"),
            ("Jessica P.", "👩‍🦰", "My senior dog was treated with such care here. They accommodated all his special needs without any issues. Thank you!", 5.0, "Oliver", "Cocker Spaniel"),
            ("Chris B.", "👨‍🦲", "First time here and was impressed! They had everything we needed. Staff gave us great recommendations too.", 4.7, "Bella", "French Bulldog"),
            ("Amanda S.", "👱‍♀️", "The outdoor space is fantastic. My energetic puppy had so much room to explore. Clean and well-maintained.", 4.9, "Cooper", "Border Collie"),
            ("Ryan W.", "🧑", "Solid experience. Fair prices and good service. My dog always gets excited when we pull into the parking lot!", 4.5, "Duke", "Boxer")
        };

        var random = new Random(venueId);
        var reviewCount = random.Next(3, 6);
        var reviews = new List<Review>();

        for (int i = 0; i < reviewCount; i++)
        {
            var template = reviewTemplates[random.Next(reviewTemplates.Count)];
            var daysAgo = random.Next(1, 90);

            reviews.Add(new Review
            {
                Id = venueId * 100 + i,
                AuthorName = template.Author,
                AuthorAvatar = template.Avatar,
                Content = template.Content,
                Rating = template.Rating,
                CleanlinessRating = Math.Round(4.0 + random.NextDouble(), 1),
                StaffRating = Math.Round(4.0 + random.NextDouble(), 1),
                PetFriendlinessRating = Math.Round(4.0 + random.NextDouble(), 1),
                DatePosted = DateTime.Now.AddDays(-daysAgo),
                PetName = template.PetName,
                PetType = template.PetType
            });
        }

        return reviews.OrderByDescending(r => r.DatePosted).ToList();
    }
}
