
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

        public string AlternateMobileNumber { get; set; } = string.Empty;
        public int LocationTypeId { get; set; } 
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
 
    }
}
