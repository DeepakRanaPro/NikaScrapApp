
namespace NikaScrapApp.Core.Models.Response
{
    public class JWTTokenDetailResponse : Response
    {
        public JWTTokenDetails? Data { get; set; } 
    }

    public class JWTTokenDetails
    {
        public string TokenType { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
    }
}
