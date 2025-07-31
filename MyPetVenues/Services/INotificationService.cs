using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface INotificationService
{
    event Action<ActivityNotification>? NotificationReceived;
    event Action<LocationAlert>? LocationAlertReceived;
    event Action? NotificationsChanged;

    Task<IEnumerable<ActivityNotification>> GetNotificationsAsync();
    Task<IEnumerable<LocationAlert>> GetLocationAlertsAsync();
    Task<int> GetUnreadCountAsync();
    Task MarkAsReadAsync(string notificationId);
    Task MarkAllAsReadAsync();
    Task DeleteNotificationAsync(string notificationId);
    Task ClearAllNotificationsAsync();
    
    Task<NotificationPermissionState> GetPermissionStateAsync();
    Task<bool> RequestLocationPermissionAsync();
    Task<bool> RequestPushNotificationPermissionAsync();
    
    Task<UserLocation?> GetCurrentLocationAsync();
    Task StartLocationMonitoringAsync();
    Task StopLocationMonitoringAsync();
    
    Task SendTestNotificationAsync();
    Task AddSampleDataAsync();
}