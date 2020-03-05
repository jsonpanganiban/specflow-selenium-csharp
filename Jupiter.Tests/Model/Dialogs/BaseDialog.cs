using Jupiter.Framework.Base;
using OpenQA.Selenium;
using System;

namespace Jupiter.Tests.Dialogs
{
    public class BaseDialog : Base
    {
        private readonly By _submitButton = By.CssSelector(".btn-primary");

        public BaseDialog(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitForm()
        {
            WebDriver.FindElement(_submitButton).Click();
        }
    }
}
