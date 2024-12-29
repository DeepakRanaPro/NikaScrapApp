using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PickupBoyController : ControllerBase
    {
        private readonly IPickUpBoyService _pickUpBoy;
        public PickupBoyController(IPickUpBoyService pickUpBoy)
        {
            _pickUpBoy = pickUpBoy;
        }

        [HttpGet]
        public ActionResult GetHestory([FromQuery] int id)
        {
            PickupHistory result = new PickupHistory();
            result = _pickUpBoy.GetHistory(id);
            return Ok(result);
        }
        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            PickupResponse result = new PickupResponse();
            result = _pickUpBoy.Get(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post(Products products)
        {
            PickupDetail result = new PickupDetail();
            result = _pickUpBoy.post(products);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult PaymentTransactions(Core.Models.Request.ScrapPickerPaymentTransactions scrapPickerPaymentTransactions)
        {
            ScrapPickerPaymentResponce result = new ScrapPickerPaymentResponce();
            result = _pickUpBoy.PaymentTransactions(scrapPickerPaymentTransactions);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult ExchangeProduct(NikaScrapApp.Core.Models.Request.ScrapPickerExchangeProducts scrapPickerExchangeProducts)
        {
            ResponseData result = new ResponseData();
            result = _pickUpBoy.ExchangeProduct(scrapPickerExchangeProducts);
            return Ok(result);
        }
    }
}
