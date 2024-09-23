using NikaScrapApp.Core.Models;

namespace NikaScrapApp.Core.Models.Request
{
    public class UserAddress  : Response.UserAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }  
        public string Pincode { get; set; } = string.Empty;
        public string LocationType { get; set; } = string.Empty;
        public string Landmark { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
