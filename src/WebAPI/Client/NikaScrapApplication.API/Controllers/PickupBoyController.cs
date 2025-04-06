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

        [HttpPost]
        public IActionResult ScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker)
        {
            ResponseData responseData = new ResponseData();

            responseData = _pickupBoyService.InsertPickupProduct(scrapPickupByWastePicker.PickupId, scrapPickupByWastePicker.ScrapProducts);

            if (responseData.IsSuccess && scrapPickupByWastePicker.ExchangeProducts.Any())
            {
                responseData = _pickupBoyService.InsertPickupProduct(scrapPickupByWastePicker.PickupId, scrapPickupByWastePicker.ExchangeProducts);
            }

            responseData = _pickupBoyService.UpdateScrapPickup(scrapPickupByWastePicker);

            return Ok(responseData);
        }

        [HttpGet]
        public IActionResult PickupHistory(int userId)
        {
            PickupHistoryList result = _pickupBoyService.PickupHistory(userId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult PickupDetail(int PickupId)
        {
            PickupDetail result = new PickupDetail();
            result = _pickupBoyService.PickupDetail(PickupId);
            return Ok(result);
        }
    }
}
