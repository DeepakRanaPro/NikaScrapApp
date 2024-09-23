using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IMasterDataService
    {
        RateListResponse GetRateList(Models.Request.RateList rateListRequest);
        MasterDataResponse GetRoles(Request request); 
    }
}