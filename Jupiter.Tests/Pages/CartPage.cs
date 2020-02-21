using Jupiter.Framework.Base;
using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class CartPage : BasePage
    {
        public static string ItemColumn = "Item";
        public static string PriceColumn = "Price";
        public static string QuantityColumn = "Quantity";
        public static string SubtotalColumn = "Subtotal";

        private readonly By _checkoutButton = By.CssSelector("td>[href*='checkout']");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void UpdateQuantity(string productItem, string quantity)
        {
            var quantityTextbox = GetRowOf(productItem, ItemColumn)[QuantityColumn].FindElement(By.TagName("Input"));
            quantityTextbox.Clear();
            quantityTextbox.SendKeys(quantity);
        }

        public void ProceedToCheckOut()
        {
            Driver.FindElement(_checkoutButton).Click();
        }

        public IWebElement GetCellValue(string rowValue, string referenceColumn, string returnColumn)
        {
            return GetRowOf(rowValue, referenceColumn)[returnColumn];
        }

        private Dictionary<string, IWebElement> GetRowOf(string rowValue, string referenceColumn)
        {
            var rowItem = GetCartItemTable().Where(r => r[referenceColumn].Text == rowValue).FirstOrDefault();
            return rowItem;
        }

        public List<Dictionary<string, IWebElement>> GetCartItemTable()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Config.Instance.Timeout));
            IWebElement tableElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".table")));
            List<Dictionary<string, IWebElement>> productTable = new List<Dictionary<string, IWebElement>>();
            IReadOnlyCollection<IWebElement> rowElements = tableElement.FindElements(By.TagName("tbody>tr"));

            IReadOnlyCollection<IWebElement> headerElems = tableElement.FindElements(By.TagName("th"));
            List<string> columnHeaders = headerElems.Select(e => e.Text).ToList();

            foreach (IWebElement rowElement in rowElements)
            {
                Dictionary<string, IWebElement> row = new Dictionary<string, IWebElement>();
                IReadOnlyCollection<IWebElement> cellElements = rowElement.FindElements(By.TagName("td"));

                int columnIndex = 0;
                foreach (var cellElem in cellElements)
                {
                    row.Add(columnHeaders[columnIndex], cellElem);
                    columnIndex++;
                }
                productTable.Add(row);
            }
            return productTable;
        }
    }
}
