using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class ExchangeProductResponse : Response
    { 
            public List<ExchangeProduct> Data { get; set; }
    }

    public class ExchangeProduct
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
