﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NikaScrapApp.Web.Models;
using NikaScrapApp.Web.Models.Request;
using NikaScrapApp.Web.Utility;
using NikaScrapApp.Web.Utility.CustomFilters;
using NikaScrapApp.Web.Utility.Extensions;

namespace NikaScrapApp.Web.Controllers
{
    [CustomAuthorizationFilterAttribute]
    public class ReportsController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly HttpClientManager _httpClientManager;

        public ReportsController(IOptions<AppSettings> appSettings) 
        {
            _appSettings = appSettings.Value;
            _httpClientManager = new HttpClientManager(_appSettings.BaseUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Pickup() 
        {
            Models.View.PickupReport pickupReportModel = new Models.View.PickupReport();
            var masterData = await _httpClientManager.GetAsync<Models.Response.MasterDataResponse>("MasterData/Get");

            //PickupReport pickupRequest = new PickupReport() { StatusId=1, FromDate = DateTime.Now.ToString("MM/dd/yyyy"), ToDate = DateTime.Now.ToString("MM/dd/yyyy") }; 
            PickupReport pickupRequest = new PickupReport() { StatusId = 1, FromDate = DateTime.Now.ToString("MM/dd/yyyy"), ToDate = DateTime.Now.ToString("MM/dd/yyyy") };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(pickupRequest), System.Text.Encoding.UTF8, "application/json");
            var pickupRecordsResponse = await _httpClientManager.PostAsync<Models.Response.PickupRecordsResponse>("Pickup/Report", content);
            pickupReportModel.PickupRecords = pickupRecordsResponse.Data.ToList();
            pickupReportModel.FromDate = pickupRequest.FromDate;
            pickupReportModel.ToDate = pickupRequest.ToDate;
            pickupReportModel.UserList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "Users");
            pickupReportModel.assignUserInfo.UserList = DropdownExtensions.InitializeDropdown(masterData.Data, "Users");
            pickupReportModel.pickupStatusDetails.StatusList = DropdownExtensions.InitializeDropdown(masterData.Data, "Status").Where(x => x.Value != "1").ToList();
            pickupReportModel.StatusList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "Status");
            pickupReportModel.LocationTypeList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "LocationType");
            pickupReportModel.StateList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "State");
            pickupReportModel.CityList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "City");

            return View("Index",pickupReportModel);
        }

        [HttpPost]
        public async Task<IActionResult> Pickup(Models.View.PickupReport pickupReportModel)
        {
            var masterData = await _httpClientManager.GetAsync<Models.Response.MasterDataResponse>("MasterData/Get");
            //PickupReport pickupRequest = new PickupReport() { StatusId=1, FromDate = DateTime.Now.ToString("MM/dd/yyyy"), ToDate = DateTime.Now.ToString("MM/dd/yyyy") }; 
            PickupReport pickupRequest = new PickupReport()
            {
                StatusId = pickupReportModel.StatusId,
                UserId = pickupReportModel.UserId,
                LocationTypeId = pickupReportModel.LocationTypeId,
                State = pickupReportModel.State,
                City = pickupReportModel.City,
                PickupCode = string.IsNullOrEmpty(pickupReportModel.PickupCode) ? "0" : pickupReportModel.PickupCode.Trim(),
                FromDate = string.IsNullOrEmpty(pickupReportModel.FromDate) ? "1900-01-01" : pickupReportModel.FromDate.Trim(),
                ToDate = string.IsNullOrEmpty(pickupReportModel.ToDate) ? "1900-01-01" : pickupReportModel.ToDate.Trim(),
            };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(pickupRequest), System.Text.Encoding.UTF8, "application/json");
            var pickupRecordsResponse = await _httpClientManager.PostAsync<Models.Response.PickupRecordsResponse>("Pickup/Report", content);
            pickupReportModel.PickupRecords = pickupRecordsResponse.Data.ToList();
            pickupReportModel.FromDate = pickupRequest.FromDate;
            pickupReportModel.ToDate = pickupRequest.ToDate;
            pickupReportModel.UserList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "Users");
            pickupReportModel.assignUserInfo.UserList = DropdownExtensions.InitializeDropdown(masterData.Data, "Users");
            pickupReportModel.pickupStatusDetails.StatusList = DropdownExtensions.InitializeDropdown(masterData.Data, "Status").Where(x => x.Value != "1").ToList();
            pickupReportModel.StatusList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "Status");
            pickupReportModel.LocationTypeList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "LocationType");
            pickupReportModel.StateList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "State");
            pickupReportModel.CityList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data, "City");

            return View("Index", pickupReportModel);
        }
    }
}
