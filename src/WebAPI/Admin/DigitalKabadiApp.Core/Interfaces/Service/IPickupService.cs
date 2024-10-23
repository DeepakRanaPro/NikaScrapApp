using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IPickupService
    {
        PickupRecordsResponse PickupRecords(PickupReport pickupReport);
    }
}