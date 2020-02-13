using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jupiter.Tests.Pages
{
    public class CartPage : Base, ICart, IProduct
    {

        private readonly By _checkoutButton = By.CssSelector("td>[href*='checkout']");
        private Dictionary<string, IWebElement> rowItem;
        private string productPrice;
        private string productSubtotalPrice;

        public CartPage(IWebDriver Driver) : base(Driver) { }

        public string GetPrice(string productItem)
        {
            var productPrice = GetRowOf(productItem)["Price"];
            return productPrice.Text;
        }

        public string GetSubtotalPrice(string productItem)
        {
            var productSubtotalPrice = GetRowOf(productItem)["Subtotal"];
            return productSubtotalPrice.Text;
        }
            
        public void UpdateQuantity(string productItem, string quantity)
        {
            var quantityTextbox = GetRowOf(productItem)["Quantity"].FindElement(By.TagName("Input"));
            quantityTextbox.Clear();
            quantityTextbox.SendKeys(quantity);
        }

        public void ProceedToCheckOut()
        {
            Driver.FindElement(_checkoutButton).Click();
        }

        private Dictionary<string, IWebElement> GetRowOf(string productItem)
        {
            var rowItem = GetCartItemTable().Where(r => r["Item"].Text == productItem).FirstOrDefault();
            return rowItem;
        }

        public List<Dictionary<string, IWebElement>> GetCartItemTable()
        {
            IWebElement tableElement = Driver.FindElement(By.CssSelector(".table"));
            List<Dictionary<string, IWebElement>> productTable = new List<Dictionary<string, IWebElement>>();
            IList<IWebElement> rowElements = tableElement.FindElements(By.TagName("tbody>tr"));

            List<string> columnHeaders = new List<string>();
            IList<IWebElement> headerElems = tableElement.FindElements(By.TagName("th"));

            foreach (var elem in headerElems)
            {
                columnHeaders.Add(elem.Text);
            }

            foreach (IWebElement rowElement in rowElements)
            {
                Dictionary<string, IWebElement> row = new Dictionary<string, IWebElement>();

                int columnIndex = 0;
                IList<IWebElement> cellElements = rowElement.FindElements(By.TagName("td"));
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
