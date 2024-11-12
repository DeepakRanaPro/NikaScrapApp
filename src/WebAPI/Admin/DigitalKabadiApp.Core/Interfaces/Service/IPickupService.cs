using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IPickupService
    {
        PickupRecordsResponse PickupRecords(PickupReport pickupReport);
        ResponseData UpdatePickupStatus(PickupStatus pickupStatus);
        ResponseData AssignPickup(PickupAssign pickupAssign);
        ResponseDetail GetMobileNo(int UserId);
        ResponseDetail GetPickupCode(int pickupId);
    }
}