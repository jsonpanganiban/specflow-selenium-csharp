using Jupiter.Framework.Base;
using OpenQA.Selenium;

namespace Jupiter.Tests.Pages
{
    public class HomePage : BasePage
    { 
        private readonly By shopLink = By.CssSelector("#nav-shop");
        private readonly By cartLink = By.CssSelector("#nav-cart");
        private readonly By loginLink = By.CssSelector("#nav-login");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToLogin()
        {
            Driver.FindElement(loginLink).Click();
        }

        public void NagivateToShop()
        {
            Driver.FindElement(shopLink).Click();
        }

        public void NavigateToCart()
        {
            Driver.FindElement(cartLink).Click();
        }
    }
}