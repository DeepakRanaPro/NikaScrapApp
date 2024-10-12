namespace NikaScrapApp.Core.Models.Response
{
    public class SchedulePickupResponse : Response
    {
        public SchedulePickupDetail Data { get; set; } = new SchedulePickupDetail();
    }
    public class SchedulePickupDetail
    {
        public List<EstimateWeight> EstimateWeightlist { get; set; }
        public List<TimeSlot> TimeSlot { get; set; }

        public UserAddress UserAddress { get; set; }

       
    }
    public class EstimateWeight
    {
     public int Id { get; set; }
     public string Name { get; set; }
    }
    public class TimeSlot
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateStaus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        
    }
}
