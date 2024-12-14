using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PickupBoyController : ControllerBase
    {
        private readonly IPickupBoyService _pickupBoyService;

        public PickupBoyController(IPickupBoyService pickupBoyService)
        {
            _pickupBoyService = pickupBoyService; 
        }

        [HttpPost, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult ScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker) 
        {
            ResponseData responseData = new ResponseData();

            responseData = _pickupBoyService.InsertPickupProduct(scrapPickupByWastePicker.PickupId, scrapPickupByWastePicker.ScrapProducts);

            if(responseData.IsSuccess && scrapPickupByWastePicker.ExchangeProducts.Any())
            {
                responseData = _pickupBoyService.InsertPickupProduct(scrapPickupByWastePicker.PickupId, scrapPickupByWastePicker.ExchangeProducts);
            }

            responseData = _pickupBoyService.UpdateScrapPickup(scrapPickupByWastePicker);

            return Ok(responseData);
        }
    }
}
