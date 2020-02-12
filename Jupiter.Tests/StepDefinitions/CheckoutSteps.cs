using Jupiter.Tests.Utilities;
using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private ICheckout checkout;

        public CheckoutSteps(ICheckout checkout)
        {
            this.checkout = checkout;
        }

        [When(@"I fill out delivery and payment details")]
        public void WHenIfillOutDeliveryAndPaymentDetails(Table table)
        {
            var dictionary = TableHelpersExtension.ConvertToDictionary(table);
            checkout.FillOutDeliveryDetails(dictionary["Forename"], dictionary["Email"], dictionary["Address"]);
            checkout.FillOutPaymentDetails(dictionary["Card Type"], dictionary["Card Number"]);
        }

        [When(@"I submit order")]
        public void WhenIsubmitOrder()
        {
            checkout.SubmitOrder();
        }

        [Then(@"Success message should be displayed")]
        public void SuccessMessageShouldBeDisplayed()
        {
            checkout.VerifyOrderIsAccepted();
        }
    }
}
