using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Services
{
    public class DismantleService : IDismantleService
    {
        private readonly IDismantleRepository _dismantleRepository;
        public DismantleService(IDismantleRepository dismantleRepository)
        {
            _dismantleRepository = dismantleRepository;
        }

        public ResponseData DismantleProduct(DismantleProduct dismantleProduct)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _dismantleRepository.DismantleProduct(dismantleProduct);

                if (!responseData.Data)
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

        public ProcessRecponce ProcessDetails(int ProductId)
        {
            ProcessRecponce responseData = new ProcessRecponce();

            try
            {
                responseData.Data = _dismantleRepository.ProcessDetails(ProductId);

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
