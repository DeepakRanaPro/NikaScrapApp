using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseInchargeController : ControllerBase
    {
        private readonly IWarehouseInchargeServic _westerService;

        public WarehouseInchargeController(IWarehouseInchargeServic westerService)
        {
            _westerService = westerService;
        }

        [HttpGet]
        public IActionResult GetUnapprovedPickups([FromQuery] string PickupCode)
        {
            UnappprovedPickups result = new UnappprovedPickups();
             result= _westerService.GetUnapprovedPickups(PickupCode);

            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetUnapprovedPickupDetails(int pickupId)
        {
            UnApprovedDetails result = new UnApprovedDetails();
            result = _westerService.GetUnapprovedPickupDetails(pickupId);

            return Ok(result);
        }
        [HttpPost]
        public IActionResult ApprovePickupProducts([FromBody] NikaScrapApp.Core.Models.Request.UnApprovedPickup unApproved)
        {
            UnApprovedDetails result = new UnApprovedDetails();
            result = _westerService.ApprovePickupProducts(unApproved);

            return Ok(result);
        }
    }
}
