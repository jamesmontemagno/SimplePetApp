namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public int StaffFriendlinessRating { get; set; }
    public int CleanlinessRating { get; set; }
    public int PetAmenitiesRating { get; set; }
    public int HelpfulCount { get; set; }
    public List<string> PhotoUrls { get; set; } = [];
    public string PetName { get; set; } = string.Empty;
    public PetType PetType { get; set; }
}
