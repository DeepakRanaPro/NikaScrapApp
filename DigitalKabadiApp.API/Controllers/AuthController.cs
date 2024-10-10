using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        private readonly IAuthService _authenticateService; 
        public AuthController(IConfiguration configuration, IAuthService authenticateService)
        {
            _configuration = configuration;  
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Login(Login loginRequest)
        {
            LoginResponse responseData = new LoginResponse();

            responseData = _authenticateService.Login(loginRequest);

            return Ok(responseData);
        }
    }
}
