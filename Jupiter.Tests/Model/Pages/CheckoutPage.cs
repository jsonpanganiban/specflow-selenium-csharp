﻿using Jupiter.Framework.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Jupiter.Tests.Model.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly By _alertSuccessMessage = By.CssSelector("div.alert.alert-success");
        private readonly By _forenameTextBox = By.Name("forename");
        private readonly By _emailTextBox = By.Name("email");
        private readonly By _addressTextBox = By.Name("address");
        private readonly By _cardTypeDropdown = By.Name("cardType");
        private readonly By _cardTextBox = By.Name("card");
        private readonly By _submitButton = By.CssSelector("#checkout-submit-btn");
        private readonly By _progressInfo = By.CssSelector(".progress.progress-info.wait");
        private const string successText = "your order has been accepted. Your order nuumber is";

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillOutDeliveryDetails(string forename, string email, string address)
        {
            WebDriver.FindElement(_forenameTextBox).SendKeys(forename);
            WebDriver.FindElement(_emailTextBox).SendKeys(email);
            WebDriver.FindElement(_addressTextBox).SendKeys(address);
        }

        public void FillOutPaymentDetails(string cartType, string cardNumber)
        {
            SelectElement selectElement = new SelectElement(WebDriver.FindElement(_cardTypeDropdown));
            selectElement.SelectByText(cartType);
            WebDriver.FindElement(_cardTextBox).SendKeys(cardNumber);
        }

        public void SubmitOrder()
        {
            WebDriver.FindElement(_submitButton).Click();
        }

        public void VerifyOrderIsAccepted(string forename)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Config.Instance.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_progressInfo));
            Assert.True(WebDriver.FindElement(_alertSuccessMessage).Text.Contains($"Thanks {forename}, {successText}"));
        }
    }
}