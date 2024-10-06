using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Interfaces
{
    public interface ISchedulePickupRepositary
    {
        NikaScrapApp.Core.Models.Request.ScrapInfo AddScrap(NikaScrapApp.Core.Models.Request.ScrapPickup scrap);
        List<NikaScrapApp.Core.Models.Request.ScrapInfo> GetHistory(int userId, int statusId, int languageId, int PageNumber, int RowsOfPage); 

        List<NikaScrapApp.Core.Models.Response.EstimateWeight> GetEstimatesWeight(int userId);
        List<NikaScrapApp.Core.Models.Response.TimeSlot> GetTimeSlot(int userId);
        NikaScrapApp.Core.Models.Request.ScrapInfo PickupCancel(int pickupId); 
    }
}
