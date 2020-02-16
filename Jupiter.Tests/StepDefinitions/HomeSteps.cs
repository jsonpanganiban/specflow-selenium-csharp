using Jupiter.Tests.Pages;
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

        [Given(@"I navigate to Login")]
        public void Login()
        {
            homePage.NavigateToLogin();
        }

        [Given(@"I navigate to Shopping page")]
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
