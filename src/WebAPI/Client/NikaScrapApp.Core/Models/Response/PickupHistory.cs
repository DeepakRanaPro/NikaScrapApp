namespace NikaScrapApp.Core.Models.Response
{

    public class PickupHistoryList : Response
    {
        public List<PickupHistory> Data { get; set; }
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

    //public class UserAddress
    //{
    //    public int Id { get; set; }
    //    public string Pincode { get; set; } = string.Empty;
    //    public string LocationType { get; set; } = string.Empty;
    //    public string Landmark { get; set; } = string.Empty;
    //    public string FullAddress { get; set; } = string.Empty;
    //    public bool IsDefault { get; set; }
    //    public string AlternateMobileNumber { get; set; } = string.Empty;
    //    public int LocationTypeId { get; set; }
    //    public string State { get; set; } = string.Empty;
    //    public string City { get; set; } = string.Empty;
    //}
    //public class PickupHistory
    //{
    //    public int PickupId { get; set; }
    //    public string PickupCode { get; set; } = string.Empty;
    //    public string TimeSlot { get; set; } = string.Empty;
    //    public string Status { get; set; } = string.Empty;
    //    public string FullAddress { get; set; } = string.Empty;
    //    public string EstimatedWeigh { get; set; } = string.Empty;
    //    public int UserAddressId { get; set; } 
    //    public UserAddress UserAddressDetails { get; set; } = new UserAddress(); 
    //}

    //public class PickupHistory
    //{
    //    public int PickupId { get; set; }
    //    public string PickupCode { get; set; } = string.Empty;
    //    public string TimeSlot { get; set; } = string.Empty;
    //    public string Status { get; set; } = string.Empty;
    //    public string FullAddress { get; set; } = string.Empty;
    //    public string EstimatedWeigh { get; set; } = string.Empty;
    //    public int UserAddressId { get; set; }
    //    public UserAddress UserAddressDetails { get; set; } = new UserAddress();
    //}

    //PickupCode, Status, UserId, FromDate, ToDate
}
