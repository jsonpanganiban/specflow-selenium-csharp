using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Jupiter.Framework.Base
{
    public abstract class Base
    {
        public IWebDriver WebDriver { get; }

        public Base(IWebDriver driver)
        {
            WebDriver = driver;
        }
    }
}
