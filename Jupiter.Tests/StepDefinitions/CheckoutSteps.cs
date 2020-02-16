using Jupiter.Tests.Utilities;
using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private CheckoutPage checkoutPage;

        public CheckoutSteps(CheckoutPage checkoutPage)
        {
            this.checkoutPage = checkoutPage;
        }

        [When(@"I fill out delivery and payment details")]
        public void WHenIfillOutDeliveryAndPaymentDetails(Table table)
        {
            var dictionary = TableHelpersExtension.ConvertToDictionary(table);
            checkoutPage.FillOutDeliveryDetails(dictionary["Forename"], dictionary["Email"], dictionary["Address"]);
            checkoutPage.FillOutPaymentDetails(dictionary["Card Type"], dictionary["Card Number"]);
        }

        [When(@"I submit order")]
        public void WhenIsubmitOrder()
        {
            checkoutPage.SubmitOrder();
        }

        [Then(@"Success message should be displayed")]
        public void SuccessMessageShouldBeDisplayed()
        {
            checkoutPage.VerifyOrderIsAccepted();
        }
    }
}
