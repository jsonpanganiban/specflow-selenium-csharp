using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Jupiter.Tests.Pages
{
    public class CheckoutPage : Base, ICheckout
    {

        private readonly By _alertSuccessMessage = By.CssSelector("div.alert.alert-success");
        private readonly By _forenameTextBox = By.CssSelector("[name='forename']");
        private readonly By _emailTextBox = By.CssSelector("[name='email']");
        private readonly By _addressTextBox = By.CssSelector("[name='address']");
        private readonly By _cardTypeDropdown = By.CssSelector("[name='cardType']");
        private readonly By _cardTextBox = By.CssSelector("[name='card']");
        private readonly By _submitButton = By.CssSelector("#checkout-submit-btn");
        private readonly By _progressInfo = By.CssSelector(".progress.progress-info.wait");
        private readonly string successText = "your order has been accepted. Your order nuumber is";
        
        private int timeout = 30;

        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public void FillOutDeliveryDetails(string forename, string email, string address)
        {
            Driver.FindElement(_forenameTextBox).SendKeys(forename);
            Driver.FindElement(_emailTextBox).SendKeys(email);
            Driver.FindElement(_addressTextBox).SendKeys(address);
        }

        public void FillOutPaymentDetails(string cartType, string cardNumber)
        {
            SelectElement selectElement = new SelectElement(Driver.FindElement(_cardTypeDropdown));
            selectElement.SelectByText(cartType);
            Driver.FindElement(_cardTextBox).SendKeys(cardNumber);
        }

        public void SubmitOrder()
        {
            Driver.FindElement(_submitButton).Click();
        }

        public void VerifyOrderIsAccepted()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, timeout));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("")));
            var successMessage = Driver.FindElement(_alertSuccessMessage);
            Assert.True(successMessage.Displayed);
            Assert.True(successMessage.Text.Contains(successText));
        }
    }
}
