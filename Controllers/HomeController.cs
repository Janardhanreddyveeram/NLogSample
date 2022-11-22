using Microsoft.AspNetCore.Mvc;
using NLogSample.Models;
using System.Diagnostics;

namespace NLogSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Controller Invoked");
            try
            {
                var value = 1;
                var item = value / 0;
            }
            catch(Exception)
            {
                _logger.LogError("Exception thrown..");
            }
            return View();
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