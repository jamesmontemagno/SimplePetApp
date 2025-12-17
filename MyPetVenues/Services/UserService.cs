using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IUserService
{
    Task<User> GetCurrentUserAsync();
    Task UpdateUserAsync(User user);
    Task<bool> ToggleFavoriteVenueAsync(int venueId);
}

public class UserService : IUserService
{
    private User _currentUser;

    public UserService()
    {
        _currentUser = GenerateMockUser();
    }

    public Task<User> GetCurrentUserAsync()
    {
        return Task.FromResult(_currentUser);
    }

    public Task UpdateUserAsync(User user)
    {
        _currentUser = user;
        return Task.CompletedTask;
    }

    public Task<bool> ToggleFavoriteVenueAsync(int venueId)
    {
        if (_currentUser.FavoriteVenueIds.Contains(venueId))
        {
            _currentUser.FavoriteVenueIds.Remove(venueId);
            return Task.FromResult(false);
        }
        else
        {
            _currentUser.FavoriteVenueIds.Add(venueId);
            return Task.FromResult(true);
        }
    }

    private static User GenerateMockUser()
    {
        return new User
        {
            Id = 1,
            Name = "Alex Johnson",
            Email = "alex.johnson@example.com",
            AvatarUrl = "images/pets/dog1.png",
            Bio = "Proud pet parent of two adorable fur babies! 🐕🐱 Love exploring new pet-friendly places around the Bay Area.",
            Location = "San Francisco, CA",
            JoinedDate = DateTime.Now.AddMonths(-8),
            ReviewCount = 12,
            VenuesAdded = 3,
            FavoriteVenueIds = [1, 3, 5, 6],
            Pets =
            [
                new Pet
                {
                    Id = 1,
                    Name = "Buddy",
                    Type = PetType.Dogs,
                    Breed = "Golden Retriever",
                    Age = 3,
                    ImageUrl = "images/pets/dog5.jpg"
                },
                new Pet
                {
                    Id = 2,
                    Name = "Mittens",
                    Type = PetType.Cats,
                    Breed = "Tabby",
                    Age = 2,
                    ImageUrl = "images/pets/cat1.jpg"
                }
            ],
            Bookings =
            [
                new Booking
                {
                    Id = 1,
                    VenueId = 3,
                    VenueName = "Mooch's Pet Hotel & Spa",
                    VenueImageUrl = "images/venues/moochs1.jpg",
                    UserId = 1,
                    BookingDate = DateTime.Now.AddDays(7),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    NumberOfPets = 1,
                    PetNames = ["Buddy"],
                    Status = BookingStatus.Confirmed,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    TotalPrice = 75.00m
                },
                new Booking
                {
                    Id = 2,
                    VenueId = 7,
                    VenueName = "Furry Friends Daycare",
                    VenueImageUrl = "images/venues/cafe1.jpg",
                    UserId = 1,
                    BookingDate = DateTime.Now.AddDays(-5),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    NumberOfPets = 2,
                    PetNames = ["Buddy", "Mittens"],
                    Status = BookingStatus.Completed,
                    CreatedAt = DateTime.Now.AddDays(-7),
                    TotalPrice = 120.00m
                },
                new Booking
                {
                    Id = 3,
                    VenueId = 8,
                    VenueName = "Whiskers & Wags Grooming",
                    VenueImageUrl = "images/venues/store1.jpg",
                    UserId = 1,
                    BookingDate = DateTime.Now.AddDays(14),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(13, 0, 0),
                    NumberOfPets = 1,
                    PetNames = ["Mittens"],
                    Status = BookingStatus.Pending,
                    CreatedAt = DateTime.Now,
                    TotalPrice = 45.00m
                }
            ]
        };
    }
}
