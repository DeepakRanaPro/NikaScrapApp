using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Request
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string SourceType { get; set; }        
        public string Subject { get; set; }
        public string Description { get; set; }
       
        public string FromEmail { get; set; } 
        public int UserId { get; set; }
        public string IsDeleted { get; set; }

        public string CreatedOn { get; set; }

    }
}
