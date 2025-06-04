// Theme toggle functionality
window.themeToggle = {
    initialize: function() {
        // Check if user has set a theme preference before
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme) {
            document.body.classList.add(savedTheme);
        } else {
            // Default to dark mode
            document.body.classList.add('dark-mode');
        }
    },
    
    toggle: function() {
        if (document.body.classList.contains('dark-mode')) {
            document.body.classList.replace('dark-mode', 'light-mode');
            localStorage.setItem('theme', 'light-mode');
            return false; // isDarkMode = false
        } else {
            document.body.classList.replace('light-mode', 'dark-mode');
            localStorage.setItem('theme', 'dark-mode');
            return true; // isDarkMode = true
        }
    },
    
    isDarkMode: function() {
        return document.body.classList.contains('dark-mode');
    }
};

// Initialize theme on page load
document.addEventListener('DOMContentLoaded', function() {
    window.themeToggle.initialize();
    
    // Rotate hero images functionality
    const rotateHeroImages = function() {
        const heroImages = document.querySelectorAll('.hero-image');
        if (!heroImages.length) return;
        
        let activeIndex = 0;
        
        setInterval(() => {
            heroImages[activeIndex].classList.remove('active');
            activeIndex = (activeIndex + 1) % heroImages.length;
            heroImages[activeIndex].classList.add('active');
        }, 3000); // Change image every 3 seconds
    };
    
    rotateHeroImages();
});
