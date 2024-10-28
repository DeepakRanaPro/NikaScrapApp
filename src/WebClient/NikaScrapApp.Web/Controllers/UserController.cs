using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Models.Request;
using NikaScrapApp.Web.Utility;
using NikaScrapApp.Web.Utility.Extensions;


namespace NikaScrapApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;

        public UserController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
        }

        public IActionResult Index()
        {
            Models.View.Users UsersModel = new Models.View.Users(); 
            return View();
        }
    }
}
