window.themeInterop = window.themeInterop || {
    getTheme: () => window.localStorage?.getItem('petVenuesTheme') ?? '',
    setTheme: (theme) => window.localStorage?.setItem('petVenuesTheme', theme ?? 'light'),
    applyTheme: (theme) => {
        const value = theme || 'light';
        document.documentElement.dataset.theme = value;
        document.body?.classList.toggle('theme-dark', value === 'dark');
        document.body?.classList.toggle('theme-light', value !== 'dark');
    },
    prefersDark: () => window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches
};
