namespace LapTopCartMVC.Services
{
    public class PaypalService : IPaymentService
    {
        public string pay(decimal amount)
        {
            return $"Paid {amount} using Paypal.";
        }
    }
}
