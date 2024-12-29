using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Infrastructure.Repositories;

namespace DigitalKabadiApp.Core.Services
{
    public class ScrapPickerPaymentService : IScrapPickerPaymentService
    {
        private readonly IScrapPickerPaymentRepository _scrapPickerPaymentRepository;
        public ScrapPickerPaymentService(IScrapPickerPaymentRepository scrapPickerPaymentRepository)
        {
            _scrapPickerPaymentRepository = scrapPickerPaymentRepository;
        }

        public ScrapPickerPaymentAccountDetail PickerPaymentAccountDetail(int ScrapPickerId)
        {
            ScrapPickerPaymentAccountDetail responseData = new ScrapPickerPaymentAccountDetail();

            try
            {
                responseData.Data = _scrapPickerPaymentRepository.PickerPaymentAccountDetail(ScrapPickerId);
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
        //public PickerPaymentTransactions PickerPaymentTransactions(int ScrapPickerId, int PickupId)
        //{
        //    PickerPaymentTransactions responseData = new PickerPaymentTransactions();

        //    try
        //    {

        //        responseData.Data = _scrapPickerPaymentRepository.PickerPaymentTransactions(ScrapPickerId, PickupId);
        //        if (!responseData.Data.Any())
        //        {
        //            responseData.IsSuccess = false;
        //            responseData.Message = "Fail";
        //            responseData.ResponseCode = 999;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData.IsSuccess = false;
        //        responseData.Message = $"Exception:{ex.Message}";
        //        responseData.ResponseCode = 999;
        //    }
        //    return responseData;
        //}
        //public Core.Models.Response.ScrapPickerPaymentAccount ScrapPickerPaymentAccounts(int ScrapPickerId)
        //{
        //    ScrapPickerPaymentAccount responseData = new ScrapPickerPaymentAccount();

        //    try
        //    {
        //        responseData.Data = _scrapPickerPaymentRepository.PickerPaymentAccounts(ScrapPickerId);
        //        if (!responseData.Data.Any())
        //        {
        //            responseData.IsSuccess = false;
        //            responseData.Message = "Fail";
        //            responseData.ResponseCode = 999;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData.IsSuccess = false;
        //        responseData.Message = $"Exception:{ex.Message}";
        //        responseData.ResponseCode = 999;
        //    }
        //    return responseData;
        //}
        public Core.Models.Response.TbScrapPickerPaymentTransactions ScrapPickerPaymentTransaction(int id)
        {
            TbScrapPickerPaymentTransactions responseData = new TbScrapPickerPaymentTransactions();

            try
            {
                responseData.Data = _scrapPickerPaymentRepository.ScrapPickerPaymentTransaction(id);
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

    }
}
