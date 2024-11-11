using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class Product
    {
        public int ProductPriceId { get; set; } 
        public string Price { get; set; } 
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string NameInHindi { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int ActionBy { get; set; } 
    }
}
