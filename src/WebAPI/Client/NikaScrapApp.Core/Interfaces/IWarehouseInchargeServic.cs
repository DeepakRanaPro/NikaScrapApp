using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IWarehouseInchargeServic
    {
        UnappprovedPickups GetUnapprovedPickups(string PickupCode);
        UnApprovedDetails GetUnapprovedPickupDetails(int pickupId);
        UnApprovedDetails ApprovePickupProducts(NikaScrapApp.Core.Models.Request.UnApprovedPickup unApprovedPickup);
    }
}