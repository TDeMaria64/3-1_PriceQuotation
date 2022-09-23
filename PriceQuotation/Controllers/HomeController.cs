using Microsoft.AspNetCore.Mvc;
using PriceQuotation.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace PriceQuotation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Name = "Subtotal:";
            ViewBag.FV1 = 0.00;
            ViewBag.FV2 = 0.00;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Quotation model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FV1 = model.CalculateDiscountAmount();
                ViewBag.FV2 = model.CalculateTotal();
            }
            else
            {
                ViewBag.FV1 = 0;
                ViewBag.FV2 = 0;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}