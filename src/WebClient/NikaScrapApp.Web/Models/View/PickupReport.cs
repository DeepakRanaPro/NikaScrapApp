using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.Response;
using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.View
{
    public class PickupReport
    {
        public string PickupCode { get; set; } = string.Empty;
        public int UserId { get; set; }
        public List<SelectListItem> UserList { get; set; } 
        public int StatusId { get; set; }
        public List<SelectListItem> StatusList { get; set; } 
        public int LocationTypeId { get; set; }
        public List<SelectListItem> LocationTypeList { get; set; }

        public string State { get; set; } 
        public List<SelectListItem> StateList { get; set; }

        public string City { get; set; }
        public List<SelectListItem> CityList { get; set; } 
        public string FromDate { get; set; } = "1900-01-01";
        public string ToDate { get; set; } = "1900-01-01";
        public string MyPickupCode { get; set; } = string.Empty;
        public List<PickupRecords> PickupRecords{ get; set; }  

        public AssignUserInfo assignUserInfo { get; set; } = new AssignUserInfo();
        public PickupStatusDetails pickupStatusDetails { get; set; } = new PickupStatusDetails(); 
         

        //public void InitializeUserList(List<MasterData> masterData) 
        //{
        //    UserList = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "All Users", Value = "0", Selected = true }
        //                };

        //    foreach (var item in masterData.Where(x=> x.Type== "Users"))
        //    {
        //        UserList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        //    } 
        //}

        //public void InitializeStatusList(List<MasterData> masterData)
        //{
        //    StatusList = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "All Status", Value = "0", Selected = true }
        //                };

        //    foreach (var item in masterData.Where(x => x.Type == "Status"))
        //    {
        //        StatusList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        //    }
        //}

        //public void InitializeLocationTypeList(List<MasterData> masterData)
        //{
        //    LocationTypeList = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "All LocationType", Value = "0", Selected = true }
        //                };

        //    foreach (var item in masterData.Where(x => x.Type == "LocationType"))
        //    {
        //        LocationTypeList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        //    }
        //}

        //public void InitializeStateList(List<MasterData> masterData)
        //{
        //    StateList = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "All State", Value = "0", Selected = true }
        //                };

        //    foreach (var item in masterData.Where(x => x.Type == "State"))
        //    {
        //        StateList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        //    }
        //}

        //public void InitializeCityList(List<MasterData> masterData)
        //{
        //    CityList = new List<SelectListItem>
        //                {
        //                    new SelectListItem { Text = "All City", Value = "0", Selected = true }
        //                };

        //    foreach (var item in masterData.Where(x => x.Type == "City"))
        //    {
        //        CityList.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        //    }
        //}
    }

    public class AssignUserInfo
    {
        public string PickupId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Scrap picker is required")]
        public int UserId { get; set; }
        public List<SelectListItem> UserList { get; set; }

        [Required(ErrorMessage = "Remarks is required")]
        public string Remarks { get; set; } = string.Empty;
        public int ActionBy { get; set; }
    }

    public class PickupStatusDetails   
    {
        public string PickupId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public int StatusId { get; set; }
        public List<SelectListItem> StatusList { get; set; } 

        [Required(ErrorMessage = "Remarks is required")]
        public string Remarks { get; set; } = string.Empty;
        public int ActionBy { get; set; }
    }
}
