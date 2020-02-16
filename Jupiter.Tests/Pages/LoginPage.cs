using NUnit.Framework;
using OpenQA.Selenium;

namespace Jupiter.Tests.Pages
{
    public class LoginPage : Base
    {
        private readonly By usernameTextbox = By.CssSelector("#loginUserName");
        private readonly By passwordTextbox = By.CssSelector("#loginPassword");
        private readonly By loginButton = By.CssSelector(".btn-primary");
        private readonly By loginErrorMessage = By.CssSelector("#login-error");
        private readonly By loingForm = By.CssSelector("#loginForm");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            Driver.FindElement(usernameTextbox).SendKeys(username);
            Driver.FindElement(passwordTextbox).SendKeys(password);
            Driver.FindElement(loginButton).Click();
        }

        public void ValidateLoginSuccessful()
        {
            Assert.True(!Driver.FindElement(loginErrorMessage).Displayed);
        }

        public void ValidateInvalidLogin(string message)
        {
            Assert.True(Driver.FindElement(loginErrorMessage).Displayed);
            Assert.True(Driver.FindElement(loginErrorMessage).Text.ToString().Equals(message));
        }
    }
}
