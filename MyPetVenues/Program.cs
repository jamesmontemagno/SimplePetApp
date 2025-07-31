using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyPetVenues;
using MyPetVenues.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register community services
builder.Services.AddScoped<IReviewService, MockReviewService>();
builder.Services.AddScoped<ICommentService, MockCommentService>();
builder.Services.AddScoped<IEventService, MockEventService>();
builder.Services.AddScoped<IMessageService, MockMessageService>();

await builder.Build().RunAsync();
