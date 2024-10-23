using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class MasterDataResponse : Response
    {
        public List<MasterData> Data { get; set; } 
    }
    public class MasterData
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }


}
