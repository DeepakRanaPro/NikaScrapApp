namespace NikaScrapApp.Core.Models.Response
{
    public class PickupHistory
    {
        public int PickupId { get; set; }
        public string PickupCode { get; set; } = string.Empty;
        public string TimeSlot { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string EstimatedWeigh { get; set; } = string.Empty;
        public int UserAddressId { get; set; } 
        public UserAddress UserAddressDetails { get; set; } = new UserAddress(); 
    }

    public class PickupHistory
    {
        public int PickupId { get; set; }
        public string PickupCode { get; set; } = string.Empty;
        public string TimeSlot { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string EstimatedWeigh { get; set; } = string.Empty;
        public int UserAddressId { get; set; }
        public UserAddress UserAddressDetails { get; set; } = new UserAddress();
    }

    //PickupCode, Status, UserId, FromDate, ToDate
}
