using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NhsLesson10DB.Models;

namespace NhsLesson10DB.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
