using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Models;
using NikaScrapApplication.API.Services;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;
        private readonly string _secretKey;
        public AuthController()
        {
            _secretKey = "MyTestCode MyTestCode MyTestCode werewrewrewrewr 234234234324324"; 
            authService = new AuthService(_secretKey);
        }

        [HttpPost]
        public IActionResult Authenticate(UserCredential userCredential) 
        {
            JWTTokenDetails jwtTokenDetails = authService.GenrateToken(userCredential);
            return Ok(jwtTokenDetails);
        }
    }


}
