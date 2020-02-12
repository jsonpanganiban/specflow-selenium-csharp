using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class CartPage : Base, ICart, IProduct
    {

        private readonly By _itemLabel = By.CssSelector("tr.cart-item.ng-scope>td:nth-child(1)");
        private readonly By _priceLabel = By.CssSelector("tr.cart-item.ng-scope>td:nth-child(2)");
        private readonly By _updateQuantityTextBox = By.CssSelector("tr.cart-item.ng-scope>td:nth-child(3)>input");
        private readonly By _subtotalPriceLabel = By.CssSelector("tr.cart-item.ng-scope>td:nth-child(4)");
        private readonly By _checkoutButton = By.CssSelector("td>[href*='checkout']");

        public CartPage(IWebDriver Driver) : base(Driver) { }


        public string GetPrice(string item)
        {
            IList<IWebElement> priceListElems = Driver.FindElements(_priceLabel);
            return priceListElems[this.GetIndexOf(item)].Text;
        }

        public string GetSubtotalPrice(string item)
        {
            IList<IWebElement> subtotalPriceListElems = Driver.FindElements(_subtotalPriceLabel);
            return subtotalPriceListElems[this.GetIndexOf(item)].Text;
        }

        public void UpdateQuantity(string item, string quantity)
        {
            var itemQuantity = Driver.FindElements(_updateQuantityTextBox)[this.GetIndexOf(item)];
            itemQuantity.Clear();
            itemQuantity.SendKeys(quantity);
        }

        public void ProceedToCheckOut()
        {
            Driver.FindElement(_checkoutButton).Click();
        }

        private int GetIndexOf(string item)
        {
            IList<IWebElement> itemListElems = Driver.FindElements(_itemLabel);
            return itemListElems.IndexOf(itemListElems.Single(i => i.Text.Contains(item)));
        }
    }
}
