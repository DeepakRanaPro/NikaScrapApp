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
         
        public int id { get; set; }
        public string PickupCode { get; set; }
        public string pickUpDate { get; set; }
        public string timeSlot { get; set; }
        public string status { get; set; }
        public string fullAddress { get; set; }
        public string estimatedWeigh { get; set; }
        public int userAddressId { get; set; }
        public string locationType { get; set; }
        public string landmark { get; set; } 
        public bool isDefault { get; set; }
        public string alternateMobileNumber { get; set; }
        public int locationTypeId { get; set; }
        public string state { get; set; }
    }

    public class Address
    {
        public string locationType { get; set; }
        public string landmark { get; set; }
        public string fullAddress { get; set; }
        public bool isDefault { get; set; }
        public string alternateMobileNumber { get; set; }
        public int locationTypeId { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
    
}
