using Jupiter.Framework.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Jupiter.Tests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameTextbox = By.CssSelector("#loginUserName");
        private readonly By _passwordTextbox = By.CssSelector("#loginPassword");
        private readonly By _loginButton = By.CssSelector(".btn-primary");
        private readonly By _loginErrorMessage = By.CssSelector("#login-error");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            Driver.FindElement(_usernameTextbox).SendKeys(username);
            Driver.FindElement(_passwordTextbox).SendKeys(password);
            Driver.FindElement(_loginButton).Click();
        }

        public void ValidateLoginSuccessful()
        {
            Assert.True(Driver.FindElement(_loginErrorMessage).Displayed);
        }

        public void ValidateInvalidLogin(string message)
        {
            Assert.True(Driver.FindElement(_loginErrorMessage).Displayed);
            Assert.True(Driver.FindElement(_loginErrorMessage).Text.Equals(message));
        }
    }
}
