namespace NikaScrapApp.Core.Models.Response
{
    public class MasterDataResponse : Response 
    {
        public List<MasterData> Data { get; set; } = new List<MasterData>();
    }
    public class MasterData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
