window.setTheme = function(theme) {
    if (theme === 'dark') {
        document.body.classList.add('dark');
        document.documentElement.classList.add('dark');
        localStorage.setItem('theme', 'dark');
    } else {
        document.body.classList.remove('dark');
        document.documentElement.classList.remove('dark');
        localStorage.setItem('theme', 'light');
    }
};

// Auto-apply theme on load
(function() {
    var theme = localStorage.getItem('theme');
    if (theme === 'dark') {
        document.body.classList.add('dark');
        document.documentElement.classList.add('dark');
    }
})();
