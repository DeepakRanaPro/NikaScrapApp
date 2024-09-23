using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Services
{
    public class SchedulePickupService : ISchedulePickupService
    {
        private readonly ISchedulePickupRepositary _scrapRepository;
        private readonly IUserRepository _userRepository; 

        public SchedulePickupService(ISchedulePickupRepositary scrapRepository, IUserRepository  userRepository)
        {
            _userRepository = userRepository;
            _scrapRepository = scrapRepository;
        }
        public SchedulePickupCommandResponse AddScrap(ScrapPickup scrapPickup)
        {
            SchedulePickupCommandResponse responseData = new SchedulePickupCommandResponse(); 
            try
            {
                responseData.Data = _scrapRepository.AddScrap(scrapPickup);
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

         
        public GetScrapResponse GetHistory(int userId, int statusId, int languageId)
        {
            GetScrapResponse responseData = new GetScrapResponse();

            try
            {
                responseData.Data = _scrapRepository.GetHistory(userId, statusId, languageId);
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

        public SchedulePickupCommandResponse PickupCancel(int pickupId) 
        {
            SchedulePickupCommandResponse responsedata = new SchedulePickupCommandResponse();
            try
            {
                responsedata.Data = _scrapRepository.PickupCancel(pickupId);
                {
                    if (!responsedata.Data)
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


        public SchedulePickupResponse GetInfo(int userId)  
        {
            SchedulePickupResponse responsedata = new SchedulePickupResponse();
            try
            {

                responsedata.Data.EstimateWeightlist = _scrapRepository.GetEstimatesWeight(userId);
                responsedata.Data.TimeSlot = _scrapRepository.GetTimeSlot();
                responsedata.Data.UserAddress = _userRepository.GetDefaultAddress(userId);
                 
                {
                    if (!responsedata.Data.EstimateWeightlist.Any())
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
