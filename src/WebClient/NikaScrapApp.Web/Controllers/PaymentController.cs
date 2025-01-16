using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Web.Models.View;
using NikaScrapApp.Web.Utility.Extensions;
using System.Transactions;

namespace NikaScrapApp.Web.Controllers
{
    public class PaymentController : Controller
    {

        private readonly IScrapPickerPaymentService _scrapPickerPaymentService;
        private readonly IMasterDataService _masterDataService;
        private readonly IPickUpBoyService _pickUpBoyService;
        public PaymentController(IScrapPickerPaymentService scrapPickerPaymentService, IMasterDataService masterDataService, IPickUpBoyService pickUpBoyService)
        {
            _pickUpBoyService = pickUpBoyService;
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

            DigitalKabadiApp.Core.Models.Request.ScrapPickerPaymentTransactions paymentTransactionRequest = new DigitalKabadiApp.Core.Models.Request.ScrapPickerPaymentTransactions()
            {
                ScrapPickerId = pickupBoyPaymentAccount.ScrapPickerPayment.PickupBoyId,
                PaymentAmount = pickupBoyPaymentAccount.ScrapPickerPayment.PaymentAmount,
                PaymentModeId = pickupBoyPaymentAccount.ScrapPickerPayment.PaymentModeId,
                TransactionCode = pickupBoyPaymentAccount.ScrapPickerPayment.TransactionCode,
                Remarks = pickupBoyPaymentAccount.ScrapPickerPayment.Remarks,
                TransactionTypeId = 1
            };

            var result = _pickUpBoyService.PaymentTransactions(paymentTransactionRequest);

            if (result.IsSuccess)
            {

            }
            else
            {

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> TrsansctionHistory(int pickupboyid)
        {

            List<TbScrapPickerPaymentTransaction> paymentTransaction = _scrapPickerPaymentService.ScrapPickerPaymentTransaction(pickupboyid).Data.ToList();
             
            return View(paymentTransaction);
        }    
    }   
}
