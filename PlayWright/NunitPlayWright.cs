using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlayWright.Pages;
using System.Web;

namespace PlayWright
{
    public class NunitPlaywright : PageTest
    {
        [SetUp]
        public async Task SetupAsync()
        {
            //await Page.GotoAsync("http://www.eaapp.somee.com/", new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
        }

        [Test]
        public async Task Test1()
        {
            Page.SetDefaultTimeout(5000);
            ILocator lnkLogin = Page.Locator("text=Login");

            await lnkLogin.ClickAsync();
            //await Page.ClickAsync("text=Login");

         

            await Page.FillAsync("#UserName","admin");
            await Page.FillAsync("#Password","password");

            ILocator btnLogin = Page.Locator("button", new PageLocatorOptions {HasTextString="Log in" });

            await btnLogin.ClickAsync();
            //await Page.ClickAsync("text=Log in");

            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout =5000}); 

           
        }
        [Test]
        public async Task TestWithPOM() 
        {
            LoginPage loginpage = new LoginPage(Page);

            await loginpage.ClickLogin();
            await loginpage.Login("admin","password");
     
            Assert.IsTrue(await loginpage.IsEmployeeDetailsExists());
        }

        [Test]
        public async Task TestNetwork()
        {
            LoginPageUpgraded loginpage = new LoginPageUpgraded(Page);

            await loginpage.ClickLogin();

            await loginpage.Login("admin", "password");

            var waitResponse = Page.WaitForResponseAsync("**/Employee");
            await loginpage.ClickEmplyoeeList();
            var getResponse = await waitResponse;

            var response = await Page.RunAndWaitForResponseAsync(async () =>
            {
                await loginpage.ClickEmplyoeeList();
            }, x => x.Url.Contains("/Employee") && x.Status==200);


            Assert.IsTrue(await loginpage.IsEmployeeDetailsExists());

        }

        [Test]
        public async Task FlipKart()
        {
            await Page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
            await Page.Locator("text=x").ClickAsync();
            await Page.Locator("a", new PageLocatorOptions { HasTextString = "Login" }).ClickAsync();


            var request = await Page.RunAndWaitForRequestAsync(async () =>
            {
                await Page.Locator("text=x").ClickAsync(); 
            }, x => x.Url.Contains("flipkart.d1.sc.omtrdc.net") && x.Method == "GET");

            var returnData = HttpUtility.UrlDecode(request.Url);


        }
    }
}