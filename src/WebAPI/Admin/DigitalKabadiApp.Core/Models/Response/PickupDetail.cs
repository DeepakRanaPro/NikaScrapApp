

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PickupDetail : Response
    {
        public Products? Data { get; set; }
    }

        public class Products
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string UnitName { get; set; }
            public decimal Price { get; set; }

        }
}
    


