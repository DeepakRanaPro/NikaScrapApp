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
    public class OrderPickupController : ControllerBase
    {
        private readonly IOrderPickupService _orderPickupService; 

        public OrderPickupController(IOrderPickupService orderPickupService)
        {
            _orderPickupService = orderPickupService; 
        }

        [HttpPost]
        public IActionResult ScrapPickup(OrderPickup orderPickup) 
        {
            ResponseData responseData = new ResponseData();

            responseData = _orderPickupService.ProcessOrderPickup(orderPickup);
             
            return Ok(responseData);
        }

    }
}
