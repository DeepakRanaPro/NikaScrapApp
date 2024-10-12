using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Request
{
    public class ScrapPickup
    {
        public int UserId { get; set; }
        public DateTime PickUpDate { get; set; }
        public int TimeSlotId { get; set; }
        public int EstimatedWeightId { get; set; }
        public int AddressId { get; set; }
    }
}
