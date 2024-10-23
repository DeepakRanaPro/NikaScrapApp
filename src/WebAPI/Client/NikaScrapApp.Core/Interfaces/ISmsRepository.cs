using NikaScrapApp.Core.Models.Response; 

namespace NikaScrapApp.Core.Interfaces
{
    public interface ISmsRepository
    {
        bool SaveSmsApiResponse(SmsApi SmsApiResponse);
    }
}