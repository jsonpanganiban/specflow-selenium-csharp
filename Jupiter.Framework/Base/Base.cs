using OpenQA.Selenium;

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
