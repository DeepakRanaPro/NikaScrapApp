using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Services
{
    public class PickupService : IPickupService
    {
        private readonly IPickupRepository _pickupRepository;
        public PickupService(IPickupRepository pickupRepository)
        {
            _pickupRepository = pickupRepository;
        }

        public PickupRecordsResponse PickupRecords(PickupReport pickupReport)
        {
            PickupRecordsResponse responseData = new PickupRecordsResponse();

            try
            {
                responseData.Data = _pickupRepository.GetPickupRecords(pickupReport);
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

        public ResponseData UpdatePickupStatus(PickupStatus pickupStatus)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _pickupRepository.UpdatePickupStatus(pickupStatus);
                if (!responseData.Data)
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

        public ResponseData AssignPickup(PickupAssign pickupAssign) 
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _pickupRepository.AssignPickup(pickupAssign);
                if (!responseData.Data)
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
 
        ResponseDetail IPickupService.GetMobileNo(int UserId)
        {
            ResponseDetail responsedata = new ResponseDetail();
            try
            {
                responsedata.Data = _pickupRepository.GetMobileNo(UserId);

                {
                    if (string.IsNullOrEmpty(responsedata.Data))
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;

                    }
                }
            }
            catch (Exception ex)
            {
                responsedata.IsSuccess = false;
                responsedata.Message = $"exception:{ex.Message}";
                responsedata.ResponseCode = 999;
            }
            return responsedata;
        }

        ResponseDetail IPickupService.GetPickupCode(int pickupId)
        {
            ResponseDetail responsedata = new ResponseDetail();
            try
            {
                responsedata.Data = _pickupRepository.GetPickupCode(pickupId);

                {
                    if (string.IsNullOrEmpty(responsedata.Data))
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;

                    }
                }
            }
            catch (Exception ex)
            {
                responsedata.IsSuccess = false;
                responsedata.Message = $"exception:{ex.Message}";
                responsedata.ResponseCode = 999;
            }
            return responsedata;
        }
    }
}
