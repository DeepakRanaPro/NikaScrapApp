using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.Response;
using NikaScrapApp.Web.Models.View;
using NikaScrapApp.Web.Utility.Extensions;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ExchangeProductAccount pickupBoyPaymentAccount = new ExchangeProductAccount();
            {
                var pickupBoyList = await _repository.GetPickupBoyList.ToList();
                var viewModel = new ExchangeProductAccount
                {
                    PickupBoyList = pickupBoyList
                };
                return View(viewModel);
            }



        }
    }
}
