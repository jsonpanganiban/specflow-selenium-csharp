using Jupiter.Framework.Base;
using Jupiter.Framework.Configuration;
using Jupiter.Tests.Component;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class CartPage : Table
    {
        public const string ItemColumn = "Item";
        public const string PriceColumn = "Price";
        public const string QuantityColumn = "Quantity";
        public const string SubtotalColumn = "Subtotal";

        private readonly By _checkoutButton = By.CssSelector("td>[href*='checkout']");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void UpdateQuantity(string productItem, string quantity)
        {
            var quantityTextbox = GetCellValue(productItem, ItemColumn, QuantityColumn)
                        .FindElement(By.TagName("Input"));
            quantityTextbox.Clear();
            quantityTextbox.SendKeys(quantity);
        }

        public string GetPrice(string item)
        {
            return GetCellValue(item, ItemColumn, PriceColumn).Text;
        }

        public string GetItemSubtotal(string item)
        {
            return GetCellValue(item, ItemColumn, SubtotalColumn).Text;
        }

        public void ProceedToCheckOut()
        {
            WebDriver.FindElement(_checkoutButton).Click();
        }

    }
}
