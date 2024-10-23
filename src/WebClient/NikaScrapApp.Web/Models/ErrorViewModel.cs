namespace NikaScrapApp.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RequestUrl { get; set; }
        public Exception Exception { get; set; }
    }
}
