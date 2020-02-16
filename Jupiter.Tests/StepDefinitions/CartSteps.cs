using Jupiter.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Jupiter.Tests.Pages;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private CartPage cartPage;
        private readonly ScenarioContext scenarioContext;

        public CartSteps(CartPage cartPage, ScenarioContext scenarioContext)
        {
            this.cartPage = cartPage;
            this.scenarioContext = scenarioContext;
        }
        
        [Then(@"Correct price for item is displayed")]
        public void CartShouldDisplayCorrectPriceForItem(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                var priceInCart = cartPage.GetPrice(item);
                Assert.AreEqual(priceInCart, scenarioContext[item], $"");
            }
        }

        [Given(@"I update quantity of item")]
        [When(@"I update quantity of item")]
        public void WhenIUpdateQuantityOfItem(Table table)
        {
            foreach (var item in table.Rows)
            {
                scenarioContext[item[0]] = item[1];
                cartPage.UpdateQuantity(item[0], item[1]);
            }
        }

        [Then(@"Subtotal for each item should be correct")]
        public void ThenSubtotalForItemTeddyBearShouldBeCorrect(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                var priceItem = cartPage.GetPrice(item);
                var priceItemDbl = Convert.ToDouble(StringHelper.RemoveCurrency(priceItem));
                var priceItemTotal = priceItemDbl * Convert.ToDouble(scenarioContext[item]);
                string itemSubtotal = cartPage.GetSubtotalPrice(item);
                Assert.AreEqual(StringHelper.RemoveCurrency(itemSubtotal), priceItemTotal.ToString());
            }
        }

        [Given(@"I proceed to check out")]
        public void WhenIProceedToCheckOut()
        {
            cartPage.ProceedToCheckOut();
        }
    }
}
