using NikaScrapApp.Core.Models.Request;

namespace NikaScrapApp.Core.Interfaces 
{
    public interface IOrderPickupRepository
    {
        bool ProcessOrderPickup(OrderPickup orderPickup);
    }
}