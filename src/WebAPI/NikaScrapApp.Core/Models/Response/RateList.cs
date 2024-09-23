
namespace NikaScrapApp.Core.Models.Response
{
    public class RateListResponse : Response 
    {
        public List<RateList> Data { get; set; } = new List<RateList>();
    }

    public class RateList
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public IEnumerable<Products> Products { get; set; } = Enumerable.Empty<Products>();
    }

    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string AppIcon { get; set; } = string.Empty;
        public string WebAppIcon { get; set; } = string.Empty;
    }

    public class ProductDetails : Products
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; } = string.Empty;

    }


}
