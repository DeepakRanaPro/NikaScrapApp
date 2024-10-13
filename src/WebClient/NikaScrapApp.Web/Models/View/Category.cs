using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.View
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name in english is required")]
        public string NameInEnglish { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name in hindi is required")]
        public string NameIsHindi { get; set; } = string.Empty;
    }
}
