using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public interface IPickupBoyRepository
    {
        bool InsertPickupProduct(int PickupId, List<PickupProducts> products);
        bool UpdateScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker);
        List<PickupHistory> PickupHistory(int userId);
        PickupInfo PickupDetail(int pickupId);
    }
}