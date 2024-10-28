using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IPickupRepository
    {
        List<PickupRecords> GetPickupRecords(PickupReport pickupReport);
        bool UpdatePickupStatus(PickupStatus pickupStatus);
        bool AssignPickup(PickupAssign pickupAssign);
    }
}