using MyPetVenues.Models;

namespace MyPetVenues.Services;

public sealed class MockPetVenueService : IPetVenueService
{
    private static readonly List<PetVenue> Venues =
    [
        new()
        {
            Id = 1,
            Name = "Sunset Bark Park",
            City = "Seattle",
            State = "WA",
            Category = "Outdoor Park",
            PetType = "Dogs",
            ImageUrl = "images/venues/park1.jpg",
            Description = "Fenced off-leash areas, agility course, and shaded seating near the waterfront.",
            Amenities = new[] { "Water bowls", "Shade", "Agility course", "Restrooms" },
            Rating = 4.8,
            ReviewCount = 214,
            Featured = true,
            Address = "123 Bay Ave, Seattle, WA",
            Hours = "6:00 AM - 10:00 PM"
        },
        new()
        {
            Id = 2,
            Name = "Whisker & Bean Café",
            City = "Portland",
            State = "OR",
            Category = "Café",
            PetType = "Cats",
            ImageUrl = "images/venues/cafe1.jpg",
            Description = "Cat-friendly coffee shop with cozy nooks and locally roasted beans.",
            Amenities = new[] { "Indoor seating", "Treat menu", "Wi-Fi", "Quiet zone" },
            Rating = 4.7,
            ReviewCount = 132,
            Featured = true,
            Address = "456 Maple St, Portland, OR",
            Hours = "8:00 AM - 9:00 PM"
        },
        new()
        {
            Id = 3,
            Name = "Paws & Stay Hotel",
            City = "San Diego",
            State = "CA",
            Category = "Hotel",
            PetType = "Dogs",
            ImageUrl = "images/venues/hotel1.jpg",
            Description = "Boutique hotel with doggy welcome packs and rooftop relief area.",
            Amenities = new[] { "Rooftop run", "Late checkout", "Grooming partners", "Concierge" },
            Rating = 4.6,
            ReviewCount = 189,
            Featured = true,
            Address = "789 Ocean Blvd, San Diego, CA",
            Hours = "24/7"
        },
        new()
        {
            Id = 4,
            Name = "Neighborhood Pet Supply",
            City = "Austin",
            State = "TX",
            Category = "Retail",
            PetType = "All Pets",
            ImageUrl = "images/venues/store1.jpg",
            Description = "Local shop with DIY treat bar and community bulletin for meetups.",
            Amenities = new[] { "Treat bar", "Cooling mats", "Adoption events", "Parking" },
            Rating = 4.5,
            ReviewCount = 98,
            Featured = false,
            Address = "321 Market Rd, Austin, TX",
            Hours = "10:00 AM - 8:00 PM"
        },
        new()
        {
            Id = 5,
            Name = "Green Trails Nature Walk",
            City = "Denver",
            State = "CO",
            Category = "Trail",
            PetType = "Dogs",
            ImageUrl = "images/venues/home1.jpg",
            Description = "Scenic loop with gentle grades, water fountains, and waste stations.",
            Amenities = new[] { "Waste bags", "Water fountains", "Scenic views", "Shade" },
            Rating = 4.9,
            ReviewCount = 260,
            Featured = true,
            Address = "14 Ridge Rd, Denver, CO",
            Hours = "Sunrise - Sunset"
        },
        new()
        {
            Id = 6,
            Name = "Mooch's Dog Diner",
            City = "Brooklyn",
            State = "NY",
            Category = "Restaurant",
            PetType = "Dogs",
            ImageUrl = "images/venues/moochs1.jpg",
            Description = "Retro diner with a curated dog menu and heated outdoor patio.",
            Amenities = new[] { "Heated patio", "Dog menu", "Water bowls", "Fans" },
            Rating = 4.4,
            ReviewCount = 143,
            Featured = false,
            Address = "88 Atlantic Ave, Brooklyn, NY",
            Hours = "11:00 AM - 11:00 PM"
        },
        new()
        {
            Id = 7,
            Name = "Cozy Critter Lounge",
            City = "Chicago",
            State = "IL",
            Category = "Indoor Lounge",
            PetType = "Small Pets",
            ImageUrl = "images/venues/hotel1.jpg",
            Description = "Climate-controlled lounge welcoming rabbits, hedgehogs, and pocket pets.",
            Amenities = new[] { "Quiet rooms", "Soft mats", "Vet on-call", "Work tables" },
            Rating = 4.3,
            ReviewCount = 77,
            Featured = false,
            Address = "210 Harbor Dr, Chicago, IL",
            Hours = "9:00 AM - 8:00 PM"
        },
        new()
        {
            Id = 8,
            Name = "Riverside Cat Walk",
            City = "Sacramento",
            State = "CA",
            Category = "Outdoor Walk",
            PetType = "Cats",
            ImageUrl = "images/venues/park1.jpg",
            Description = "Leash-friendly river path with shaded benches and calm traffic.",
            Amenities = new[] { "Shade", "Calm path", "Benches", "Parking" },
            Rating = 4.5,
            ReviewCount = 112,
            Featured = false,
            Address = "12 River Rd, Sacramento, CA",
            Hours = "7:00 AM - 9:00 PM"
        }
    ];

    public Task<IReadOnlyList<PetVenue>> GetFeaturedAsync() => Task.FromResult<IReadOnlyList<PetVenue>>(Venues.Where(v => v.Featured).ToList());

    public Task<IReadOnlyList<PetVenue>> GetAllAsync() => Task.FromResult<IReadOnlyList<PetVenue>>(Venues);

    public Task<PetVenue?> GetByIdAsync(int id) => Task.FromResult(Venues.FirstOrDefault(v => v.Id == id));

    public Task<IReadOnlyList<PetVenue>> SearchAsync(string? term, string? petType, IEnumerable<string>? amenities)
    {
        var query = Venues.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(term))
        {
            query = query.Where(v => v.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                                     v.City.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                                     v.Description.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(petType) && !petType.Equals("all", StringComparison.OrdinalIgnoreCase))
        {
            query = query.Where(v => v.PetType.Equals(petType, StringComparison.OrdinalIgnoreCase) || v.PetType.Equals("All Pets", StringComparison.OrdinalIgnoreCase));
        }

        var amenityList = amenities?.Where(a => !string.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToList();
        if (amenityList is { Count: > 0 })
        {
            query = query.Where(v => amenityList.All(a => v.Amenities.Any(x => x.Equals(a, StringComparison.OrdinalIgnoreCase))));
        }

        return Task.FromResult<IReadOnlyList<PetVenue>>(query.ToList());
    }
}
