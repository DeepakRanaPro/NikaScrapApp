namespace NikaScrapApp.Core.Models.Request
{
    public class ScrapPickupComplete
    {
        public List<ScrapProduct> ScrapProducts = new List<ScrapProduct>();
        public List<ExchangeProduct> ExchangeProducts = new List<ExchangeProduct>();
        public decimal TotalAmountToCustomer { get; set; }
        public int PaymentModeId { get; set; }
        public string TranscationId { get; set; } = string.Empty;
        public int PickupId { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }

    public class ScrapProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string ProductRemark { get; set; } = string.Empty;
    }

    public class ExchangeProduct
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }

}
