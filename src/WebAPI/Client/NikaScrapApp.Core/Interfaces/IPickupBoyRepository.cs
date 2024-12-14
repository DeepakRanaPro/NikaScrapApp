using NikaScrapApp.Core.Models.Request;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public interface IPickupBoyRepository
    {
        bool InsertPickupProduct(int PickupId, List<PickupProducts> products);
        bool UpdateScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker);
    }
}