using Microsoft.AspNetCore.Mvc;
using NhsLesson05_Model.Models;
using System.Diagnostics;

namespace NhsLesson05_Model.Controllers
{
    public class NhsHomeController : Controller
    {
        private readonly ILogger<NhsHomeController> _logger;

        public NhsHomeController(ILogger<NhsHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NhsIndex()
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
