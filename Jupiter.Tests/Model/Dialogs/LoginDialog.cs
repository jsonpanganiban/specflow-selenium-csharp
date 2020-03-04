using Jupiter.Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Jupiter.Tests.Dialogs
{
    public class LoginDialog : BaseDialog
    {

        private readonly By _usernameTextbox = By.CssSelector("#loginUserName");
        private readonly By _passwordTextbox = By.CssSelector("#loginPassword");
        private readonly By _loginErrorMessage = By.CssSelector("#login-error");
        private readonly By _submitButton = By.CssSelector(".btn-primary");

        public LoginDialog(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            WebDriver.FindElement(_usernameTextbox).SendKeys(username);
            WebDriver.FindElement(_passwordTextbox).SendKeys(password);
            SubmitForm();
        }

        public IWebElement GetLoginErrorMessage()
        {
            return WebDriver.FindElement(_loginErrorMessage);
        }
    }
}
