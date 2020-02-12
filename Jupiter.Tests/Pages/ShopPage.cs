using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class ShopPage : Base, IShop
    {

        private const string productScope = ".product.ng-scope>div";

        public ShopPage(IWebDriver Driver) : base(Driver) { }

        public void Buy(string item)
        {
            IList<IWebElement> productLinkListElems = Driver.FindElements(By.CssSelector(string.Concat(productScope, ">p>a")));
            productLinkListElems[this.GetIndex(item)].Click();
        }

        public string GetPrice(string item)
        {
            IList<IWebElement> productPriceListElems = Driver.FindElements(By.CssSelector(string.Concat(productScope, ">p>span")));
            return productPriceListElems[this.GetIndex(item)].Text;
        }

        private int GetIndex(string item)
        {
            IList<IWebElement> productListElems = Driver.FindElements(By.CssSelector(productScope));
            return productListElems.IndexOf(productListElems.Single(i => i.Text.Contains(item)));
        }
    }
}
