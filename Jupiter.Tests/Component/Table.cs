using Jupiter.Framework.Configuration;
using Jupiter.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Component
{
    public class Table : BasePage
    {
        public Table(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement GetCellValue(string rowValue, string findColumn, string returnColumn)
        {
            var rowItem = GetTable().Where(r => r[findColumn].Text == rowValue).FirstOrDefault();
            return rowItem[returnColumn];
        }
 
        public List<Dictionary<string, IWebElement>> GetTable()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Config.Instance.Timeout));
            IWebElement tableElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementIsVisible(By.CssSelector("table.cart-items")));

            var productTable = new List<Dictionary<string, IWebElement>>();

            var columnHeaders = tableElement.FindElements(By.TagName("th")).Select(e => e.Text).ToList();

            foreach (IWebElement rowElement in tableElement.FindElements(By.TagName("tbody>tr")))
            {
                var row = new Dictionary<string, IWebElement>();
                int columnIndex = 0;
                foreach (var cellElem in rowElement.FindElements(By.TagName("td")))
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