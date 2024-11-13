using DigitalKabadiApp.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Utility;
using NikaScrapApp.Web.Utility.CustomFilters;
using NikaScrapApp.Web.Utility.Extensions;

namespace NikaScrapApp.Web.Controllers
{
    [CustomAuthorizationFilterAttribute]
    public class ProductController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;
        private readonly IMasterDataService _masterDataService;
        public ProductController(IOptions<AppSettings> appSettings, IMasterDataService masterDataService)
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
            _masterDataService = masterDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var productResponse = await _httpClientManager.GetAsync<Models.Response.ProductResponse>("Product/Get?id=0");
            return View(productResponse.Data.Select(x => new NikaScrapApp.Web.Models.View.Product()
            {
                ProductId = x.ProductId,
                AppIcon = x.AppIcon,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Name = x.Name,
                NameInHindi = x.NameInHindi,
                Price = x.Price,
                ProductPriceId = x.ProductPriceId,
                RoleName = x.RoleName,
                Stock = x.Stock,
                UnitName = x.UnitName
            }
            ));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var responseData = await _httpClientManager.DeleteAsync<Models.Response.ResponseData>($"Product/DeleteProduct?id={id}");

            if (responseData.IsSuccess)
                NotificationHelper.SetNotification(this, "Product has been deleted", "success");
            else
                NotificationHelper.SetNotification(this, $"Product not deleted, {responseData.Message} ", "danger");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var masterData = _masterDataService.GetMasterData();
            Models.Request.Product model = new Models.Request.Product();
            var productResponse = await _httpClientManager.GetAsync<Models.Response.ProductResponse>($"Product/Get?id={id}");
            var product = productResponse.Data.FirstOrDefault();


            model = new Models.Request.Product()
            {
                Name = product.Name,
                NameInHindi = product.NameInHindi,
                ProductId = product.ProductId,
                UnitId = product.UnitId,
                ProductPriceId = product.ProductPriceId,
                Price = product.Price,
                RoleName = product.RoleName,
                CategoryId = product.CategoryId,
            };

            model.CategoryList = DropdownExtensions.InitializeDropdownWithOutDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Category");
            model.UnitList = DropdownExtensions.InitializeDropdownWithOutDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Unit");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Request.Product product) 
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");
            var productResponse = await _httpClientManager.PostAsync<Models.Response.ResponseData>("Product/ModifyProduct", content);

            if (productResponse.IsSuccess)
            {
                NotificationHelper.SetNotification(this, "Product has been updated", "success");
                return RedirectToAction("Index");
            }

            NotificationHelper.SetNotification(this, $"Product not updated, {productResponse.Message} ", "danger");
            return View(productResponse.Data);
        }
    }
} 
