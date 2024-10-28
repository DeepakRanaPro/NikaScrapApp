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
            return Ok(result);
        }
    }
}
