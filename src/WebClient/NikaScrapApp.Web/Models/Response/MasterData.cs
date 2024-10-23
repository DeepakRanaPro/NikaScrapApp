namespace NikaScrapApp.Web.Models.Response
{
    public class MasterDataResponse : Response
    {
        public List<MasterData> Data { get; set; }
    }
    public class MasterData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
