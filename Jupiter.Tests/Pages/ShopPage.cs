using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class ShopPage : Base, IShop
    {
        private const string productScope = "li.product";

        public ShopPage(IWebDriver Driver) : base(Driver) { }

        public void Buy(string item)
        {
            var productElement = GetItemElement(item).FindElement(By.CssSelector(".btn-success"));
            productElement.Click();
        }

        public string GetPrice(string item)
        {
            var productPrice = GetItemElement(item).FindElement(By.CssSelector(".product-price"));
            return productPrice.Text;
        }

        private IWebElement GetItemElement(string item)
        {
            IList<IWebElement> productListElems = Driver.FindElements(By.CssSelector(productScope));
            int productIndex = productListElems.IndexOf(productListElems.Single(i => i.Text.Contains(item)));
            return productListElems[productIndex];
        }
    }
}
