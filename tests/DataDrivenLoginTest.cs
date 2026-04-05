



using System.IO.Pipelines;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

public class TestDriveLoginTest : PageTest
{
    private readonly string BASE_URL = "https://practicesoftwaretesting.com";
    private readonly static object[] data =
    [
        new object[]{"wrong@email.com", "wrongpass", false},
        new object[]{"wrong2@email.com", "wrongpass2", false},
        new object[]{"xirovo4283@fengnu.com", "Xirovo4283@fengnu.com", true},
    ];
    [SetUp]

    public async Task Setup()
    {
        await Page.GotoAsync(BASE_URL + "/auth/login");
    }

    // [Test]
    // [TestCase("wrong@email.com", "wrongpass", false)]
    // [TestCase("wrong2@email.com", "wrongpass2", false)]
    // [TestCase("xirovo4283@fengnu.com", "Xirovo4283@fengnu.com", true)]

    // public async Task LoginTest(string email, string password, bool expected)
    // {
    //     var em = Page.Locator("//input[@id='email']");
    //     var pass = Page.Locator("//input[@id='password']");
    //     var btn = Page.Locator("//input[@value='Login']");
    //     await em.FillAsync(email);
    //     await pass.FillAsync(password);
    //     await btn.ClickAsync();
    //     if (expected)
    //     {
    //         await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*/account"));

    //     }
    //     else
    //     {
    //         await Expect(Page.GetByText("Invalid email or password")).ToBeVisibleAsync();
    //     }
    // }


    private static object[] ReadLoginData()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "LoginData.csv");
        var lines = File.ReadAllLines(filePath).Skip(1);
        var data = new List<object[]>();
        foreach (var line in lines)
        {
            var values = line.Split(",");
            string email = values[0];
            string password = values[1];
            bool expected = bool.Parse(values[2]);

            data.Add([email, password, expected]);

        }
        return data.ToArray();
    }

    [Test]
    [TestCaseSource(nameof(data))]
    public async Task LoginTestWithData(string email, string password, bool expected)
    {
        var em = Page.Locator("//input[@id='email']");
        var pass = Page.Locator("//input[@id='password']");
        var btn = Page.Locator("//input[@value='Login']");
        await em.FillAsync(email);
        await pass.FillAsync(password);
        await btn.ClickAsync();
        if (expected)
        {
            await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*/account"));

        }
        else
        {
            await Expect(Page.GetByText("Invalid email or password")).ToBeVisibleAsync();
        }
    }
    [Test]
    [TestCaseSource(nameof(ReadLoginData))]
    public async Task LoginTestWithCSVData(string email, string password, bool expected)
    {
        var em = Page.Locator("//input[@id='email']");
        var pass = Page.Locator("//input[@id='password']");
        var btn = Page.Locator("//input[@value='Login']");
        await em.FillAsync(email);
        await pass.FillAsync(password);
        await btn.ClickAsync();
        if (expected)
        {
            await Expect(Page).ToHaveURLAsync(new System.Text.RegularExpressions.Regex(".*/account"));

        }
        else
        {
            await Expect(Page.GetByText("Invalid email or password")).ToBeVisibleAsync();
        }
    }
}