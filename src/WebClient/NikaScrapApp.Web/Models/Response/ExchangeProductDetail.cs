using Microsoft.AspNetCore.Mvc.Rendering;

namespace NikaScrapApp.Web.Models.Response
{
    public class ExchangeProductAccount 
    {
        public int PickupBoyId { get; set; }

        public List<SelectListItem> PickupBoyList { get; set; } 
        public List<ExchangeProductDetails> ExchangeProductDetails { get; set; }
        public List<SelectListItem> ExchangeProductList { get; set; } 
    }
    public class ExchangeProductDetails
    {
        public int PickupBoyId { get; set; }
        public int PickupBoyName { get; set; } 
        public int TotalProducts { get; set; }
    }
}
