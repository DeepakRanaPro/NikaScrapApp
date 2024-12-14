using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PickupResponse : Response
    {
        public List<UpApprovedPikup> Data { get; set; }
    }
        public class UpApprovedPikup
        {
            //UpApprovedPikup
            public int Id { get; set; }
            public string PickupCode { get; set; }
            public string PickUpDate { get; set; }
            public string TimeSlot { get; set; }
            public string Status { get; set; }
            public string EstimatedWeigh { get; set; }
            public int PickerCode { get; set; }
            public string PickerName { get; set; }
        }

    
}
