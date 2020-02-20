using Jupiter.Framework.Extensions;
using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;

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
            foreach (var item in TableExtensions.GetFirstColumnValues<string>(table))
            {
                _scenarioContext.SetContextKey(item, _shopPage.GetPrice(item));
            }
        }

        [When("I buy item")]
        public void WhenISelectItemToCart(Table table)
        {
            foreach (var item in TableExtensions.GetFirstColumnValues<string>(table))
            {
                _shopPage.Buy(item);
            }
        }
    }
}