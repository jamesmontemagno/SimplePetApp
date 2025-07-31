// Notification and Location APIs for Pet Venues App

let watchId = null;
let dotNetHelper = null;

// Get current permission states
window.getNotificationPermissions = function() {
    const locationPermission = navigator.permissions ? 'unknown' : 'unknown';
    const pushPermission = 'Notification' in window ? Notification.permission : 'unsupported';
    
    return {
        locationPermission: locationPermission,
        pushPermission: pushPermission
    };
};

// Request location permission and get current location
window.requestLocationPermission = function() {
    return new Promise((resolve) => {
        if (!navigator.geolocation) {
            resolve('denied');
            return;
        }

        navigator.geolocation.getCurrentPosition(
            (position) => {
                resolve('granted');
            },
            (error) => {
                console.warn('Location permission denied:', error);
                resolve('denied');
            },
            {
                enableHighAccuracy: true,
                timeout: 10000,
                maximumAge: 300000 // 5 minutes
            }
        );
    });
};

// Request push notification permission
window.requestPushNotificationPermission = function() {
    if (!('Notification' in window)) {
        console.warn('Browser does not support notifications');
        return Promise.resolve('denied');
    }

    if (Notification.permission === 'granted') {
        return Promise.resolve('granted');
    }

    if (Notification.permission === 'denied') {
        return Promise.resolve('denied');
    }

    return Notification.requestPermission().then((permission) => {
        return permission;
    });
};

// Get current location
window.getCurrentLocation = function() {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject(new Error('Geolocation not supported'));
            return;
        }

        navigator.geolocation.getCurrentPosition(
            (position) => {
                resolve({
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude,
                    accuracy: position.coords.accuracy,
                    timestamp: position.timestamp
                });
            },
            (error) => {
                console.warn('Error getting location:', error);
                reject(error);
            },
            {
                enableHighAccuracy: true,
                timeout: 15000,
                maximumAge: 300000 // 5 minutes
            }
        );
    });
};

// Start location monitoring
window.startLocationMonitoring = function(dotNetObjectReference) {
    dotNetHelper = dotNetObjectReference;
    
    if (!navigator.geolocation) {
        console.warn('Geolocation not supported');
        return;
    }

    // Stop any existing watch
    if (watchId !== null) {
        navigator.geolocation.clearWatch(watchId);
    }

    watchId = navigator.geolocation.watchPosition(
        (position) => {
            if (dotNetHelper) {
                dotNetHelper.invokeMethodAsync('OnLocationChanged',
                    position.coords.latitude,
                    position.coords.longitude,
                    position.coords.accuracy
                );
            }
        },
        (error) => {
            console.warn('Location monitoring error:', error);
        },
        {
            enableHighAccuracy: true,
            timeout: 30000,
            maximumAge: 60000 // 1 minute
        }
    );
};

// Stop location monitoring
window.stopLocationMonitoring = function() {
    if (watchId !== null) {
        navigator.geolocation.clearWatch(watchId);
        watchId = null;
    }
    dotNetHelper = null;
};

// Send test notification
window.sendTestNotification = function() {
    if (!('Notification' in window)) {
        console.warn('Browser does not support notifications');
        return Promise.resolve();
    }

    if (Notification.permission === 'granted') {
        const notification = new Notification('🐾 Pet Venues', {
            body: 'Test notification from your pet-friendly app!',
            icon: '/icon-192.png',
            badge: '/icon-192.png',
            tag: 'pet-venues-test',
            vibrate: [100, 50, 100],
            requireInteraction: false,
            timestamp: Date.now()
        });

        // Auto-close after 5 seconds
        setTimeout(() => {
            notification.close();
        }, 5000);

        return Promise.resolve();
    } else {
        console.warn('Notification permission not granted');
        return Promise.resolve();
    }
};

// Send location alert notification
window.sendLocationAlert = function(title, body, venueType) {
    if (!('Notification' in window) || Notification.permission !== 'granted') {
        return;
    }

    const icons = {
        'park': '🏞️',
        'cafe': '☕',
        'restaurant': '🍽️',
        'store': '🏪',
        'hotel': '🏨',
        'default': '📍'
    };

    const icon = icons[venueType] || icons.default;

    const notification = new Notification(`${icon} ${title}`, {
        body: body,
        icon: '/icon-192.png',
        badge: '/icon-192.png',
        tag: 'pet-venues-location',
        vibrate: [200, 100, 200],
        requireInteraction: false,
        timestamp: Date.now()
    });

    // Auto-close after 8 seconds
    setTimeout(() => {
        notification.close();
    }, 8000);
};

// Utility function to calculate distance between two points
window.calculateDistance = function(lat1, lon1, lat2, lon2) {
    const R = 6371; // Radius of the Earth in kilometers
    const dLat = (lat2 - lat1) * Math.PI / 180;
    const dLon = (lon2 - lon1) * Math.PI / 180;
    const a = 
        Math.sin(dLat/2) * Math.sin(dLat/2) +
        Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
        Math.sin(dLon/2) * Math.sin(dLon/2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
    const distance = R * c; // Distance in kilometers
    return distance;
};

// Format distance for display
window.formatDistance = function(distanceInKm) {
    if (distanceInKm < 1) {
        return Math.round(distanceInKm * 1000) + 'm';
    } else {
        return distanceInKm.toFixed(1) + 'km';
    }
};

console.log('🐾 Pet Venues notification system loaded');