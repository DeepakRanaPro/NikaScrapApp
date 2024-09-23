using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApplication.API.Services;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly AuthService authService;
        private readonly IAuthenticateService _authenticateService; 
        private readonly string _secretKey;
        public AuthController(IConfiguration configuration, IAuthenticateService authenticateService)
        {
            _configuration = configuration;
            _secretKey = _configuration.GetSection("SecretKey").Value; 
            //authService = new AuthService(_secretKey);
            _authenticateService = authenticateService;
        }

        [HttpPost,AllowAnonymous]
        public IActionResult GenrateToken(UserCredential userCredential)   
        {
            JWTTokenDetailResponse jwtTokenDetails = _authenticateService.GenrateToken(userCredential);
            return Ok(jwtTokenDetails);
        }

        [HttpPost]
        public IActionResult Login(Login loginRequest)
        {
            ResponseData responseData = new ResponseData();

            responseData = _authenticateService.Login(loginRequest);

            return Ok(responseData);
        }

        [HttpPost]
        public IActionResult VerifyOTP(OTP otpDTO) 
        {
            UserResponse responseData = new UserResponse();

            responseData = _authenticateService.VerifyOTP(otpDTO);

            return Ok(responseData);
        }
    }


}
