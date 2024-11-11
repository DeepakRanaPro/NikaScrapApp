using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class LoginResponse : Response  
    {
        public UsersDetail? Data { get; set; }
    }
    public class UsersDetail 
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
 
    }
}
