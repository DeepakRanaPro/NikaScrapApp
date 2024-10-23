using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface ISmsService
    {
        ResponseData SaveSmsApiResponse(SmsApi SmsApiResponse);
    }
}