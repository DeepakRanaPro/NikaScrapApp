

namespace DigitalKabadiApp.Core.Models.Request
{
    public class ScrapPickerPaymentTransactions
    {


        public int ScrapPickerId { get; set; }
        public int TransactionTypeId { get; set; }
        public int PaymentModeId { get; set; }
        public string TransactionCode { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaymentBy { get; set; }
         public string Remarks { get; set; }
   
    }
}
