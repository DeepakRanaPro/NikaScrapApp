using DigitalKabadiApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace NikaScrapApp.Web.Controllers
{
    public class ExchangePickerBoyController : Controller
    {
        private readonly IExchangeProductsRepository _repository;
        private readonly IMasterDataRepository _masterDataService;
        public ExchangePickerBoyController(IExchangeProductsRepository repository, IMasterDataRepository masterDataService)
        {
            _repository = repository;
            _masterDataService = masterDataService;
        }
        //[HttpGet]
        //public IActionResult Index(int userId)
        //{
        //    ExchangeProductAccount pickupBoyPaymentAccount = new ExchangeProductAccount();
        //    {
        //        var pickupBoyList =  _repository.GetPickupBoyList(userId).ToList();
        //        var viewModel = new ExchangeProductAccount
        //        {
        //            PickupBoyList = pickupBoyList
        //        };
        //        return View(viewModel);
        //    }



        //}
    }
}
