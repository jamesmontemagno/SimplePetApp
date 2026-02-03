namespace MyPetVenues.Models;

public class Amenity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public static class AmenityIcons
{
    public const string WaterBowl = "💧";
    public const string Treats = "🦴";
    public const string OutdoorSeating = "🌳";
    public const string PetBeds = "🛏️";
    public const string WashingStation = "🚿";
    public const string PetMenu = "🍽️";
    public const string Parking = "🅿️";
    public const string VetOnSite = "🏥";
    public const string OffLeashArea = "🐕";
    public const string AirConditioned = "❄️";
    public const string WiFi = "📶";
    public const string PlayArea = "🎾";
    public const string Fenced = "🚧";
    public const string PetFriendlyStaff = "💕";
    public const string WasteStations = "🗑️";
    public const string PhotoSpot = "📸";
}
