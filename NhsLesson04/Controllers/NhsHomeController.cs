using Microsoft.AspNetCore.Mvc;
using NhsLesson04.Models;
using System.Diagnostics;

namespace NhsLesson04.Controllers
{
    public class NhsHomeController : Controller
    {
        private readonly ILogger<NhsHomeController> _logger;

        public NhsHomeController(ILogger<NhsHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NhsAbout()
        {
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
