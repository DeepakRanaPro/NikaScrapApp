using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Services
{
    public class SmsService : ISmsService
    {

        private readonly ISmsRepository _smsRepository;
        public SmsService(ISmsRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        public ResponseData SaveSmsApiResponse(SmsApi SmsApiResponse)
        {
            ResponseData response = new ResponseData();

            try
            {
                response.Data = _smsRepository.SaveSmsApiResponse(SmsApiResponse);

                if (!response.Data)
                {
                    response.IsSuccess = false;
                    response.Message = "Fail";
                    response.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Exception: {ex.Message}";
                response.ResponseCode = 999;
            }
            return response;
        }

    }
}
