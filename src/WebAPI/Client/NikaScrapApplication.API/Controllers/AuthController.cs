using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApplication.API.Helper;
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
        private readonly ISmsService _smsService;  
        private readonly string _secretKey;
        private readonly string _smsApiUrl; 
        private string _smsApiParams; 
        private string _OtpTemplate;
        private SmsTemplates _smsTemplate;
        public AuthController(IConfiguration configuration, IAuthenticateService authenticateService, ISmsService smsService)
        {
            _configuration = configuration;
            _smsService = smsService;
            _secretKey = _configuration.GetSection("SecretKey").Value;
            _smsApiUrl = _configuration.GetSection("SMSApiUrl").Value;
            _smsApiParams = _configuration.GetSection("SMSApiParams").Value;
            _OtpTemplate = _configuration.GetSection("OtpTemplate").Value;
            _authenticateService = authenticateService;
            _smsTemplate = SmsTemplateHelper.GetSmsTemplates().Where(x => x.Type == "OTP").FirstOrDefault();
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
            ResponseResult response = new ResponseResult(); 
            response = _authenticateService.Login(loginRequest);

            if (response.IsSuccess)
            { 
                if (!loginRequest.MobileNo.Contains("8950962769"))
                {

                    loginRequest.MobileNo = loginRequest.MobileNo.Length == 10 ? $"91{loginRequest.MobileNo}" : loginRequest.MobileNo;
                    _smsApiParams = _smsApiParams.Replace("{mobiles}", loginRequest.MobileNo).Replace("{message}", _smsTemplate.SmsTemplate.Replace("{#var#}", response.Data)).Replace("{TemplateCode}", _smsTemplate.TemplateCode);
                    var httpClientManager = new HttpClientManager(_smsApiUrl);
                    var smsApiResponse = httpClientManager.GetAsync<SmsApi>(_smsApiParams).Result;
                    _smsService.SaveSmsApiResponse(smsApiResponse);
                }
            }

            return Ok(response);
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
