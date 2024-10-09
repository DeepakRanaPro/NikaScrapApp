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
        public SchedulePickupCommandResponse AddScrap(ScrapPickup scrapPickup,int languageId)
        {
            SchedulePickupCommandResponse responseData = new SchedulePickupCommandResponse(); 
            try
            {
                responseData.Data = _scrapRepository.AddScrap(scrapPickup);
                 
                responseData.Data.Address = _userRepository.GetAddress(scrapPickup.UserId, languageId).Where(x=> x.Id == scrapPickup.AddressId).FirstOrDefault();
                 
                if (responseData.Data==null)
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

         
        public GetScrapResponse GetHistory(int userId, int statusId, int languageId, int PageNumber, int RowsOfPage)
        {
            GetScrapResponse responseData = new GetScrapResponse();

            try
            {
                responseData.Data = _scrapRepository.GetHistory(userId, statusId, languageId, PageNumber,  RowsOfPage);


                responseData.Data.ForEach(x =>
                { 
                    x.Address = _userRepository.GetAddressDetails(x.UserAddressId); 
                }); 

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

        public SchedulePickupCommandResponse PickupCancel(int pickupId,int languageId) 
        {
            SchedulePickupCommandResponse responsedata = new SchedulePickupCommandResponse(); 
            try
            {
                responsedata.Data = _scrapRepository.PickupCancel(pickupId);
                responsedata.Data.Address = _userRepository.GetAddressByPickupId(pickupId, languageId);
                 
                    if (responsedata.Data == null)
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;

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
                responsedata.Data.TimeSlot = _scrapRepository.GetTimeSlot(userId);
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
