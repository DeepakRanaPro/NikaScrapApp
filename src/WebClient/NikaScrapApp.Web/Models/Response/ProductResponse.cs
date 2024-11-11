namespace NikaScrapApp.Web.Models.Response
{
    public class ProductResponse : Response
    {
        public List<Product> Data { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameInHindi { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string AppIcon { get; set; } = string.Empty;
        public decimal Stock { get; set; }
        public int ProductPriceId { get; set; }
        public string RoleName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
    }
}
