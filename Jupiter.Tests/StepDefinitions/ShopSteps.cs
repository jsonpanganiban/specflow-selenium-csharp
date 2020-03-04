using Jupiter.Framework.Extensions;
using Jupiter.Tests.Model.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class ShopSteps
    {
        private readonly ShopPage _shopPage;
        private readonly ScenarioContext _scenarioContext;

        public ShopSteps(ShopPage shopPage, ScenarioContext scenarioContext)
        {
            _shopPage = shopPage;
            _scenarioContext = scenarioContext;
        }

        [When(@"I capture item price")]
        public void GetTheItemPrice(Table table)
        {
            var products = table.CreateSet<ProductData>();
            foreach (var product in products)
            {
                _scenarioContext.SetContextKey(product.Item, _shopPage.GetPrice(product.Item));
            }
        }

        [When("I buy item")]
        public void WhenISelectItemToCart(Table table)
        {
            var products = table.CreateSet<ProductData>();
            foreach (var product in products)
            {
                _shopPage.Buy(product.Item);
            }
        }
    }
}