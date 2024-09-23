using System.ComponentModel.DataAnnotations;
namespace NikaScrapApp.Core.Models.Response
{
    public class UserResponse : Response  
    {
        public Users? Data { get; set; } 
    }
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;

        public JWTTokenDetails JWTTokenDetail { get; set; } 
        public DateTime CreatedOn { get; set; }
    }
}
