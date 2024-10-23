using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.Response
{
    public class LoginResponse : Response
    {
        public User? Data { get; set; }
    }
    public class User
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
