using BoDi;
using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class HomePage : Base, IHome
    {

        private readonly By shopLink = By.CssSelector("#nav-shop > a");
        private readonly By cartLink = By.CssSelector("#nav-cart > a");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void NagivateToShop()
        {
            Driver.FindElement(shopLink).Click();
        }

        public void NavigateToCart()
        {
            Driver.FindElement(cartLink).Click();
        }

        public void NavigateToJupiterToys()
        {
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/");
        }
    }
}
