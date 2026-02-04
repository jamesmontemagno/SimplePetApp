window.themeManager = {
    getTheme: function () {
        const theme = localStorage.getItem('theme');
        if (!theme) {
            const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
            return prefersDark ? 'dark' : 'light';
        }
        return theme;
    },
    
    setTheme: function (theme) {
        localStorage.setItem('theme', theme);
        document.documentElement.setAttribute('data-theme', theme);
    },
    
    initialize: function () {
        const theme = this.getTheme();
        document.documentElement.setAttribute('data-theme', theme);
    }
};

themeManager.initialize();
