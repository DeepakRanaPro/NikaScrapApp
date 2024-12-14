using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NikaScrapApp.Core.Models.Request
{
    public class ScrapPickupByWastePicker
    {
        public int PickupId { get; set; } 
        public List<PickupProducts> ScrapProducts { get; set; } = new List<PickupProducts>();
        public List<PickupProducts> ExchangeProducts { get; set; } = new List<PickupProducts>();
        public decimal TotalAmount { get; set; }
        public decimal ExchangeProductsAmount { get; set; }
        public int PaymentModeId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string TransactionCode { get; set; } = string.Empty;
        public string PickupBoyRemarks { get; set; } = string.Empty;
    }

    public class  PickupProducts 
    {
        public int ProductTypeId { get; set; } 
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; } 
    }

}
