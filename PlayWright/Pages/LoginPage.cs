using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWright.Pages
{
    public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _lnkLogin;

        private readonly ILocator _txtUsername;

        private readonly ILocator _txtPassword;

        private readonly ILocator _btnLogin;

        private readonly ILocator _lnkEmployeeDetails;
        public LoginPage(IPage page)
        {
            _page = page;
            _lnkLogin = _page.Locator("text=Login");
            _txtUsername = _page.Locator("#UserName");
            _txtPassword = _page.Locator("#Password");
            _btnLogin = _page.Locator("text=Log in");
            _lnkEmployeeDetails = _page.Locator("text='Employee Details'");
        }

        public async Task ClickLogin()=>await _lnkLogin.ClickAsync();

    

        public async Task Login(string Username, string Password)
        {
            await _txtUsername.FillAsync(Username);
            await _txtPassword.FillAsync(Password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();

    }
}
