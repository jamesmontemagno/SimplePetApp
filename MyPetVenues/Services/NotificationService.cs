using Microsoft.JSInterop;
using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class NotificationService : INotificationService, IDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private readonly List<ActivityNotification> _notifications = new();
    private readonly List<LocationAlert> _locationAlerts = new();
    private UserLocation? _currentLocation;
    private bool _isLocationMonitoring = false;
    private DotNetObjectReference<NotificationService>? _objectReference;

    public event Action<ActivityNotification>? NotificationReceived;
    public event Action<LocationAlert>? LocationAlertReceived;
    public event Action? NotificationsChanged;

    public NotificationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _objectReference = DotNetObjectReference.Create(this);
    }

    public Task<IEnumerable<ActivityNotification>> GetNotificationsAsync()
    {
        return Task.FromResult(_notifications.OrderByDescending(n => n.CreatedAt).AsEnumerable());
    }

    public Task<IEnumerable<LocationAlert>> GetLocationAlertsAsync()
    {
        return Task.FromResult(_locationAlerts.OrderByDescending(a => a.CreatedAt).AsEnumerable());
    }

    public Task<int> GetUnreadCountAsync()
    {
        var unreadNotifications = _notifications.Count(n => !n.IsRead);
        var unreadAlerts = _locationAlerts.Count(a => !a.IsRead);
        return Task.FromResult(unreadNotifications + unreadAlerts);
    }

    public Task MarkAsReadAsync(string notificationId)
    {
        var notification = _notifications.FirstOrDefault(n => n.Id == notificationId);
        if (notification != null)
        {
            notification.IsRead = true;
            NotificationsChanged?.Invoke();
            return Task.CompletedTask;
        }

        var alert = _locationAlerts.FirstOrDefault(a => a.Id == notificationId);
        if (alert != null)
        {
            alert.IsRead = true;
            NotificationsChanged?.Invoke();
        }

        return Task.CompletedTask;
    }

    public Task MarkAllAsReadAsync()
    {
        foreach (var notification in _notifications)
        {
            notification.IsRead = true;
        }
        foreach (var alert in _locationAlerts)
        {
            alert.IsRead = true;
        }
        NotificationsChanged?.Invoke();
        return Task.CompletedTask;
    }

    public Task DeleteNotificationAsync(string notificationId)
    {
        _notifications.RemoveAll(n => n.Id == notificationId);
        _locationAlerts.RemoveAll(a => a.Id == notificationId);
        NotificationsChanged?.Invoke();
        return Task.CompletedTask;
    }

    public Task ClearAllNotificationsAsync()
    {
        _notifications.Clear();
        _locationAlerts.Clear();
        NotificationsChanged?.Invoke();
        return Task.CompletedTask;
    }

    public async Task<NotificationPermissionState> GetPermissionStateAsync()
    {
        try
        {
            var permissions = await _jsRuntime.InvokeAsync<dynamic>("getNotificationPermissions");
            return new NotificationPermissionState
            {
                LocationPermissionGranted = permissions.locationPermission == "granted",
                PushNotificationPermissionGranted = permissions.pushPermission == "granted",
                LocationPermissionStatus = permissions.locationPermission ?? "unknown",
                PushPermissionStatus = permissions.pushPermission ?? "unknown"
            };
        }
        catch
        {
            return new NotificationPermissionState();
        }
    }

    public async Task<bool> RequestLocationPermissionAsync()
    {
        try
        {
            var result = await _jsRuntime.InvokeAsync<string>("requestLocationPermission");
            return result == "granted";
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RequestPushNotificationPermissionAsync()
    {
        try
        {
            var result = await _jsRuntime.InvokeAsync<string>("requestPushNotificationPermission");
            return result == "granted";
        }
        catch
        {
            return false;
        }
    }

    public async Task<UserLocation?> GetCurrentLocationAsync()
    {
        try
        {
            var location = await _jsRuntime.InvokeAsync<dynamic>("getCurrentLocation");
            _currentLocation = new UserLocation
            {
                Latitude = location.latitude,
                Longitude = location.longitude,
                Accuracy = location.accuracy ?? 0,
                LastUpdated = DateTime.UtcNow
            };
            return _currentLocation;
        }
        catch
        {
            return null;
        }
    }

    public async Task StartLocationMonitoringAsync()
    {
        if (_isLocationMonitoring) return;

        try
        {
            _isLocationMonitoring = true;
            await _jsRuntime.InvokeVoidAsync("startLocationMonitoring", _objectReference);
        }
        catch
        {
            _isLocationMonitoring = false;
        }
    }

    public async Task StopLocationMonitoringAsync()
    {
        if (!_isLocationMonitoring) return;

        try
        {
            _isLocationMonitoring = false;
            await _jsRuntime.InvokeVoidAsync("stopLocationMonitoring");
        }
        catch
        {
            // Ignore errors when stopping
        }
    }

    [JSInvokable]
    public void OnLocationChanged(double latitude, double longitude, double accuracy)
    {
        _currentLocation = new UserLocation
        {
            Latitude = latitude,
            Longitude = longitude,
            Accuracy = accuracy,
            LastUpdated = DateTime.UtcNow
        };

        // Check for nearby venues and create location alerts
        CheckForNearbyVenues();
    }

    public async Task SendTestNotificationAsync()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("sendTestNotification");
            
            // Also add a test notification to our internal list
            var testNotification = new ActivityNotification
            {
                Title = "Test Notification",
                Message = "This is a test notification to verify the system is working!",
                Type = NotificationType.Message,
                Priority = NotificationPriority.Normal,
                Icon = "🔔"
            };
            
            _notifications.Add(testNotification);
            NotificationReceived?.Invoke(testNotification);
            NotificationsChanged?.Invoke();
        }
        catch
        {
            // Fallback if browser notifications aren't available
            var testNotification = new ActivityNotification
            {
                Title = "Test Notification",
                Message = "Browser notifications not available, but in-app notifications are working!",
                Type = NotificationType.Message,
                Priority = NotificationPriority.Normal,
                Icon = "🔔"
            };
            
            _notifications.Add(testNotification);
            NotificationReceived?.Invoke(testNotification);
            NotificationsChanged?.Invoke();
        }
    }

    public Task AddSampleDataAsync()
    {
        var sampleNotifications = new List<ActivityNotification>
        {
            new()
            {
                Title = "New Review Posted",
                Message = "Sarah left a 5-star review for Central Bark Park!",
                Type = NotificationType.Review,
                Priority = NotificationPriority.Normal,
                Icon = "⭐",
                CreatedAt = DateTime.UtcNow.AddMinutes(-30)
            },
            new()
            {
                Title = "Message Received",
                Message = "Mike sent you a message about the upcoming dog meetup.",
                Type = NotificationType.Message,
                Priority = NotificationPriority.High,
                Icon = "💬",
                CreatedAt = DateTime.UtcNow.AddHours(-2)
            },
            new()
            {
                Title = "Event Reminder",
                Message = "Pet Adoption Fair starts in 1 hour at Downtown Plaza!",
                Type = NotificationType.Event,
                Priority = NotificationPriority.Urgent,
                Icon = "🎉",
                CreatedAt = DateTime.UtcNow.AddMinutes(-5)
            }
        };

        var sampleLocationAlerts = new List<LocationAlert>
        {
            new()
            {
                Title = "Pet-Friendly Cafe Nearby",
                Description = "Paws & Coffee is just 0.3km away and welcomes dogs!",
                VenueName = "Paws & Coffee",
                VenueType = "cafe",
                Latitude = 40.7589, // Example coordinates
                Longitude = -73.9851,
                DistanceInKm = 0.3,
                CreatedAt = DateTime.UtcNow.AddMinutes(-15)
            },
            new()
            {
                Title = "Dog Park Alert",
                Description = "Riverside Dog Park has a special agility event today!",
                VenueName = "Riverside Dog Park",
                VenueType = "park",
                Latitude = 40.7614,
                Longitude = -73.9776,
                DistanceInKm = 0.8,
                CreatedAt = DateTime.UtcNow.AddMinutes(-45)
            }
        };

        _notifications.AddRange(sampleNotifications);
        _locationAlerts.AddRange(sampleLocationAlerts);
        NotificationsChanged?.Invoke();

        return Task.CompletedTask;
    }

    private void CheckForNearbyVenues()
    {
        if (_currentLocation == null) return;

        // This is a simplified example - in a real app, you'd query a backend service
        var nearbyVenues = GetMockNearbyVenues(_currentLocation);
        
        foreach (var venue in nearbyVenues)
        {
            // Only alert if we haven't already alerted about this venue recently
            var existingAlert = _locationAlerts.FirstOrDefault(a => 
                a.VenueName == venue.VenueName && 
                (DateTime.UtcNow - a.CreatedAt).TotalHours < 24);

            if (existingAlert == null)
            {
                _locationAlerts.Add(venue);
                LocationAlertReceived?.Invoke(venue);
                NotificationsChanged?.Invoke();
            }
        }
    }

    private List<LocationAlert> GetMockNearbyVenues(UserLocation location)
    {
        // This is mock data - in a real app, this would come from your backend API
        var mockVenues = new List<LocationAlert>();
        
        // Simulate finding a nearby venue occasionally (10% chance)
        if (Random.Shared.NextDouble() < 0.1)
        {
            var venues = new[]
            {
                new LocationAlert
                {
                    Title = "Dog-Friendly Restaurant Nearby",
                    Description = "The Barking Bistro welcomes pets on their patio!",
                    VenueName = "The Barking Bistro",
                    VenueType = "restaurant",
                    Latitude = location.Latitude + 0.001,
                    Longitude = location.Longitude + 0.001,
                    DistanceInKm = 0.2
                },
                new LocationAlert
                {
                    Title = "Pet Store Close By",
                    Description = "Furry Friends Pet Store has treats and toys!",
                    VenueName = "Furry Friends Pet Store",
                    VenueType = "store",
                    Latitude = location.Latitude - 0.002,
                    Longitude = location.Longitude + 0.003,
                    DistanceInKm = 0.4
                }
            };
            
            mockVenues.Add(venues[Random.Shared.Next(venues.Length)]);
        }

        return mockVenues;
    }

    public void Dispose()
    {
        _objectReference?.Dispose();
        StopLocationMonitoringAsync().ConfigureAwait(false);
    }
}