using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PickupRecordsResponse : Response
    {
        public List<PickupRecords> Data { get; set; } 
    }
    public class PickupRecords
    {
        public string Id { get; set; }
        public string PickupCode { get; set; } = string.Empty;
        public string PickUpDate { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty; 
        public string TimeSlot { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string EstimatedWeigh { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string LocationType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
