using Jupiter.Tests.Model.Tables;
using OpenQA.Selenium;
using System.Linq;

namespace Jupiter.Tests.Model.Pages
{
    public class CartPage : BasePage
    {
        public const string ItemColumn = "Item";
        public const string PriceColumn = "Price";
        public const string QuantityColumn = "Quantity";
        public const string SubtotalColumn = "Subtotal";

        private readonly By _checkoutButton = By.CssSelector("td>[href*='checkout']");
        private readonly By _cartTable = By.CssSelector("table.cart-items");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void UpdateQuantity(string productItem, string quantity)
        {
            Table cartTable = new Table(WebDriver.FindElement(_cartTable));
            var quantityTextbox = cartTable.GetCellValue(productItem, ItemColumn, QuantityColumn)
                        .FindElement(By.TagName("Input"));
            quantityTextbox.Clear();
            quantityTextbox.SendKeys(quantity);
        }

        public string GetPrice(string item)
        {
            Table cartTable = new Table(WebDriver.FindElement(_cartTable));
            return cartTable.GetCellValue(item, ItemColumn, PriceColumn).Text;
        }

        public string GetItemSubtotal(string item)
        {
            Table cartTable = new Table(WebDriver.FindElement(_cartTable));
            return cartTable.GetCellValue(item, ItemColumn, SubtotalColumn).Text;
        }

        public void ProceedToCheckOut()
        {
            WebDriver.FindElement(_checkoutButton).Click();
        }

    }
}
