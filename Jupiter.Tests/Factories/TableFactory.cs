using Jupiter.Tests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jupiter.Tests.Factories
{
    public class TableFactory : Base
    {
        private int waitTime = 5;

        public TableFactory(IWebDriver driver) : base(driver)
        {
        }

        public ReadOnlyCollection<IWebElement> GetRowItem(int tableIndex = 0)
        {
            return GetWebElements(Driver, By.TagName("tbody"))[tableIndex].FindElements(By.TagName("tr"));
        }

        private ReadOnlyCollection<IWebElement> GetWebElements(IWebDriver driver, By by)
        {
            for (var i = 0; i < waitTime; i++)
            {
                try
                {
                    return driver.FindElements(by);
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
            }
            throw new Exception("Elements not found: '" + by + "'");
        }
        }
    }
