using Microsoft.JSInterop;

namespace MyPetVenues.Services;

public sealed class ThemeService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private readonly Lazy<Task> _initTask;

    public string CurrentTheme { get; private set; } = "light";
    public event Action? OnChange;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _initTask = new(() => InitializeInternalAsync());
    }

    public Task InitializeAsync() => _initTask.Value;

    public async Task ToggleAsync()
    {
        await InitializeAsync();
        var next = CurrentTheme == "light" ? "dark" : "light";
        await SetThemeAsync(next);
    }

    public async Task SetThemeAsync(string theme)
    {
        await InitializeAsync();
        CurrentTheme = theme;
        await ApplyAsync(theme);
        OnChange?.Invoke();
    }

    private async Task InitializeInternalAsync()
    {
        var stored = await _jsRuntime.InvokeAsync<string?>("themeInterop.getTheme");
        var prefersDark = await _jsRuntime.InvokeAsync<bool>("themeInterop.prefersDark");
        CurrentTheme = string.IsNullOrWhiteSpace(stored) ? (prefersDark ? "dark" : "light") : stored;
        await ApplyAsync(CurrentTheme);
    }

    private async Task ApplyAsync(string theme)
    {
        await _jsRuntime.InvokeVoidAsync("themeInterop.applyTheme", theme);
        await _jsRuntime.InvokeVoidAsync("themeInterop.setTheme", theme);
    }

    public ValueTask DisposeAsync()
    {
        OnChange = null;
        return ValueTask.CompletedTask;
    }
}
