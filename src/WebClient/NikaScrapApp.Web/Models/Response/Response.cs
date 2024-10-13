namespace NikaScrapApp.Web.Models.Response
{
    public class Response
    {
        public int ResponseCode { get; set; } 
        public bool IsSuccess { get; set; } 
        public string Message { get; set; } 
    }

    public class ResponseData : Response
    {
        public bool Data { get; set; }
    }
}
