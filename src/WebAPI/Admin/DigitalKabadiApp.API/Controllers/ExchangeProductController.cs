using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ExchangeProductController : ControllerBase
    {
        private readonly IExchangeProductService _exchangeProductService;
        public ExchangeProductController(IExchangeProductService exchangeProductService)
        {
            _exchangeProductService = exchangeProductService; 
        }

        [HttpPost]
        public ActionResult Insert(Core.Models.Request.ExchangeProduct exchangeProduct) 
        {
            ResponseData result = new ResponseData();
            result = _exchangeProductService.InsertRecord(exchangeProduct);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            ExchangeProductResponse exchangeProductResponse = new ExchangeProductResponse();
            exchangeProductResponse = _exchangeProductService.GetRecords();
            return Ok(exchangeProductResponse);
        }

        [HttpGet]
        public ActionResult GetProduct([FromQuery] int id)
        {
            ExchangeProductResponse exchangeProductResponse = new ExchangeProductResponse();
            exchangeProductResponse = _exchangeProductService.GetRecord(id);
            return Ok(exchangeProductResponse);
        }


    }
}
