using NikaScrapApp.Web.Models.Request;

namespace NikaScrapApp.Web.Models.Response
{
    public class CategoryResponse : Response
    {
        public List<Category> Data { get; set; }
    }
}
