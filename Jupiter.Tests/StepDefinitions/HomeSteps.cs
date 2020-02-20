using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private readonly HomePage _homePage;

        public HomeSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [Given(@"I navigate to Login")]
        public void Login()
        {
            _homePage.NavigateToLogin();
        }

        [Given(@"I navigate to Shopping page")]
        [When(@"I navigate to Shopping page")]
        public void WHenINavigateToShoppingPage()
        {
            _homePage.NagivateToShop();
        }

        [When(@"I navigate to Cart page")]
        public void WhenINavigateToCartPage()
        {
            _homePage.NavigateToCart();
        }
    }
}