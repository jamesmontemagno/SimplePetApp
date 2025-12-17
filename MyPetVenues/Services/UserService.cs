using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IUserService
{
    Task<User?> GetCurrentUserAsync();
    Task<bool> UpdateUserAsync(User user);
    Task<List<Venue>> GetFavoriteVenuesAsync();
    Task<bool> ToggleFavoriteAsync(int venueId);
}

public class MockUserService : IUserService
{
    private User _currentUser;
    private readonly IVenueService _venueService;

    public MockUserService(IVenueService venueService)
    {
        _venueService = venueService;
        _currentUser = GenerateMockUser();
    }

    public Task<User?> GetCurrentUserAsync() => Task.FromResult<User?>(_currentUser);

    public Task<bool> UpdateUserAsync(User user)
    {
        _currentUser = user;
        return Task.FromResult(true);
    }

    public async Task<List<Venue>> GetFavoriteVenuesAsync()
    {
        var allVenues = await _venueService.GetAllVenuesAsync();
        return allVenues.Where(v => _currentUser.FavoriteVenueIds.Contains(v.Id)).ToList();
    }

    public Task<bool> ToggleFavoriteAsync(int venueId)
    {
        if (_currentUser.FavoriteVenueIds.Contains(venueId))
        {
            _currentUser.FavoriteVenueIds.Remove(venueId);
        }
        else
        {
            _currentUser.FavoriteVenueIds.Add(venueId);
        }
        return Task.FromResult(true);
    }

    private static User GenerateMockUser() => new()
    {
        Id = 1,
        Name = "Alex Johnson",
        Email = "alex.johnson@email.com",
        Avatar = "images/pets/dog7.jpg",
        Bio = "Pet lover with a passion for finding the best spots for my furry family! 🐾 Always on the lookout for new adventures.",
        Location = "San Francisco, CA",
        JoinedDate = DateTime.Now.AddYears(-2),
        Pets = new List<Pet>
        {
            new Pet
            {
                Id = 1,
                Name = "Max",
                Type = PetType.Dog,
                Breed = "Golden Retriever",
                Age = 4,
                ImageUrl = "images/pets/dog1.png"
            },
            new Pet
            {
                Id = 2,
                Name = "Whiskers",
                Type = PetType.Cat,
                Breed = "Maine Coon",
                Age = 3,
                ImageUrl = "images/pets/cat1.jpg"
            }
        },
        FavoriteVenueIds = new List<int> { 1, 2, 3 },
        Preferences = new UserPreferences
        {
            EmailNotifications = true,
            PushNotifications = true,
            SearchRadius = 25,
            PreferredPetTypes = new List<PetType> { PetType.Dog, PetType.Cat },
            PreferredVenueTypes = new List<VenueType> { VenueType.Park, VenueType.Cafe, VenueType.Restaurant }
        }
    };
}
