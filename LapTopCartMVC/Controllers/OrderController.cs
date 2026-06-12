using LapTopCartMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LapTopCartMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPaymentService _paymentService;
        public OrderController(IPaymentService paymentService)
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
