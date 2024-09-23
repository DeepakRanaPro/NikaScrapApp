using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Request
{
    public class UserProfileUpdate
    {
        public string Userid { get; set; } 
        public string Name { get; set; }
        public string EmailId { get; set; } 
    }
}
