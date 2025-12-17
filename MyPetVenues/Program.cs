using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPetVenues;
using MyPetVenues.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register application services
builder.Services.AddSingleton<IThemeService, ThemeService>();
builder.Services.AddSingleton<IVenueService, VenueService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IBookingService, BookingService>();

await builder.Build().RunAsync();
