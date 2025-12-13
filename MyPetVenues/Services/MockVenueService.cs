using MyPetVenues.Models;

namespace MyPetVenues.Services;

public sealed class MockVenueService : IVenueService
{
    private readonly IReadOnlyList<Venue> _venues;

    public MockVenueService()
    {
        _venues = BuildMockVenues();
    }

    public Task<IReadOnlyList<Venue>> GetVenuesAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_venues);

    public Task<Venue?> GetVenueAsync(int id, CancellationToken cancellationToken = default)
        => Task.FromResult(_venues.FirstOrDefault(v => v.Id == id));

    private static IReadOnlyList<Venue> BuildMockVenues()
    {
        var now = DateTimeOffset.UtcNow;

        var venues = new List<Venue>
        {
            new(
                Id: 1,
                Name: "Paws & Pastries Café",
                Description: "Cozy coffee + dog-friendly patio. Grab a treat for you and a biscuit for your buddy. ☕️🍪",
                Address: "123 Bark St",
                City: "Seattle",
                State: "WA",
                ImageUrl: "images/venues/cafe1.jpg",
                Rating: 4.7,
                ReviewCount: 128,
                Amenities: new[]
                {
                    VenueAmenity.WaterBowls,
                    VenueAmenity.DogFriendlySeating,
                    VenueAmenity.PetFriendlyOutdoors,
                    VenueAmenity.ShadeAvailable,
                    VenueAmenity.WasteBags,
                },
                Rules: new VenueRules(
                    LeashedOnly: true,
                    OutdoorOnly: false,
                    SmallDogsOnly: false,
                    Notes: "Dogs welcome on the patio; please keep pups off chairs."),
                Reviews: new List<VenueReview>
                {
                    new(101, 1, 5, "Alex", "Perfect patio vibes and always fresh water bowls. 💧🐶", now.AddDays(-3),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.WaterBowls] = true,
                            [VenueAmenity.DogFriendlySeating] = true,
                            [VenueAmenity.PetFriendlyOutdoors] = true,
                            [VenueAmenity.PetFriendlyIndoors] = false,
                        }),
                    new(102, 1, 4, "Sam", "Busy on weekends, but the staff is super kind to pets.", now.AddDays(-11),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.WaterBowls] = true,
                            [VenueAmenity.ShadeAvailable] = true,
                        }),
                }),

            new(
                Id: 2,
                Name: "Mooch’s Meadow Park",
                Description: "Wide open paths, shaded benches, and an off‑leash corner for fetch time. 🎾🌳",
                Address: "400 Greenway Ave",
                City: "Portland",
                State: "OR",
                ImageUrl: "images/venues/park1.jpg",
                Rating: 4.8,
                ReviewCount: 342,
                Amenities: new[]
                {
                    VenueAmenity.OffLeashArea,
                    VenueAmenity.ShadeAvailable,
                    VenueAmenity.WasteBags,
                    VenueAmenity.WaterBowls,
                    VenueAmenity.PetFriendlyOutdoors,
                    VenueAmenity.FencedArea,
                },
                Rules: new VenueRules(
                    LeashedOnly: false,
                    OutdoorOnly: true,
                    SmallDogsOnly: false,
                    Notes: "Off‑leash area is fenced; leash required outside that zone."),
                Reviews: new List<VenueReview>
                {
                    new(201, 2, 5, "Priya", "Fenced off‑leash area is a lifesaver. Great shade too!", now.AddDays(-2),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.FencedArea] = true,
                            [VenueAmenity.OffLeashArea] = true,
                            [VenueAmenity.ShadeAvailable] = true,
                            [VenueAmenity.WasteBags] = true,
                        }),
                    new(202, 2, 4, "Jordan", "Water fountain was working today, bags were stocked.", now.AddDays(-18),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.WaterBowls] = true,
                            [VenueAmenity.WasteBags] = true,
                        }),
                }),

            new(
                Id: 3,
                Name: "Sniff & Stay Hotel",
                Description: "Pet-friendly rooms, welcome treats at check‑in, and a quick relief area outside. 🏨🐾",
                Address: "88 Travel Blvd",
                City: "San Diego",
                State: "CA",
                ImageUrl: "images/venues/hotel1.jpg",
                Rating: 4.5,
                ReviewCount: 96,
                Amenities: new[]
                {
                    VenueAmenity.WaterBowls,
                    VenueAmenity.PetFriendlyIndoors,
                    VenueAmenity.PetFriendlyOutdoors,
                    VenueAmenity.WasteBags,
                },
                Rules: new VenueRules(
                    LeashedOnly: true,
                    OutdoorOnly: false,
                    SmallDogsOnly: false,
                    Notes: "Pets allowed in rooms; please leash in lobby."),
                Reviews: new List<VenueReview>
                {
                    new(301, 3, 5, "Morgan", "Super clean and genuinely pet-welcoming. Treat bag at check-in!", now.AddDays(-7),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.PetFriendlyIndoors] = true,
                            [VenueAmenity.WaterBowls] = true,
                        }),
                    new(302, 3, 4, "Riley", "Great for a quick overnight. Relief area is small but convenient.", now.AddDays(-24),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.PetFriendlyOutdoors] = true,
                            [VenueAmenity.WasteBags] = true,
                        }),
                }),

            new(
                Id: 4,
                Name: "Belly Rub Boutique",
                Description: "A pet-friendly shop with a welcome station and lots of sniff-worthy aisles. 🛍️🐶",
                Address: "55 Market Lane",
                City: "Austin",
                State: "TX",
                ImageUrl: "images/venues/store1.jpg",
                Rating: 4.6,
                ReviewCount: 74,
                Amenities: new[]
                {
                    VenueAmenity.WaterBowls,
                    VenueAmenity.PetFriendlyIndoors,
                    VenueAmenity.WasteBags,
                },
                Rules: new VenueRules(
                    LeashedOnly: true,
                    OutdoorOnly: false,
                    SmallDogsOnly: false,
                    Notes: "Leashed pets welcome; please keep pups close in narrow aisles."),
                Reviews: new List<VenueReview>
                {
                    new(401, 4, 5, "Jamie", "They had water + little treats by the door. My dog loved it. 🥹", now.AddDays(-5),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.PetFriendlyIndoors] = true,
                            [VenueAmenity.WaterBowls] = true,
                        }),
                }),

            new(
                Id: 5,
                Name: "The Pink Paw Home",
                Description: "A welcoming pet-friendly space with comfy corners and lots of natural light. 🏡💖",
                Address: "12 Cozy Ct",
                City: "Nashville",
                State: "TN",
                ImageUrl: "images/venues/home1.jpg",
                Rating: 4.4,
                ReviewCount: 31,
                Amenities: new[]
                {
                    VenueAmenity.ShadeAvailable,
                    VenueAmenity.DogFriendlySeating,
                    VenueAmenity.PetFriendlyIndoors,
                    VenueAmenity.WaterBowls,
                },
                Rules: new VenueRules(
                    LeashedOnly: false,
                    OutdoorOnly: false,
                    SmallDogsOnly: true,
                    Notes: "Small pups only indoors; larger dogs welcome on the patio."),
                Reviews: new List<VenueReview>
                {
                    new(501, 5, 4, "Taylor", "Sweet vibe and great lighting for photos. Smaller dogs fit best inside.", now.AddDays(-16),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.PetFriendlyIndoors] = true,
                            [VenueAmenity.DogFriendlySeating] = true,
                        }),
                }),

            new(
                Id: 6,
                Name: "Mooch’s Corner",
                Description: "Neighborhood hangout with outdoor seating and plenty of shade for loafing. 😎🐾",
                Address: "9 Sunset Rd",
                City: "Phoenix",
                State: "AZ",
                ImageUrl: "images/venues/moochs1.jpg",
                Rating: 4.3,
                ReviewCount: 52,
                Amenities: new[]
                {
                    VenueAmenity.PetFriendlyOutdoors,
                    VenueAmenity.DogFriendlySeating,
                    VenueAmenity.ShadeAvailable,
                    VenueAmenity.WaterBowls,
                },
                Rules: new VenueRules(
                    LeashedOnly: true,
                    OutdoorOnly: false,
                    SmallDogsOnly: false,
                    Notes: "Ask staff for a water bowl refill anytime."),
                Reviews: new List<VenueReview>
                {
                    new(601, 6, 5, "Chris", "Shady seating and very chill. Great stop after a walk.", now.AddDays(-9),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.ShadeAvailable] = true,
                            [VenueAmenity.WaterBowls] = true,
                            [VenueAmenity.PetFriendlyOutdoors] = true,
                        }),
                    new(602, 6, 4, "Drew", "Solid spot—wish the waste bags were stocked last time.", now.AddDays(-22),
                        new Dictionary<VenueAmenity, bool?>
                        {
                            [VenueAmenity.WasteBags] = null,
                        }),
                }),
        };

        return venues;
    }
}
