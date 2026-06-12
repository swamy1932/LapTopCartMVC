using LapTopCartMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LapTopCartMVC.Controllers
{
    public class SubscriptionController : Controller
    {
        public readonly IPaymentService _paymentService;
        public SubscriptionController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
          string result = _paymentService.pay(1000);
            return View();
        }
    }
}
