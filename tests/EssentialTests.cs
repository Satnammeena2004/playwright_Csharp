
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace EssentialTests;

public class EssentialTests : PageTest
{
    [Test]
    public async Task HomePageTitleIsCorrect()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc");
        await Expect(Page).ToHaveTitleAsync("React • TodoMVC");
    }

    [Test]
    public async Task NaviagationMenuIsVisible()
    {
        await Page.GotoAsync("https://practicesoftwaretesting.com");
        var nav = Page.Locator("nav");
        await Expect(nav).ToBeVisibleAsync();

    }

    [Test]
    public async Task ScreenShotOnLoad()
    {
        await Page.GotoAsync("https://practicesoftwaretesting.com");
        var parent = Directory.GetParent(Directory.GetCurrentDirectory());
        var path = Path.Combine(
    AppContext.BaseDirectory, "..", "..", "..", "Artifacts", "home.png"
);
        await Page.ScreenshotAsync(new() { Path = path });

        Assert.Pass("Screetshot captrued successfully");
    }
}

