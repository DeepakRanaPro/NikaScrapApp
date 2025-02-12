

namespace DigitalKabadiApp.Core.Models.Response
{
    public class ExchangeProductResponse : Response
    { 
            public List<PickerboysProduct> Data { get; set; }
    }

    public class PickerboysProduct
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public decimal Stock { get; set; } 
    }

}
