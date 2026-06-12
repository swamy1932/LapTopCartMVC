using LapTopCartMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LapTopCartMVC.Controllers
{
    public class DonationController : Controller
    {
        private readonly IPaymentService _paymentService;
        public DonationController(IPaymentService paymentService)
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
