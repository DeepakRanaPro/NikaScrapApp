using DigitalKabadiApp.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.View;
using NikaScrapApp.Web.Utility.Extensions;

namespace NikaScrapApp.Web.Controllers
{
    public class PaymentController : Controller
    { 
            private readonly IScrapPickerPaymentService _scrapPickerPaymentService;
            private readonly IMasterDataService _masterDataService;
            public PaymentController(IScrapPickerPaymentService scrapPickerPaymentService, IMasterDataService masterDataService)
            { 
                _scrapPickerPaymentService = scrapPickerPaymentService;
                _masterDataService = masterDataService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
               PickupBoyPaymentAccount pickupBoyPaymentAccount = new PickupBoyPaymentAccount();
               var masterData = _masterDataService.GetMasterData().Data.ToList();
               pickupBoyPaymentAccount.PickupBoyList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker", "Pickup Boy");
               pickupBoyPaymentAccount.AccountDetails = _scrapPickerPaymentService.PickerPaymentAccountDetail(0).Data ?? new List<DigitalKabadiApp.Core.Models.Response.ScrapPickerPaymentAccountDetails>();
               pickupBoyPaymentAccount.ScrapPickerPayment = new PickupBoyPayment() {
               PickupBoyList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker", "Pickup Boy"),
               PaymentModeList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "PaymentMode", "Payment Mode"),
               };
                
               return View(pickupBoyPaymentAccount);
            }


            [HttpPost]
            public async Task<IActionResult> PickupBoyPaymentAccountSearch(PickupBoyPaymentAccount pickupBoyPaymentAccount) 
            {
               var masterData = _masterDataService.GetMasterData().Data.ToList();
               pickupBoyPaymentAccount.AccountDetails = _scrapPickerPaymentService.PickerPaymentAccountDetail(pickupBoyPaymentAccount.PickupBoyId).Data ?? new List<DigitalKabadiApp.Core.Models.Response.ScrapPickerPaymentAccountDetails>();
               pickupBoyPaymentAccount.PickupBoyList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker", "Pickup Boy");
               pickupBoyPaymentAccount.ScrapPickerPayment = new PickupBoyPayment()
               {
                  PickupBoyList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker", "Pickup Boy"),
                  PaymentModeList = DropdownExtensions.InitializeDropdown(masterData.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "PaymentMode", "Payment Mode"),
               };
            
                return View("Index", pickupBoyPaymentAccount);
            }


            [HttpPost]
            public async Task<IActionResult> Pay(PickupBoyPaymentAccount pickupBoyPaymentAccount)  
            { 
                return RedirectToAction("Index");
            }
    }
}
