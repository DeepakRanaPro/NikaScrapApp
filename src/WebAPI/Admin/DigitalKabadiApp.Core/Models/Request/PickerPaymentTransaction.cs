using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
   
        public class PickerPaymentTransaction
        {
        
        public int ScrapPickerId { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string TransactionType { get; set; }
        public string PaymentMode { get; set; }
        public decimal TransactionCode { get; set; }
        public string PaymentBy { get; set; }
        public string Remarks { get; set; }
        public int PickupId { get; set; }
        public string PickupCode { get; set; }
    }
}
