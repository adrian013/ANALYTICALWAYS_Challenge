namespace AcmeSchool.External
{
    public interface IPaymentGateway
    {
        string GetPaymentLink(decimal amount);

        bool validatePayment(string paymentId);
    }
}
