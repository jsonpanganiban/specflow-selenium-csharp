using Jupiter.Framework.Extensions;
using Jupiter.Framework.Utilities;
using Jupiter.Tests.Pages;
using NUnit.Framework;
using System;
using System.Linq;
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
            foreach (var item in TableExtensions.GetFirstColumnValues<string>(table))
            {
                var priceInCart = _cartPage.GetValueBasedOnColumnName(item, CartPage.ItemColumn, CartPage.PriceColumn);
                Assert.AreEqual(priceInCart, _scenarioContext.GetContextKey(item));
            }
        }

        [Given(@"I update quantity of item")]
        [When(@"I update quantity of item")]
        public void WhenIUpdateQuantityOfItem(Table table)
        {
            var data = table.CreateSet<ProductData>();
            foreach (var product in data)
            {
                _cartPage.UpdateQuantity(product.Item, product.Quantity);
                _scenarioContext.SetContextKey(product.Item, product.Quantity);
            }
        }

        [Then(@"Subtotal for each item should be correct")]
        public void ThenSubtotalForItemShouldBeCorrect(Table table)
        {
            var data = table.CreateSet<ProductData>();
            foreach (var product in data)
            {
                string priceItem = _cartPage.GetValueBasedOnColumnName(product.Item, CartPage.ItemColumn, CartPage.PriceColumn);
                var priceItemDbl = Convert.ToDouble(StringHelper.RemoveCurrency(priceItem));
                var priceItemTotal = priceItemDbl * Convert.ToDouble(_scenarioContext.GetContextKey(product.Item));
                
                string itemSubtotal = _cartPage.GetValueBasedOnColumnName(product.Item, CartPage.ItemColumn, CartPage.SubtotalColumn);
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
