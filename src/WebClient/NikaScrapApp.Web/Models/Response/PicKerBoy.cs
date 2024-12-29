namespace NikaScrapApp.Web.Models.Response
{
    public class PicKerBoy
    {
        public List<PicKerBoys> Data { get; set; }
    }
         public class PicKerBoys
        { 
            public int ScrapPickerId { get; set; }
            public string ScrapPickerName { get; set; }
            public decimal CurrentBalance { get; set; }
            public DateTime LastTransactionOn { get; set; }
    }
}
