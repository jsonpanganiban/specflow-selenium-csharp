using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private readonly BasePage _basePage;

        public HomeSteps(BasePage basePage)
        {
            _basePage = basePage;
        }

        [Given(@"I navigate to Login")]
        public void Login()
        {
            _basePage.NavigateToLogin();
        }

        [Given(@"I navigate to Shopping page")]
        [When(@"I navigate to Shopping page")]
        public void WHenINavigateToShoppingPage()
        {
            _basePage.NagivateToShop();
        }

        [When(@"I navigate to Cart page")]
        public void WhenINavigateToCartPage()
        {
            _basePage.NavigateToCart();
        }
    }
}