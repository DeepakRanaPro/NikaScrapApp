

namespace NikaScrapApp.Core.Models.Request
{
    public class ScrapPickerExchangeProducts 
    {
        public int ScrapPickerId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ActionBy { get; set; }
        public string Remarks { get; set; } = string.Empty;


    }
}
