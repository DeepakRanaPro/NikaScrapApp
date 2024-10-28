using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.Request
{
    public class Users
    {
        public string Id { get; set; } = string.Empty;
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "MobileNo is required")]
        public string MobileNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = "Pincode is required")]
        public string pincode { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;
        public string landmark { get; set; } = string.Empty;
        public string fullAddress { get; set; } = string.Empty;
    }
}
