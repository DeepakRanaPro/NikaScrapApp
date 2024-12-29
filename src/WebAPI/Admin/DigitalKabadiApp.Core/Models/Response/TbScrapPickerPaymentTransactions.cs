

namespace DigitalKabadiApp.Core.Models.Response
{
    public class TbScrapPickerPaymentTransactions:Response
    {
        public List<TbScrapPickerPaymentTransaction>Data { get; set; }
    }
    public class TbScrapPickerPaymentTransaction
    {
        public int Id { get; set; }
        public string ScrapPickerName { get; set; }
        public string TransactionType { get; set; }
        public string PaymentMode { get; set; }
        public int TransactionCode { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public string PaymentOn { get; set; }
        public string PaymentBy { get; set; }
        public string Remarks { get; set; }
        public string PickupCode { get; set; }
    }
}
