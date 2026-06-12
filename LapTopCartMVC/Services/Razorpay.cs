namespace LapTopCartMVC.Services
{
    public class Razorpay : IPaymentService
    {
        public string pay(decimal amount)
        {
            return $"Paid {amount} using Razorpay.";
        }
    }
}
