using DigitalKabadiApp.Core.Interfaces.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly IProductService _productServics;
        public ProductController(IOptions<AppSettings> appSettings, IProductService productServics, IMasterDataService masterDataService)
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
            _masterDataService = masterDataService;
            _productServics = productServics;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            var productResponse = _productServics.GetProduct(0);
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
                UnitName = x.UnitName,
                ProductPriceRoleWiseId= x.ProductPriceRoleWiseId,
            }
            ));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var responseData = _productServics.DeleteProduct(id);

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
            var productResponse = _productServics.GetProduct(id);
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
                ProductPriceRoleWiseId = product.ProductPriceRoleWiseId,
            };

            model.CategoryList = DropdownExtensions.InitializeDropdownWithOutDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Category");
            model.UnitList = DropdownExtensions.InitializeDropdownWithOutDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Unit");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Request.Product product) 
        {
            DigitalKabadiApp.Core.Models.Request.Product requestData = new() {
            ActionBy = product.ActionBy,
            CategoryId = product.CategoryId,
            ProductId = product.ProductId,
            Name = product.Name,
            NameInHindi = product.NameInHindi,
            Price = product.Price,
            ProductPriceId = product.ProductPriceId,
            UnitId = product.UnitId,
                ProductPriceRoleWiseId= product.ProductPriceRoleWiseId
            };
            var productResponse = _productServics.ModifyProduct(requestData);

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
