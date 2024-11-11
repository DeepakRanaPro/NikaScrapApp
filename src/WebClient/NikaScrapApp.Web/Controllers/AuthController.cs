using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Models.Request;
using NikaScrapApp.Web.Utility;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace NikaScrapApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthService _authenticateService;
        public AuthController(IOptions<AppSettings> appSettings, IAuthService authenticateService) 
        {
            _appSettings = appSettings.Value;
            _authenticateService = authenticateService;
        }

        [HttpGet]
        public async Task<IActionResult> Login() 
        { 
            return View(new Login());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginRequest) 
        { 
            LoginResponse loginResponse = new LoginResponse();

            loginResponse = _authenticateService.Login(new DigitalKabadiApp.Core.Models.Request.Login() { EmailId= loginRequest.EmailId,Password= loginRequest.Password });

            if (loginResponse.IsSuccess)
            {
                string dd = new Guid().ToString();
                SessionManager.Set(SessionManager.UserId, loginResponse.Data.Id.ToString());
                SessionManager.Set(SessionManager.UserName, loginResponse.Data.Name);
                SessionManager.Set(SessionManager.RoleName, loginResponse.Data.Role);
                SessionManager.Set(SessionManager.RoleId, loginResponse.Data.RoleId.ToString());
    
                return RedirectToAction("Index","Home");
            }

            NotificationHelper.SetNotification(this, $"Invalid credentials, Please try again!", "danger");
            return View(loginResponse.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("SessionKey");
            SessionManager.Clear();
            return RedirectToAction("Login");
        }
    }
}
