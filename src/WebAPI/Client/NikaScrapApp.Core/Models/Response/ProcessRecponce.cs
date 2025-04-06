namespace NikaScrapApp.Core.Models.Response
{
    public class ProcessRecponce : Response
    {
        public List<ProcessDetails> Data { get; set; }
    }
    public class ProcessDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
    }
}
