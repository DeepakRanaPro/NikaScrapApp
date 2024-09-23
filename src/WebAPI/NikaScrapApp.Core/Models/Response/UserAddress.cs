
namespace NikaScrapApp.Core.Models.Response 
{
    public class UserAddressResponse : Response 
    {
        public List<UserAddress> Data { get; set; } = new List<UserAddress>(); 
    }

    public class UserAddress
    {
        public int  Id { get; set; } 
        public string Pincode { get; set; } = string.Empty;
        public string LocationType { get; set; } = string.Empty;
        public string Landmark { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
    }
}
