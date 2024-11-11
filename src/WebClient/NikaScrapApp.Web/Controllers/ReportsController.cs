using DigitalKabadiApp.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPickupService _pickupServices;
        private readonly IMasterDataService _masterDataService;

        public ReportsController(IOptions<AppSettings> appSettings, IPickupService pickupService, IMasterDataService masterDataService) 
        {
            _appSettings = appSettings.Value; 
            _pickupServices = pickupService;
            _masterDataService = masterDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Pickup() 
        { 
            Models.View.PickupReport pickupReportModel = new Models.View.PickupReport();
            var masterData = _masterDataService.GetMasterData(); 
            var pickupRecordsResponse = _pickupServices.PickupRecords(new DigitalKabadiApp.Core.Models.Request.PickupReport());

            //PickupReport pickupRequest = new PickupReport() { StatusId=1, FromDate = DateTime.Now.ToString("MM/dd/yyyy"), ToDate = DateTime.Now.ToString("MM/dd/yyyy") }; 
            PickupReport pickupRequest = new PickupReport() { StatusId = 1, FromDate = DateTime.Now.ToString("MM/dd/yyyy"), ToDate = DateTime.Now.ToString("MM/dd/yyyy") };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(pickupRequest), System.Text.Encoding.UTF8, "application/json");
            //var pickupRecordsResponse = await _httpClientManager.PostAsync<Models.Response.PickupRecordsResponse>("Pickup/Report", content);
            pickupReportModel.PickupRecords = pickupRecordsResponse.Data.Select(x => new NikaScrapApp.Web.Models.Response.PickupRecords()
            {
                City = x.City,
                EstimatedWeigh = x.EstimatedWeigh,
                FullAddress = x.FullAddress,
                Id = x.Id,
                LocationType = x.LocationType,
                MobileNumber = x.MobileNumber,
                Name = x.Name,
                PickupCode = x.PickupCode,
                PickUpDate = x.PickUpDate,
                Remarks = x.Remarks,
                State = x.State,
                Status = x.Status,
                TimeSlot = x.TimeSlot
            }).ToList();
            pickupReportModel.FromDate = pickupRequest.FromDate;
            pickupReportModel.ToDate = pickupRequest.ToDate;
            pickupReportModel.UserList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Users");
            pickupReportModel.assignUserInfo.UserList = DropdownExtensions.InitializeDropdown(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker");
            pickupReportModel.pickupStatusDetails.StatusList = DropdownExtensions.InitializeDropdown(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Status").Where(x => x.Value != "1").ToList();
            pickupReportModel.StatusList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Status");
            pickupReportModel.LocationTypeList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "LocationType");
            pickupReportModel.StateList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "State");
            pickupReportModel.CityList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "City");


            return View("Index",pickupReportModel);
        }

        [HttpPost]
        public async Task<IActionResult> Pickup(Models.View.PickupReport pickupReportModel)
        { 
            var masterData = _masterDataService.GetMasterData();

            var pickupRequest = new DigitalKabadiApp.Core.Models.Request.PickupReport()
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

            var pickupRecordsResponse = _pickupServices.PickupRecords(pickupRequest);

            pickupReportModel.PickupRecords = pickupRecordsResponse.Data.Select(x => new NikaScrapApp.Web.Models.Response.PickupRecords()
            {
                City = x.City,
                EstimatedWeigh = x.EstimatedWeigh,
                FullAddress = x.FullAddress,
                Id = x.Id,
                LocationType = x.LocationType,
                MobileNumber = x.MobileNumber,
                Name = x.Name,
                PickupCode = x.PickupCode,
                PickUpDate = x.PickUpDate,
                Remarks = x.Remarks,
                State = x.State,
                Status = x.Status,
                TimeSlot = x.TimeSlot
            }).ToList();
            pickupReportModel.FromDate = pickupRequest.FromDate;
            pickupReportModel.ToDate = pickupRequest.ToDate;
            pickupReportModel.UserList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Users");
            pickupReportModel.assignUserInfo.UserList = DropdownExtensions.InitializeDropdown(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "WastePicker");
            pickupReportModel.pickupStatusDetails.StatusList = DropdownExtensions.InitializeDropdown(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Status").Where(x => x.Value != "1").ToList();
            pickupReportModel.StatusList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "Status");
            pickupReportModel.LocationTypeList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "LocationType");
            pickupReportModel.StateList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "State");
            pickupReportModel.CityList = DropdownExtensions.InitializeDropdownWithDefaultValue(masterData.Data.Select(x => new NikaScrapApp.Web.Models.Response.MasterData() { Id = x.Id, Name = x.Name, Type = x.Type }).ToList(), "City");


            return View("Index", pickupReportModel);
        }
    }
}
