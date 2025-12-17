namespace MyPetVenues.Services;

public interface IThemeService
{
    bool IsDarkMode { get; }
    event Action? OnThemeChanged;
    void ToggleTheme();
    void SetTheme(bool isDarkMode);
}

public class ThemeService : IThemeService
{
    private bool _isDarkMode = false;
    
    public bool IsDarkMode => _isDarkMode;
    
    public event Action? OnThemeChanged;

    public void ToggleTheme()
    {
        _isDarkMode = !_isDarkMode;
        OnThemeChanged?.Invoke();
    }

    public void SetTheme(bool isDarkMode)
    {
        _isDarkMode = isDarkMode;
        OnThemeChanged?.Invoke();
    }
}
