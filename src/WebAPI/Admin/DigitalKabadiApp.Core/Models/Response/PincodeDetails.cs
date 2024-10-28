using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PincodeDetailsResponse : Response
    {
        public List<PincodeDetails> Data { get; set; } = new List<PincodeDetails>();
    }
    public class PincodeDetails
    {
        public int PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
