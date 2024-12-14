using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class ExchangeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
