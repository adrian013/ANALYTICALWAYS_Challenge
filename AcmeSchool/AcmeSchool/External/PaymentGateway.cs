namespace AcmeSchool.External
{
    public class PaymentGateway : IPaymentGateway
    {
        public string GetPaymentLink(decimal amount)
        {
            return "https://FakePaymentProvider.Payment.com";
        }

        public bool ValidatePayment(string paymentId)
        {
            //Simulated validation of paymentId
            return paymentId == "ValidPaymentId";
        }
    }
}
