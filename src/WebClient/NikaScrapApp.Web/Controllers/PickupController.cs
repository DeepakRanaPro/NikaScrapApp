using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Utility;

namespace NikaScrapApp.Web.Controllers
{
    public class PickupController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;

        public PickupController(IOptions<AppSettings> appSettings) 
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var masterData = await _httpClientManager.GetAsync<Models.Response.MasterDataResponse>("MasterData/Get"); 

            var categoryResponse = await _httpClientManager.GetAsync<Models.Response.CategoryResponse>("Category/Get?id=0");
            return View(categoryResponse.Data);
        }
    }
}
