using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IPickupBoyService
    {
        ResponseData InsertPickupProduct(int PickupId, List<PickupProducts> products);
        ResponseData UpdateScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker);
    }
}