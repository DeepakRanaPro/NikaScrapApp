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
        bool AddScrap(NikaScrapApp.Core.Models.Request.ScrapPickup scrapPickup);
        List<NikaScrapApp.Core.Models.Request.ScrapInfo> GetHistory(int userId, int statusId, int languageId); 

        List<NikaScrapApp.Core.Models.Response.EstimateWeight> GetEstimatesWeight(int userId);
        List<NikaScrapApp.Core.Models.Response.TimeSlot> GetTimeSlot();
        bool PickupCancel(int pickupId); 
    }
}
