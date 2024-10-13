namespace AcmeSchool.External
{
    public class PaymentGateway : IPaymentGateway
    {
        public string GetPaymentLink(decimal amount)
        {
            return "https://FakePaymentProvider.Payment.com";
        }

        public bool validatePayment(string paymentId)
        {
            //Simulated validation of paymentId
            return paymentId == "ValidPaymentId";
        }
    }
}
