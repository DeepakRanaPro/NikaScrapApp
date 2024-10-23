using System.ComponentModel.DataAnnotations;

namespace NikaScrapApp.Web.Models.Request
{
    public class Login
    {
        [Required(ErrorMessage = "EmailId is Required!")]
        public string EmailId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
