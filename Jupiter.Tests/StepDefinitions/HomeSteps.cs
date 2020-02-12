using Jupiter.Tests.Contracts;
using Jupiter.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private HomePage homePage;

        public HomeSteps(HomePage homePage)
        {
            this.homePage = homePage;
        }

        [Given(@"I visit Jupiter Toys page")]
        public void GivenINavigateToShoppingPage()
        {
            homePage.NavigateToJupiterToys();
        }

        [When(@"I navigate to Shopping page")]
        public void WHenINavigateToShoppingPage()
        {
            homePage.NagivateToShop();
        }

        [When(@"I navigate to Cart page")]
        public void WhenINavigateToCartPage()
        {
            homePage.NavigateToCart();
        }
    }
}
