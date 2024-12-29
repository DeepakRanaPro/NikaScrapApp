

using DigitalKabadiApp.Core.Models.Response;
using System.Transactions;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class PickupBoyReport
    {

        public int Id { get; set; }
        public string ScrapPickerName { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal CurrentBanance { get; set; }
        public string TransactionsDetail { get; set; }
        public int ScrapPickerId { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionCode { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string PaymentOn { get; set; }
        public string PaymentBy { get; set; }
    }
}
