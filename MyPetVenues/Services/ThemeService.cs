using Microsoft.JSInterop;

namespace MyPetVenues.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private bool _isDarkMode;

    public event Action? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public bool IsDarkMode => _isDarkMode;

    public async Task InitializeAsync()
    {
        _isDarkMode = await _jsRuntime.InvokeAsync<bool>("themeManager.getTheme");
    }

    public async Task ToggleThemeAsync()
    {
        _isDarkMode = !_isDarkMode;
        await _jsRuntime.InvokeVoidAsync("themeManager.setTheme", _isDarkMode);
        OnThemeChanged?.Invoke();
    }
}
