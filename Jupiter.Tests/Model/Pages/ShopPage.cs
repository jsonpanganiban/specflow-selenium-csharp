﻿using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jupiter.Tests.Model.Pages
{
    public class ShopPage : BasePage
    {
        private readonly By _productScope = By.CssSelector("li.product");
        private readonly By _successButton = By.CssSelector(".btn-success");
        private readonly By _productPriceTextbox = By.CssSelector(".product-price");

        public ShopPage(IWebDriver driver) : base(driver)
        {
        }

        public void Buy(string item)
        {
            var productElement = GetItemElement(item).FindElement(_successButton);
            productElement.Click();
        }

        public string GetPrice(string item)
        {
            var productPrice = GetItemElement(item).FindElement(_productPriceTextbox);
            return productPrice.Text;
        }

        private IWebElement GetItemElement(string item)
        {
            return WebDriver.FindElements(_productScope).Single(i => i.Text.Contains(item));
        }
    }
}