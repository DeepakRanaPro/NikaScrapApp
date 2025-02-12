using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Response
{

    public class PickupDetailsResponse : Response 
    {
        public PickupDetails Data { get; set; } = new PickupDetails();
    }
     
    public class PickupDetails
    {
        public List<Product> ScrapProducts { get; set; } = new List<Product>();
        public List<Product> ExchangeProducts { get; set; } = new List<Product>(); 
        public decimal TotalAmountToCustomer { get; set; } 
        public string PaymentModeId { get; set; } = string.Empty;
        public string TranscationID { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
