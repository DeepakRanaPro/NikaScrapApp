using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class ExchangeProductAccount : Response
    { 
        public List<ExchangeProductAccounts> Data { get; set; } 
    }
        public class ExchangeProductAccounts 
        {
         public int ScrapPickerId { get; set; }
        public int Name { get; set; }
        public int TotalProduct { get; set; }
        }
}
