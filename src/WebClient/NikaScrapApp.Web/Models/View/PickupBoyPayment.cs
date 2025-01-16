using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace NikaScrapApp.Web.Models.View
{

    public class PickupBoyPaymentAccount 
    {
        public int PickupBoyId { get; set; }
        public List<SelectListItem> PickupBoyList { get; set; } = new List<SelectListItem>();
        public List<ScrapPickerPaymentAccountDetails> AccountDetails { get; set; } = new List<ScrapPickerPaymentAccountDetails>();
        public PickupBoyPayment ScrapPickerPayment { get; set; } = new PickupBoyPayment();
    }

    public class PickupBoyPayment
    {
        [Required(ErrorMessage = "PickupBoy is required")]
        public int PickupBoyId { get; set; }
        public List<SelectListItem> PickupBoyList { get; set; } = new List<SelectListItem>();
 
        [Required(ErrorMessage = "PaymentMode is required")]
        public int PaymentModeId { get; set; }
        public List<SelectListItem> PaymentModeList { get; set; } = new List<SelectListItem>(); 
        public string CurrentBalance { get; set; } = string.Empty;
        public string TransactionCode { get; set; } = string.Empty;

        [Required()]
        public decimal PaymentAmount { get; set; } 
        public string Remarks { get; set; } = string.Empty;
    }
}
