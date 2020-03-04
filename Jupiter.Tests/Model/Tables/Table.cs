using Jupiter.Framework.Base;
using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Model.Tables
{
    public class Table
    {
        private IWebElement webElement;

        public Table(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public IWebElement GetCellValue(string rowValue, string findColumn, string returnColumn)
        {
            var rowItem = GetTable().Where(r => r[findColumn].Text == rowValue).FirstOrDefault();
            return rowItem[returnColumn];
        }
 
        private List<Dictionary<string, IWebElement>> GetTable()
        {
            var productTable = new List<Dictionary<string, IWebElement>>();
            var columnHeaders = webElement.FindElements(By.TagName("th")).Select(e => e.Text).ToList();

            foreach (IWebElement rowElement in webElement.FindElements(By.TagName("tbody>tr")))
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