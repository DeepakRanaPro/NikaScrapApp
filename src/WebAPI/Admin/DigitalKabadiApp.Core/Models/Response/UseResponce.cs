namespace DigitalKabadiApp.Core.Models.Response
{
    public class UserResponse : Response
    {
        public List<UserDetail> Data { get; set; }
    }
    public class UserDetail 
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal mobileNo { get; set; }
        public int roleId { get; set; }
        public decimal pincode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string landmark { get; set; }
        public string fullAddress { get; set; }

   
    }
}
