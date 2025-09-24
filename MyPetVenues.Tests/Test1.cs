using System;
using System.Text.RegularExpressions;
using Microsoft.Playwright.MSTest;

namespace MyPetVenues.Tests;

[TestClass]
public class HomePageTests : PageTest
{
    private static readonly string BaseUrl =
        Environment.GetEnvironmentVariable("TEST_BASE_URL")
        ?? "http://localhost:5039"; // matches launchSettings.json http profile

    [TestMethod]
    public async Task Home_Has_Hello_World_Heading()
    {
        // Navigate to the locally running Blazor app root
        await Page.GotoAsync(BaseUrl);

        // Assert the main heading text (case / optional ! tolerant)
        await Expect(Page.Locator("h1"))
            .ToHaveTextAsync(new Regex("^Hello, world!?$", RegexOptions.IgnoreCase));
    }
}
