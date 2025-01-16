using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ScrapPickerPaymentController : ControllerBase
    {
        private readonly IScrapPickerPaymentService _scrapPickerPaymentService;
        public ScrapPickerPaymentController(IScrapPickerPaymentService scrapPickerPaymentService)
        {
            _scrapPickerPaymentService = scrapPickerPaymentService;    
        }

        [HttpGet]
        public ActionResult PickerPaymentAccountDetail(int ScrapPickerId)
        {
            ScrapPickerPaymentAccountDetail result = new ScrapPickerPaymentAccountDetail();
            result = _scrapPickerPaymentService.PickerPaymentAccountDetail(ScrapPickerId);
            return Ok(result);
        }
        [HttpGet]
        public ActionResult PickerPaymentTransactions(int ScrapPickerId)
        {
            ScrapPickerPaymentAccountDetail result = new ScrapPickerPaymentAccountDetail();
            result = _scrapPickerPaymentService.PickerPaymentAccountDetail(ScrapPickerId);
            return Ok(result);
        }
        //[HttpGet]
        //public ActionResult ScrapPickerPaymentAccount(int ScrapPickerId)
        //{
        //    ScrapPickerPaymentAccount result = new ScrapPickerPaymentAccount();
        //    result = _scrapPickerPaymentService.ScrapPickerPaymentAccounts(ScrapPickerId);
        //    return Ok(result);
        //}
        //[HttpGet]
        //public ActionResult ScrapPickerPaymentTransaction(int id)
        //{
        //    Core.Models.Response.TbScrapPickerPaymentTransactions result = new Core.Models.Response.TbScrapPickerPaymentTransactions();
        //    result = _scrapPickerPaymentService.ScrapPickerPaymentTransaction(id);
        //    return Ok(result);
        //}
    }
}
