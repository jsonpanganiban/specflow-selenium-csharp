using Jupiter.Tests.Utilities;
using Jupiter.Tests.Contracts;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {

        private readonly ICart cart;
        private readonly ScenarioContext scenarioContext;

        public CartSteps(ICart cart, ScenarioContext scenarioContext)
        {
            this.cart = cart;
            this.scenarioContext = scenarioContext;
        }
        
        [Then(@"Correct price for item is displayed")]
        public void CartShouldDisplayCorrectPriceForItem(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                var priceInCart = cart.GetPrice(item);
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
                cart.UpdateQuantity(item[0], item[1]);
            }
        }

        [Then(@"Subtotal for each item should be correct")]
        public void ThenSubtotalForItemTeddyBearShouldBeCorrect(Table table)
        {
            foreach (var item in table.Rows.Select(r => r[0]).ToArray())
            {
                var priceItem = cart.GetPrice(item);
                var priceItemDbl = Convert.ToDouble(StringHelper.RemoveCurrency(priceItem));
                var priceItemTotal = priceItemDbl * Convert.ToDouble(scenarioContext[item]);
                string itemSubtotal = cart.GetSubtotalPrice(item);
                Assert.AreEqual(StringHelper.RemoveCurrency(itemSubtotal), priceItemTotal.ToString());
            }
        }

        [Given(@"I proceed to check out")]
        public void WhenIProceedToCheckOut()
        {
            cart.ProceedToCheckOut();
        }
    }
}
