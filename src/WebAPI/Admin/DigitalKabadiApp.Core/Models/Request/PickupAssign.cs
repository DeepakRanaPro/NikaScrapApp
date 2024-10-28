namespace DigitalKabadiApp.Core.Models.Request
{
    public class PickupAssign 
    {
        public int PickupId { get; set; } 
        public int UserId { get; set; } 
        public string Remarks { get; set; } = string.Empty;
        public int ActionBy { get; set; } 
    }
}
