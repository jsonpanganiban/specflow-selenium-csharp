using Jupiter.Framework.Extensions;
using Jupiter.Framework.Utilities;
using Jupiter.Tests.Model.Pages;
using Jupiter.Tests.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private readonly CartPage _cartPage;
        private readonly ScenarioContext _scenarioContext;

        public CartSteps(CartPage cartPage, ScenarioContext scenarioContext)
        {
            _cartPage = cartPage;
            _scenarioContext = scenarioContext;
        }

        [Then(@"Correct price for item is displayed")]
        public void CartShouldDisplayCorrectPriceForItem(Table table)
        {
            var products = table.CreateSet<ProductData>();
            foreach (var product in products)
            {
                var priceInCart = _cartPage.GetPrice(product.Item);
                Assert.AreEqual(priceInCart, _scenarioContext.GetContextKey(product.Item));
            }
        }

        [Given(@"I update quantity of item")]
        [When(@"I update quantity of item")]
        public void WhenIUpdateQuantityOfItem(Table table)
        {
            var products = table.CreateSet<ProductData>();
            foreach (var product in products)
            {
                _cartPage.UpdateQuantity(product.Item, product.Quantity);
                _scenarioContext.SetContextKey(product.Item, product.Quantity);
            }
        }

        [Then(@"Subtotal for each item should be correct")]
        public void ThenSubtotalForItemShouldBeCorrect(Table table)
        {
            var products = table.CreateSet<ProductData>();
            foreach (var product in products)
            {
                var priceItem = _cartPage.GetPrice(product.Item);
                var priceItemDbl = Convert.ToDouble(StringHelper.RemoveCurrency(priceItem));
                var priceItemTotal = priceItemDbl * Convert.ToDouble(_scenarioContext.GetContextKey(product.Item));
                var itemSubtotal = _cartPage.GetItemSubtotal(product.Item);
                Assert.AreEqual(StringHelper.RemoveCurrency(itemSubtotal), priceItemTotal.ToString());
            }
        }

        [Given(@"I proceed to check out")]
        public void WhenIProceedToCheckOut()
        {
            _cartPage.ProceedToCheckOut();
        }
    }
}
