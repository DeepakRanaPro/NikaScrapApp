using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class SmsApi
    {
        public string Status { get; set; }
        public string Code { get; set; }

        [JsonProperty("Message-Id")]
        public string MessageId { get; set; }
        public string Description { get; set; }
    }
}
