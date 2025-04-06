using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Response
{
    public class PickupInfo
    {
        public decimal TotalAmountToCustomer { get; set; }
        public int TransactionCode { get; set; }
        public string PaymentMode { get; set; }
        public string Remarks { get; set; }
        public List<Product> ScrapProducts { get; set; } = new List<Product>();
        public List<Product> ExchangedProducts { get; set; } = new List<Product>();
    }

    public class PickupInfoConsolidated
    {
        public decimal TotalAmountToCustomer { get; set; }
        public string PaymentMode { get; set; }
        public int TransactionCode { get; set; }
        public string Remarks { get; set; }

        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    public class PickupDetail : Response
    {
        public PickupInfo Data { get; set; } = new PickupInfo(); 
    }
    public class Product
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

    }
}

