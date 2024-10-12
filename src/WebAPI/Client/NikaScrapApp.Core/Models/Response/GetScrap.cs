using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Response
{
    public class GetScrapResponse : Response
    {
        public List<NikaScrapApp.Core.Models.Request.ScrapInfo> Data { get; set; }
    }
}
