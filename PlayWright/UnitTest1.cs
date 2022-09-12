using Microsoft.Playwright;


namespace PlayWright
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public async Task Test1()
        {
            //Playwright
            IPlaywright playwright = await Playwright.CreateAsync();

            //Browser
            await using IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            }); 

            //Page
            IPage page = await browser.NewPageAsync();

            await page.GotoAsync("http://www.eaapp.somee.com/");

            await page.ClickAsync("text=Login");

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path="screesnhot.jpg"
            });

            await page.FillAsync("#UserName","admin");
            await page.FillAsync("#Password","password");

            await page.ClickAsync("text=Log in");

            Assert.IsTrue(await page.Locator("text='Employee Details'").IsVisibleAsync());
        }
    }
}