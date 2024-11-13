namespace DigitalKabadiApp.Core.Models.Response
{
    public class FeedbackResponse: Response
    {
        public List<Feedback> Data {  get; set; } 
    }
    public class Feedback
    {
        public int Id { get; set; }
        public string PickupCode { get; set; }
        public int PickupId { get; set; }
        public string userName { get; set; }
        public int Rating { get; set; } 
        public string ImagePath { get; set; }=string .Empty;
        public string Description { get; set; } = string.Empty;
        public string CreatedOn { get; set; }= string.Empty;
    }

    //RatingFrom,  RatingTo, UserId, CreatedFrom , CreatedTo 
}
