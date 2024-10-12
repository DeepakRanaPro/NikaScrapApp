
namespace NikaScrapApp.Core.Models.Request
{
    public class OTP : Login
    {
        public string Otp { get; set; } = string.Empty;
    }
}
