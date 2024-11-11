using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int roleId { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public decimal pincode { get; set; }
        public decimal mobileNo { get; set; }



    }
}
