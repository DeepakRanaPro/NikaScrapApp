using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.Request
{
    public class Product
    { 
        public string RoleName { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        public string NameInHindi { get; set; }

        [Required(ErrorMessage = "Category is Required!")]
        public int CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = "Unit is Required!")]
        public int UnitId { get; set; }
        public List<SelectListItem> UnitList { get; set; } = new List<SelectListItem>(); 
        public int ActionBy { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ProductPriceId { get; set; }

        [Required(ErrorMessage = "Price is Required!")]
        public string Price { get; set; }
    }
}
