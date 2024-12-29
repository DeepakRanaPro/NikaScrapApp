using NikaScrapApp.Core.Models.Response;


namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IWarehouseInchargeRepository
    {
        List<NikaScrapApp.Core.Models.Response.UnappprovedPickup> GetUnapprovedPickups(string PickupCode);
        List<NikaScrapApp.Core.Models.Response.UnApproved> GetUnapprovedPickupDetails(int pickupId);
        bool ApprovePickupProducts(NikaScrapApp.Core.Models.Request.UnApprovedPickup unApprovedPickup);
    }
}