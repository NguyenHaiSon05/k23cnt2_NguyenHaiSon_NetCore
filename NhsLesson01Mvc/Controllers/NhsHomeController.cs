using Microsoft.AspNetCore.Mvc;
using NhsLesson01Mvc.Models;

namespace NhsLesson01Mvc.Controllers
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
            return View("NhsIndex"); // Đảm bảo gọi đúng file view
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
