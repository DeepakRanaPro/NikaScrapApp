using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Models.Request
{
    public class UserManageUpdate
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }


    }
}
