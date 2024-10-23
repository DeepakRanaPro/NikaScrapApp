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
        private readonly IPickupService _pickupServices;
        public PickupController(IPickupService pickupService) 
        {
            _pickupServices = pickupService;
        }

        [HttpPost]
        public ActionResult Report([FromBody] PickupReport pickupReport) 
        {
            PickupRecordsResponse result = new PickupRecordsResponse();
            result = _pickupServices.PickupRecords(pickupReport);
            return Ok(result);
        }
    }
}
