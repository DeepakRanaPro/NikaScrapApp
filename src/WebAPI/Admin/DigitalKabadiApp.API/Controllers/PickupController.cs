using DigitalKabadiApp.API.Helper;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PickupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPickupService _pickupServices;
        private readonly ISmsService _smsService;
        private readonly string _smsApiUrl;
        private string _smsApiParams;
        private SmsTemplates _smsTemplate;
        public PickupController(IConfiguration configuration, IPickupService pickupService, ISmsService smsService)
        {
            _configuration = configuration;
            _smsService = smsService;
            _pickupServices = pickupService;
            _smsApiUrl = _configuration.GetSection("SMSApiUrl").Value;
            _smsApiParams = _configuration.GetSection("SMSApiParams").Value;
            _smsTemplate = SmsTemplateHelper.GetSmsTemplates().Where(x => x.Type == "OrderConfirmed").FirstOrDefault();
        }

        [HttpPost]
        public ActionResult Report([FromBody] PickupReport pickupReport) 
        {
            PickupRecordsResponse result = new PickupRecordsResponse();
            result = _pickupServices.PickupRecords(pickupReport);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult UpdateStatus([FromBody] PickupStatus pickupStatus)  
        {
            ResponseData result = new ResponseData();
            result = _pickupServices.UpdatePickupStatus(pickupStatus);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Assign([FromBody] PickupAssign pickupAssign)  
        {
            ResponseData result = new ResponseData();
            result = _pickupServices.AssignPickup(pickupAssign);

            if(result.IsSuccess)
            {
                _smsApiParams = _smsApiParams.Replace("{mobiles}", _pickupServices.GetMobileNo(pickupAssign.UserId).Data).Replace("{message}", _smsTemplate.SmsTemplate.Replace("{#var#}", _pickupServices.GetPickupCode(pickupAssign.PickupId).Data)).Replace("{TemplateCode}", _smsTemplate.TemplateCode);
                var httpClientManager = new HttpClientManager(_smsApiUrl);
                var smsApiResponse = httpClientManager.GetAsync<SmsApi>(_smsApiParams).Result;
                _smsService.SaveSmsApiResponse(smsApiResponse);
            }

            return Ok(result);
        }
    }
}
