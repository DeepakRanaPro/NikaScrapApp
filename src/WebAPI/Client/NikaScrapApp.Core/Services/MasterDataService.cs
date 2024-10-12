using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApp.Infrastructure.Repositories;

namespace NikaScrapApp.Core.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMasterDataRepository _masterDataRepository;
        public MasterDataService(IMasterDataRepository masterDataRepositor)
        {
            _masterDataRepository = masterDataRepositor;
        }

        public MasterDataResponse GetRoles(Request request)
        {
            MasterDataResponse responseData = new MasterDataResponse();

            try
            {
                responseData.Data = _masterDataRepository.GetRoles(request);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

        public MasterDataResponse GetLocationTypes(Request request) 
        {
            MasterDataResponse responseData = new MasterDataResponse();

            try
            {
                responseData.Data = _masterDataRepository.GetLocationTypes(request);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

        public RateListResponse GetRateList(NikaScrapApp.Core.Models.Request.RateList rateListRequest)
        {
            RateListResponse responseData = new RateListResponse();

            try
            {
                responseData.Data = _masterDataRepository.GetRateList(rateListRequest);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

        public PincodeDetailsResponse GetPincodeDetails(string pincode)
        {
            PincodeDetailsResponse responseData = new PincodeDetailsResponse();

            try
            {
                responseData.Data = _masterDataRepository.GetPincodeDetails(pincode);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        } 
    }
}
