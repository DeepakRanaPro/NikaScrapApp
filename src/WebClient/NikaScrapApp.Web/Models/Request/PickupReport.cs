namespace NikaScrapApp.Web.Models.Request
{
    public class PickupReport
    {
        public string PickupCode { get; set; } = "0";
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int LocationTypeId { get; set; }
        public string State { get; set; } = "0";
        public string City { get; set; } = "0";
        public string FromDate { get; set; } = "1900-01-01";
        public string ToDate { get; set; } = "1900-01-01";

        public string CreatedFromDate { get; set; } = "1900-01-01";
        public string CreatedToDate { get; set; } = "1900-01-01";
    }
}
