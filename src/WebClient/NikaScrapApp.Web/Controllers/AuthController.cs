using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Models.Request;
using NikaScrapApp.Web.Utility;
using System.Security.Claims;

namespace NikaScrapApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;
        public AuthController(IOptions<AppSettings> appSettings) 
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Login() 
        { 
            return View(new Login());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login) 
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(login), System.Text.Encoding.UTF8, "application/json");
            var loginResponse = await _httpClientManager.PostAsync<Models.Response.LoginResponse>("Auth/Login", content); 

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
