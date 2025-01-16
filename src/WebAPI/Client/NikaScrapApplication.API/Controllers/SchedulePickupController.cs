using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApplication.API.Helper;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchedulePickupController : ControllerBase
    {
        private readonly ISchedulePickupService _scrapService;
        private SmsTemplates _smsTemplate;
        private readonly ISmsService _smsService;
        private readonly string _smsApiUrl;
        private string _smsApiParams;
        private string _PlaceOrderTemplate;
        private readonly IConfiguration _configuration;
        public SchedulePickupController(IConfiguration configuration, ISchedulePickupService scrapService, ISmsService smsService)
        {
            _configuration = configuration;
            _smsService = smsService;
            _scrapService = scrapService;
            _smsTemplate = SmsTemplateHelper.GetSmsTemplates().Where(x => x.Type == "PlaceOrder").FirstOrDefault();
            _smsApiUrl = _configuration.GetSection("SMSApiUrl").Value;
            _smsApiParams = _configuration.GetSection("SMSApiParams").Value; 
        }
         
        [HttpGet]
        public IActionResult Info([FromQuery] int userId)
        {
            SchedulePickupResponse result = new SchedulePickupResponse();
            result = _scrapService.GetInfo(userId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ScrapPickup scrapPickup,int languageId) 
        {
            SchedulePickupCommandResponse result = new SchedulePickupCommandResponse();
            result = _scrapService.AddScrap(scrapPickup, languageId);

            if(result.IsSuccess)
            { 
                string mobileNo= _scrapService.GetMobileNo(scrapPickup.UserId).Data;
                _smsApiParams = _smsApiParams.Replace("{mobiles}", mobileNo).Replace("{message}", _smsTemplate.SmsTemplate).Replace("{TemplateCode}", _smsTemplate.TemplateCode);
                var httpClientManager = new HttpClientManager(_smsApiUrl);
                var smsApiResponse = httpClientManager.GetAsync<SmsApi>(_smsApiParams).Result;
                _smsService.SaveSmsApiResponse(smsApiResponse);
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult History([FromQuery] int userId, int statusId, int languageId,int PageNumber, int RowsOfPage)
        {
            GetScrapResponse result = new GetScrapResponse();
            result = _scrapService.GetHistory(userId, statusId, languageId,PageNumber, RowsOfPage);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Cancel([FromQuery] int pickupId, [FromQuery]  int languageId)  
        {
            SchedulePickupCommandResponse result = new SchedulePickupCommandResponse(); 
            result = _scrapService.PickupCancel(pickupId, languageId);
            return Ok(result);
        }
    }
}
