// Tiny theme helper for MyPetVenues landing page.
// Stores preference in localStorage and applies via html[data-theme].

(function () {
    const storageKey = "mpv-theme";

    function preferredTheme() {
        try {
            return window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches
                ? "dark"
                : "light";
        } catch {
            return "light";
        }
    }

    function getStoredTheme() {
        try {
            const value = window.localStorage.getItem(storageKey);
            return value === "dark" || value === "light" ? value : "";
        } catch {
            return "";
        }
    }

    function applyTheme(theme) {
        const t = theme === "dark" ? "dark" : "light";
        document.documentElement.setAttribute("data-theme", t);
        return t;
    }

    function setStoredTheme(theme) {
        try {
            window.localStorage.setItem(storageKey, theme);
        } catch {
            // ignore
        }
    }

    window.theme = {
        init: function () {
            const theme = getStoredTheme() || preferredTheme();
            return applyTheme(theme);
        },
        set: function (theme) {
            const applied = applyTheme(theme);
            setStoredTheme(applied);
        }
    };
})();
