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
            IList<IWebElement> productLinkList = Driver.FindElements(By.CssSelector(string.Concat(productScope, ">p>a")));
            productLinkList[this.GetIndex(item)].Click();
        }

        public string GetPrice(string item)
        {
            IList<IWebElement> productPriceList = Driver.FindElements(By.CssSelector(string.Concat(productScope, ">p>span")));
            return productPriceList[this.GetIndex(item)].Text;
        }

        private int GetIndex(string item)
        {
            IList<IWebElement> productList = Driver.FindElements(By.CssSelector(productScope));
            return productList.IndexOf(productList.Single(i => i.Text.Contains(item)));
        }
    }
}
