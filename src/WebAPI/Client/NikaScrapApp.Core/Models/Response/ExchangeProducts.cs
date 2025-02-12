using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Response
{
    public class ExchangeProductsResponse : Response 
    {
        public List<ExchangeProducts> Data { get; set; } = new List<ExchangeProducts>();
    }
    public class ExchangeProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } 
        public decimal Price { get; set; } 
    }
}
