




using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;

public class LoginTest : PageTest
{
    private readonly string BASE_URL = "https://practicesoftwaretesting.com";

    [SetUp]
    public async Task SetupNavigateToWebSite()
    {
        await Page.GotoAsync(BASE_URL + "/auth/login");
    }

    [Test]

    public async Task ValidLoginShouldRedirectToDashboard()
    {
        var email = Page.Locator("//input[@id='email']");
        var pass = Page.Locator("//input[@id='password']");
        var btn = Page.Locator("//input[@value='Login']");
        await email.FillAsync("xirovo4283@fengnu.com");
        await pass.FillAsync("Xirovo4283@fengnu.com");
        await btn.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*/account"));

    }
    [Test]
    public async Task InvalidLoginShould_ShowTheHelpMessage()
    {
        var email = Page.Locator("//input[@id='email']");
        var pass = Page.Locator("//input[@id='password']");
        var btn = Page.Locator("//input[@value='Login']");
        var help_message = Page.Locator("//div[@class='help-block']");
        await email.FillAsync("xir@fengnu.com");
        await pass.FillAsync("Xiroo.com");
        await btn.ClickAsync();
        await Expect(help_message).ToBeVisibleAsync();

    }

    [Test]
    public async Task EmptyFieldLogin_BlockLogin()
    {
        var btn = Page.Locator("//input[@value='Login']");
        await btn.ClickAsync();
        var email_error = Page.Locator("//div[@id='email-error']");
        await Expect(email_error).ToBeVisibleAsync();

    }
    [Test]
    public async Task ValidLogin_ThenLogout()
    {
        await ValidLoginShouldRedirectToDashboard();
        var menu = Page.Locator("//a[@id='menu']");
        await menu.ClickAsync();
        var log_out = Page.GetByText("Sign Out");
        await log_out.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*/login"));

    }


}