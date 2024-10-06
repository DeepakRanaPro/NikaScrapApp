using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Request
{
    public class ScrapInfo
    {
        public int Id { get; set; }
        public string PickupCode { get; set; }
        public string PickUpDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status  { get; set; }
        public string FullAddress { get; set; } 
        public string EstimatedWeigh { get; set; }
        public NikaScrapApp.Core.Models.Response.UserAddress Address { get; set; }
    }
}
