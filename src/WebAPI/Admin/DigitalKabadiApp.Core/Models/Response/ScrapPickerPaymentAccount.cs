


namespace DigitalKabadiApp.Core.Models.Response
{
    public class ScrapPickerPaymentAccount:ResponseData
    {
        public List<ScrapPickerPaymentAccounts> Data { get; set; } = new List<ScrapPickerPaymentAccounts>();
    }
    public class ScrapPickerPaymentAccounts
    {
        public int ScrapPickerId { get; set; }
        public string ScrapPickerName { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
