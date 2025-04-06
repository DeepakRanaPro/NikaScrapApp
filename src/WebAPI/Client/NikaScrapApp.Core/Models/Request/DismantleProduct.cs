
namespace NikaScrapApp.Core.Models.Request
{
    public class DismantleProduct
    {
        public int Productid { get; set; }
        public int ActionBy { get; set; }
        public int OrignalQuantity { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public List<DismantleElements> DismantleElements { get; set; } = new List<DismantleElements>();
    }

    public class DismantleElements
    {
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; } = string.Empty;
    } 
}
