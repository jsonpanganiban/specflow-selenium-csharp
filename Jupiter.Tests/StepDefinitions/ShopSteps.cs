using Jupiter.Tests.Contracts;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class ShopSteps
    {
        private readonly IShop shop;
        private readonly ScenarioContext scenarioContext;

        public ShopSteps(IShop shop, ScenarioContext scenarioContext)
        {
            this.shop = shop;
            this.scenarioContext = scenarioContext;
        }

        [When(@"I capture item price")]
        public void GetTheItemPrice(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                scenarioContext[item] = shop.GetPrice(item);
            }
        }

        [When("I buy item")]
        public void WhenISelectItemToCart(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                shop.Buy(item);
            }
        }
    }
}
