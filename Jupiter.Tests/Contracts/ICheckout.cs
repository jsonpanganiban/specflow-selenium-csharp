namespace Jupiter.Tests.Pages
{
    public interface ICheckout
    {
        void FillOutDeliveryDetails(string forename, string email, string address);
        void FillOutPaymentDetails(string cardType, string cardNumber);
        void SubmitOrder();
        void VerifyOrderIsAccepted();
    }
}