using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IOrderPickupService
    {
        ResponseData ProcessOrderPickup(OrderPickup orderPickup);
    }
}