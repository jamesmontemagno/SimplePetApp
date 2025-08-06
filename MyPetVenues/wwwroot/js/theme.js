window.setTheme = function(theme) {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);
}

// On load, set theme from localStorage
document.addEventListener('DOMContentLoaded', function() {
    var theme = localStorage.getItem('theme') || 'dark';
    document.documentElement.setAttribute('data-theme', theme);
});
