using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPetVenues;
using MyPetVenues.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register services with interfaces for testability (Dependency Inversion Principle)
builder.Services.AddSingleton<IVenueRepository, MockVenueRepository>();
builder.Services.AddSingleton<IVenueService, VenueService>();

await builder.Build().RunAsync();
