using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPetVenues;
using MyPetVenues.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("MyPetVenues", client =>
{
	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddScoped(sp =>
	sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyPetVenues"));

builder.Services.AddSingleton<IVenueService, MockVenueService>();

await builder.Build().RunAsync();
