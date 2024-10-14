namespace AcmeSchool.External
{
    public interface IPaymentGateway
    {
        string GetPaymentLink(decimal amount);

        bool ValidatePayment(string paymentId);
    }
}
