using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public interface IMasterDataRepository
    {
        List<NikaScrapApp.Core.Models.Response.RateList> GetRateList(Core.Models.Request.RateList  rateListRequest);
        List<MasterData> GetRoles(Request request);
    
    }
}