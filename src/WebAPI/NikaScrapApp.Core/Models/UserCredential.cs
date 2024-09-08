using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models
{
    public class UserCredential
    {
        public int  Id { get; set; } 
        public string ObjectId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty; 
        public string MobileNo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
    }
}
