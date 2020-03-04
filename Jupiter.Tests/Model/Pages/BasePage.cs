using Jupiter.Framework.Base;
using OpenQA.Selenium;

namespace Jupiter.Tests.Model.Pages
{
    public class BasePage : Base
    { 
        private readonly By shopLink = By.CssSelector("#nav-shop");
        private readonly By cartLink = By.CssSelector("#nav-cart");
        private readonly By loginLink = By.CssSelector("#nav-login");

        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToLogin()
        {
            WebDriver.FindElement(loginLink).Click();
        }

        public void NagivateToShop()
        {
            WebDriver.FindElement(shopLink).Click();
        }

        public void NavigateToCart()
        {
            WebDriver.FindElement(cartLink).Click();
        }
    }
}