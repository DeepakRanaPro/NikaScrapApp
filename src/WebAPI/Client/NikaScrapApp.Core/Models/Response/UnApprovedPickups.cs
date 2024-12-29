

namespace NikaScrapApp.Core.Models.Response
{

    public class UnappprovedPickups : Response
    {
        public List<UnappprovedPickup> Data { get; set; }=new List<UnappprovedPickup>();
    }

    public class UnappprovedPickup
    { 
        public int PickupId { get; set; }
        public string PickupCode { get; set; }
        public string PickupDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public decimal estimatedWeigh { get; set; }
        public string PickupBoy { get; set; }
        public decimal TotalAmount { get; set; }
        
    }
    public class UnApprovedDetails : Response
    {
        public List<UnApproved> Data { get; set; }
    }
        public class UnApproved
        {
            public int PickupProductId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string UnitName { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; } = 0;
            public decimal ApprovedQuantity { get; set; }
        }
    
}
