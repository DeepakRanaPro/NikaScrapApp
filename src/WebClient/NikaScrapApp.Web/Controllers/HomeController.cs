using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Utility;
using NikaScrapApp.Web.Utility.CustomFilters;
using System.Diagnostics;

namespace NikaScrapApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomAuthorizationFilterAttribute]
        public IActionResult Index()
        {
            _logger.LogError($"Custome Exception: Deepak2 ");
            string userName = SessionManager.Get(SessionManager.UserName);
           string userId = SessionManager.Get(SessionManager.UserId); 

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
