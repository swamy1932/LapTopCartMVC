namespace LapTopCartMVC.Services
{
    public class StripeService : IPaymentService
    {
        public string pay(decimal amount)
        {
            return $"Paid {amount} using Stripe.";
        }
    }
}
