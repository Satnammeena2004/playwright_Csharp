
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;


public class LoginTest : PageTest
{
    [Test]
    public async Task homePageTitleIsCorrect()
    {
        await Page.GotoAsync("https://demo.playwright.dev/todomvc");
        await Expect(Page).ToHaveTitleAsync("React • TodoMVC");
    }
}

