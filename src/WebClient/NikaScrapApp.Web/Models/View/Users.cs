using Microsoft.AspNetCore.Mvc.Rendering;
using NikaScrapApp.Web.Models.Response;

namespace NikaScrapApp.Web.Models.View
{
    public class Users
    {
        public UserSearch UserSearch { get; set; } 
       public List<UsersRecords> UsersRecordList { get; set; }  
    }

    public class UserSearch
    {
        public string Name { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; } = new List<SelectListItem>();
        public string State { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public string City { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public string pincode { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
    }

} 