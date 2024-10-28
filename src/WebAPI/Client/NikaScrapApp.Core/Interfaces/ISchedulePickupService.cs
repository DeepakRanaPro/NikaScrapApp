using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
 
namespace NikaScrapApp.Core.Interfaces
{
    public interface ISchedulePickupService
    {
        SchedulePickupCommandResponse AddScrap(ScrapPickup scrapPickup, int languageId);
        GetScrapResponse GetHistory(int userId, int statusId, int languageId, int PageNumber, int RowsOfPage);
        SchedulePickupCommandResponse PickupCancel(int pickupId, int languageId);
        SchedulePickupResponse GetInfo(int userId);
        ResponseResult GetMobileNo(int UserId);
    }
}
