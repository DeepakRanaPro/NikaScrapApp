using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Request
{
    public class UnApprovedPickup
    { 
        public int PickupId { get; set; }
        public int PickupProductId { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public int WareHouseInchargeId { get; set; }  
    }
}
