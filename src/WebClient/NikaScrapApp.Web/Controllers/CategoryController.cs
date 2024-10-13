using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Utility;

namespace NikaScrapApp.Web.Controllers
{
    public class CategoryController : Controller
    { 
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;
        public CategoryController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoryResponse = await _httpClientManager.GetAsync<Models.Response.CategoryResponse>("Category/Get?id=0"); 
            return View(categoryResponse.Data);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            Models.View.Category category = new Models.View.Category();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.View.Category category) 
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(category), System.Text.Encoding.UTF8, "application/json");
            var categoryResponse = await _httpClientManager.PostAsync<Models.Response.CategoryResponse>("Category/InsertCategory", content);

            if (categoryResponse.IsSuccess)
            {
                NotificationHelper.SetNotification(this, "Category has been created", "success");
                return RedirectToAction("Index");
            }

            NotificationHelper.SetNotification(this, $"Category not created, {categoryResponse.Message} ", "danger");
            return View(categoryResponse.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Models.View.Category model = new Models.View.Category();
            var categoryResponse = await _httpClientManager.GetAsync<Models.Response.CategoryResponse>($"Category/Get?id={id}");
            model = categoryResponse.Data.Select(x=> 
                                                     new Models.View.Category() {
                                                         Id =x.Id, 
                                                         NameInEnglish=x.NameInEnglish, 
                                                         NameIsHindi=x.NameIsHindi }
                                                     ).FirstOrDefault() ?? new Models.View.Category();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.View.Category category) 
        { 
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(category), System.Text.Encoding.UTF8, "application/json");
            var categoryResponse = await _httpClientManager.PostAsync<Models.Response.CategoryResponse>("Category/ModifyCategory", content);

            if (categoryResponse.IsSuccess)
            {
                NotificationHelper.SetNotification(this, "Category has been updated", "success");
                return RedirectToAction("Index");
            }

            NotificationHelper.SetNotification(this, $"Category not updated, {categoryResponse.Message} ", "danger");
            return View(categoryResponse.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        { 
            var categoryResponse = await _httpClientManager.DeleteAsync<Models.Response.CategoryResponse>($"Category/DeleteCategory?id={id}");

            if (categoryResponse.IsSuccess)
                NotificationHelper.SetNotification(this, "Category has been deleted", "success");
            else
                NotificationHelper.SetNotification(this, $"Category not deleted, {categoryResponse.Message} ", "danger");

            return RedirectToAction("Index");
        }
    }
}
