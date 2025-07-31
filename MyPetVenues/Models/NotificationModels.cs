namespace MyPetVenues.Models;

public enum NotificationType
{
    Review,
    Message,
    Event,
    LocationAlert
}

public enum NotificationPriority
{
    Low,
    Normal,
    High,
    Urgent
}

public interface INotificationItem
{
    string Id { get; set; }
    string Title { get; set; }
    DateTime CreatedAt { get; set; }
    bool IsRead { get; set; }
}

public class ActivityNotification : INotificationItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public NotificationType Type { get; set; }
    public NotificationPriority Priority { get; set; } = NotificationPriority.Normal;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;
    public string? Icon { get; set; }
    public string? ActionUrl { get; set; }
}

public class LocationAlert : INotificationItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string VenueName { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double DistanceInKm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;
    public string VenueType { get; set; } = string.Empty; // e.g., "park", "cafe", "hotel"
    public string? ImageUrl { get; set; }
}

public class UserLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public double Accuracy { get; set; }
}

public class NotificationPermissionState
{
    public bool LocationPermissionGranted { get; set; }
    public bool PushNotificationPermissionGranted { get; set; }
    public string LocationPermissionStatus { get; set; } = "unknown"; // "granted", "denied", "prompt"
    public string PushPermissionStatus { get; set; } = "unknown"; // "granted", "denied", "default"
}