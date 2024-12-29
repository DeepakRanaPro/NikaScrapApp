using DigitalKabadiApp.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Web.Models;

namespace NikaScrapApp.Web.Controllers
{
    public class PickerBoyController1 : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IScrapPickerPaymentService _scrapPickerPaymentService;
       
        public PickerBoyController1( AppSettings appSettings, IScrapPickerPaymentService scrapPickerPaymentService)
        {
            _appSettings = _appSettings;
            _scrapPickerPaymentService = _scrapPickerPaymentService;
        }
       

            //[HttpGet]
            //public async Task<IActionResult> PickerBoy()
            //{
            //    Models.View.Response.PicKerBoys pickupReportModel = new Models.View.PicKerBoys();
            //    var masterData = ();
            //    var pickupRecordsResponse = _scrapPickerPaymentService.PickerPaymentTransactions(new DigitalKabadiApp.Core.Models.Request.PicKerBoys());
            //    return View();
            //} 
    }
}
