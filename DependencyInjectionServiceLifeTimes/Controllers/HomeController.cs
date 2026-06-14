using DependencyInjectionServiceLifeTimes.Models;
using DependencyInjectionServiceLifeTimes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DependencyInjectionServiceLifeTimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransientGuidService _transientGuidService1;
        private readonly ITransientGuidService _transientGuidService2;

        private readonly IScopedGuidService _scopedGuidService1;
        private readonly IScopedGuidService _scopedGuidService2;

        private readonly ISingletonGuidService _singletonGuidService1;
        private readonly ISingletonGuidService _singletonGuidService2;
        public HomeController(ITransientGuidService transientGuidService1, ITransientGuidService transientGuidService2,
                              IScopedGuidService scopedGuidService1, IScopedGuidService scopedGuidService2,
                              ISingletonGuidService singletonGuidService1, ISingletonGuidService singletonGuidService2)
        {
            _transientGuidService1 = transientGuidService1;
            _transientGuidService2 = transientGuidService2;
            _scopedGuidService1 = scopedGuidService1;
            _scopedGuidService2 = scopedGuidService2;
            _singletonGuidService1=singletonGuidService1;
            _singletonGuidService2 = singletonGuidService2;
        }
        public IActionResult Index()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Transient 1: {_transientGuidService1.GetGuid()}\n");
            stringBuilder.Append($"Transient 2: {_transientGuidService2.GetGuid()}\n\n\n");
            stringBuilder.Append($"Scoped 1: {_scopedGuidService1.GetGuid()}\n");
            stringBuilder.Append($"Scoped 2: {_scopedGuidService2.GetGuid()}\n\n\n");
            stringBuilder.Append($"Singleton 1: {_singletonGuidService1.GetGuid()}\n");
            stringBuilder.Append($"Singleton 2: {_singletonGuidService2.GetGuid()}\n");

            return Ok(stringBuilder.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
