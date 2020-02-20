using Jupiter.Tests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly CheckoutPage _checkoutPage;
        private readonly PaymentData _paymentData;

        public CheckoutSteps(CheckoutPage checkoutPage, PaymentData paymentData)
        {
            _checkoutPage = checkoutPage;
            _paymentData = paymentData;
        }

        [When(@"I fill out delivery and payment details")]
        public void WHenIfillOutDeliveryAndPaymentDetails(Table table)
        {
            var data = table.CreateInstance<PaymentData>();
            _checkoutPage.FillOutDeliveryDetails(data.Forename, data.Email, data.Address);
            _checkoutPage.FillOutPaymentDetails(data.CardType, data.CardNumber);
            _paymentData.Forename = data.Forename;
        }

        [When(@"I submit order")]
        public void WhenIsubmitOrder()
        {
            _checkoutPage.SubmitOrder();
        }

        [Then(@"Success message should be displayed")]
        public void SuccessMessageShouldBeDisplayed()
        {
            _checkoutPage.VerifyOrderIsAccepted(_paymentData.Forename);
        }
    }
}
