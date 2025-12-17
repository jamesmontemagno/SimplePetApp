using Microsoft.JSInterop;

namespace MyPetVenues.Services;

public interface IThemeService
{
    bool IsDarkMode { get; }
    event Action? OnThemeChanged;
    Task ToggleThemeAsync();
    Task SetThemeAsync(bool isDarkMode);
    Task InitializeAsync();
}

public class ThemeService : IThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private bool _isDarkMode = false;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public bool IsDarkMode => _isDarkMode;
    
    public event Action? OnThemeChanged;

    public async Task InitializeAsync()
    {
        // Check for saved preference or system preference
        try
        {
            var savedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
            if (!string.IsNullOrEmpty(savedTheme))
            {
                _isDarkMode = savedTheme == "dark";
            }
            else
            {
                // Check system preference
                _isDarkMode = await _jsRuntime.InvokeAsync<bool>("eval", 
                    "window.matchMedia('(prefers-color-scheme: dark)').matches");
            }
            await ApplyThemeAsync();
        }
        catch
        {
            // Ignore errors during initialization
        }
    }

    public async Task ToggleThemeAsync()
    {
        _isDarkMode = !_isDarkMode;
        await ApplyThemeAsync();
        OnThemeChanged?.Invoke();
    }

    public async Task SetThemeAsync(bool isDarkMode)
    {
        if (_isDarkMode != isDarkMode)
        {
            _isDarkMode = isDarkMode;
            await ApplyThemeAsync();
            OnThemeChanged?.Invoke();
        }
    }

    private async Task ApplyThemeAsync()
    {
        try
        {
            if (_isDarkMode)
            {
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.add('dark')");
            }
            else
            {
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.remove('dark')");
            }
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", _isDarkMode ? "dark" : "light");
        }
        catch
        {
            // Ignore JS interop errors
        }
    }
}
