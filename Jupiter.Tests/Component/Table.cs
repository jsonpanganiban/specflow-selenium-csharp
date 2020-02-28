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
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Config.Instance.Timeout));
            IWebElement tableElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".table")));
            var productTable = new List<Dictionary<string, IWebElement>>();

            IReadOnlyCollection<IWebElement> headerElems = tableElement.FindElements(By.TagName("th"));
            var columnHeaders = headerElems.Select(e => e.Text).ToList();

            IReadOnlyCollection<IWebElement> rowElements = tableElement.FindElements(By.TagName("tbody>tr"));

            foreach (IWebElement rowElement in rowElements)
            {
                var row = new Dictionary<string, IWebElement>();
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