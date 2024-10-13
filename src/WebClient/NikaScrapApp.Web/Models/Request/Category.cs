using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.Request
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string NameInEnglish { get; set; }
        public string NameIsHindi { get; set; }
    }
}
