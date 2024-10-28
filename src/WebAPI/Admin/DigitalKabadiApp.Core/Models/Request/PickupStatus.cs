namespace DigitalKabadiApp.Core.Models.Request
{
    public class PickupStatus
    {
        public int PickupId { get; set; } 
        public int StatusId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public int ActionBy { get; set; } 
    }
}
