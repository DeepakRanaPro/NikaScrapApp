using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
 
namespace NikaScrapApp.Core.Interfaces
{
    public interface ISchedulePickupService
    {
        SchedulePickupCommandResponse AddScrap(ScrapPickup scrapPickup);
        GetScrapResponse GetHistory(int userId, int statusId, int languageId);
        SchedulePickupCommandResponse PickupCancel(int pickupId);   
        SchedulePickupResponse GetInfo(int userId);

    }
}
