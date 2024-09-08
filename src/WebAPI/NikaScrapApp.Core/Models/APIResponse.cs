using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models
{
    public class Response 
    {
        public int ResponseCode { get; set; } = 200;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Success";
    }
}
