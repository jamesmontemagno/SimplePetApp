using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPetVenues;
using MyPetVenues.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register mock services as singletons to maintain state across the app
builder.Services.AddSingleton<MockVenueService>();
builder.Services.AddSingleton<IVenueService>(sp => sp.GetRequiredService<MockVenueService>());
builder.Services.AddSingleton<IReviewService>(sp => sp.GetRequiredService<MockVenueService>());

await builder.Build().RunAsync();
