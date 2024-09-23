using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApp.Core.Services;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchedulePickupController : ControllerBase
    {
        private readonly ISchedulePickupService _scrapService;
        public SchedulePickupController(ISchedulePickupService scrapService)
        {
            _scrapService = scrapService;
        }


        [HttpGet, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult Info([FromQuery] int userId)
        {
            SchedulePickupResponse result = new SchedulePickupResponse();
            result = _scrapService.GetInfo(userId);
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult Create(ScrapPickup scrapPickup) 
        {
            SchedulePickupCommandResponse result = new SchedulePickupCommandResponse();
            result = _scrapService.AddScrap(scrapPickup);
            return Ok(result);
        }

        [HttpGet, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult History([FromQuery] int userId, int statusId, int languageId)
        {
            GetScrapResponse result = new GetScrapResponse();
            result = _scrapService.GetHistory(userId, statusId, languageId);
            return Ok(result);
        }

        [HttpGet, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult Cancel([FromQuery] int pickupId)  
        {
            SchedulePickupCommandResponse result = new SchedulePickupCommandResponse();
            result = _scrapService.PickupCancel(pickupId);
            return Ok(result);
        }
    }
}
