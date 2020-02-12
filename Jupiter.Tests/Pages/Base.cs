using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Jupiter.Tests.Pages
{
    public abstract class Base
    {
        public IWebDriver Driver { get; }

        public Base(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
