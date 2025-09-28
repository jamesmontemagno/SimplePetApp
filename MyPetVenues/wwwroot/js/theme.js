window.themeManager = {
    getTheme: function () {
        const savedTheme = localStorage.getItem('theme');
        if (savedTheme) {
            const isDark = savedTheme === 'dark';
            this.applyTheme(isDark);
            return isDark;
        }
        // Default to system preference
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        this.applyTheme(prefersDark);
        return prefersDark;
    },
    
    setTheme: function (isDark) {
        localStorage.setItem('theme', isDark ? 'dark' : 'light');
        this.applyTheme(isDark);
    },
    
    applyTheme: function (isDark) {
        if (isDark) {
            document.documentElement.classList.add('dark-theme');
        } else {
            document.documentElement.classList.remove('dark-theme');
        }
    }
};
