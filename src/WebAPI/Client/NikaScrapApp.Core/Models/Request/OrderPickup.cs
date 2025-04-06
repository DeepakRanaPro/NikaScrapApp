namespace NikaScrapApp.Core.Models.Request
{
    public class OrderPickup
    {
        public int PickupId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ExchangeProductsAmount { get; set; }
        public decimal PaidAmountToCustomer { get; set; }
        public int PaymentModeId { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public List<ProductInfo> ScrapProducts { get; set; } = new List<ProductInfo>();
        public List<ProductInfo> ExchangedProduct { get; set; } = new List<ProductInfo>();
    }


    public class ProductInfo
    {
        public int ProductId { get; set; } 
        public string ProductDescription { get; set; } = string.Empty; 
        public int unitId { get; set; }
        public decimal price { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
