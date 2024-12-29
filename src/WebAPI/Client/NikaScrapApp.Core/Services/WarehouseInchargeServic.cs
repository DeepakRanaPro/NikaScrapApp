using DigitalKabadiApp.Core.Interfaces.Repository;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Response;


namespace NikaScrapApp.Core.Services
{
    public class WarehouseInchargeServic : IWarehouseInchargeServic
    {
        private readonly IWarehouseInchargeRepository _warehouseInchargeRepository;
        public WarehouseInchargeServic(IWarehouseInchargeRepository warehouseInchargeRepository)
        {
            _warehouseInchargeRepository = warehouseInchargeRepository;
        }

       

        public NikaScrapApp.Core.Models.Response.UnappprovedPickups GetUnapprovedPickups(string PickupCode)
        {
            NikaScrapApp.Core.Models.Response.UnappprovedPickups responseData = new NikaScrapApp.Core.Models.Response.UnappprovedPickups();
            try
            {
                responseData.Data = _warehouseInchargeRepository.GetUnapprovedPickups(PickupCode);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        } public UnApprovedDetails GetUnapprovedPickupDetails(int pickupId)
        {
            UnApprovedDetails responseData = new UnApprovedDetails();
            try
            {
                responseData.Data = _warehouseInchargeRepository.GetUnapprovedPickupDetails(pickupId);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
        public UnApprovedDetails ApprovePickupProducts(NikaScrapApp.Core.Models.Request.UnApprovedPickup unApprovedPickup)
        {
            UnApprovedDetails responseData = new UnApprovedDetails();
            try
            {
                bool result = _warehouseInchargeRepository.ApprovePickupProducts(unApprovedPickup);

                if (!result)
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
    }
}
