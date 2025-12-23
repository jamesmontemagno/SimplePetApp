using Microsoft.JSInterop;

namespace MyPetVenues.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private string _currentTheme = "light";
    
    public event Action? OnThemeChanged;
    
    public string CurrentTheme => _currentTheme;
    
    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task InitializeAsync()
    {
        try
        {
            _currentTheme = await _jsRuntime.InvokeAsync<string>("themeManager.getTheme");
        }
        catch
        {
            _currentTheme = "light";
        }
    }
    
    public async Task ToggleThemeAsync()
    {
        _currentTheme = _currentTheme == "light" ? "dark" : "light";
        await _jsRuntime.InvokeVoidAsync("themeManager.setTheme", _currentTheme);
        OnThemeChanged?.Invoke();
    }
    
    public async Task SetThemeAsync(string theme)
    {
        _currentTheme = theme;
        await _jsRuntime.InvokeVoidAsync("themeManager.setTheme", _currentTheme);
        OnThemeChanged?.Invoke();
    }
}
