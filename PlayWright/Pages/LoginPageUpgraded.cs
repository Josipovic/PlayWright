using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWright.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;
        public LoginPageUpgraded(IPage page) => _page = page;

        private ILocator _lnkLogin => _page.Locator("text=Login");
        private ILocator _txtUsername => _page.Locator("#UserName");
        private ILocator _txtPassword => _page.Locator("#Password");
        private ILocator _btnLogin => _page.Locator("text=Log in");
        private ILocator _lnkEmployeDetails => _page.Locator("text='Employee Details'");
        private ILocator _lnkEmployeeLists => _page.Locator("text='Employee List'");

        public async Task ClickLogin()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _lnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            }
            ); ;
        }

        public async Task ClickEmplyoeeList() => await _lnkEmployeeLists.ClickAsync();
        public async Task Login(string Username, string Password)
        {
            await _txtUsername.FillAsync(Username);
            await _txtPassword.FillAsync(Password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeDetails.IsVisibleAsync();

    }
}
