using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class PickupReport
    { 
        public string PickupCode { get; set; } = string.Empty;
        public int UserId { get; set; } 
        public int StatusId { get; set; } 
        public int LocationTypeId { get; set; } 
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;

        public string CreatedFromDate { get; set; } = string.Empty; 
        public string CreatedToDate { get; set; } = string.Empty; 
    }
}
