using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PickupHistory : Response
    {
        public List<Pickup> Data { get; set; }
    }
    public class Pickup
    {
        public int Id { get; set; }
        public string PickupCode { get; set; }
        public string PickUpDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public string FullAddress { get; set; }
        public string EstimatedWeigh { get; set; }
        public int UserAddressId { get; set; }
        public string LocationType { get; set; }
        public string landmark { get; set; } 
        public bool IsDefault { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int LocationTypeId { get; set; }
        public string State { get; set; }
    }

    public class Address
    {
        public string LocationType { get; set; }
        public string Landmark { get; set; }
        public string FullAddress { get; set; }
        public bool IsDefault { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int LocationTypeId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
