// Basic map functionality for pet venues
window.initializeMap = function(locations) {
    console.log('Initializing map with locations:', locations);
    // In a real implementation, this would integrate with Google Maps, Leaflet, or similar
    // For now, we'll just log the locations
    if (locations && locations.length > 0) {
        console.log(`Map initialized with ${locations.length} locations`);
    }
};

// Navigation helpers
window.navigateToLocationDetails = function(locationId) {
    window.location.href = `/locations/${locationId}`;
};

window.navigateToLocationList = function() {
    window.location.href = '/locations';
};

window.navigateToLocationMap = function() {
    window.location.href = '/map';
};

// Utility functions
window.shareLocation = function(locationData) {
    if (navigator.share) {
        navigator.share({
            title: locationData.title,
            text: locationData.text,
            url: locationData.url
        }).catch(console.error);
    } else {
        // Fallback for browsers that don't support Web Share API
        navigator.clipboard.writeText(locationData.url).then(() => {
            alert('Link copied to clipboard!');
        }).catch(() => {
            alert('Unable to share. Please copy the URL manually.');
        });
    }
};

window.getDirections = function(latitude, longitude) {
    const url = `https://maps.google.com/maps?q=${latitude},${longitude}`;
    window.open(url, '_blank');
};

// Theme management (extending existing theme.js)
window.setMapTheme = function(theme) {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);
};

// Initialize theme on page load
document.addEventListener('DOMContentLoaded', function() {
    var theme = localStorage.getItem('theme') || 'light';
    document.documentElement.setAttribute('data-theme', theme);
});