using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Infrastructure.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } 
    }
}
