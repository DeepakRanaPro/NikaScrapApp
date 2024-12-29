using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Infrastructure.Repositories;

namespace DigitalKabadiApp.Core.Services
{
    public class PickUpBoyService : IPickUpBoyService
    {
        private readonly IPickupBoyRepository _pickupRepository;
        public PickUpBoyService(IPickupBoyRepository pickupRepository)
        {
            _pickupRepository = pickupRepository;
        }
        public Core.Models.Response.PickupHistory GetHistory(int id)
        {
            PickupHistory responseData = new PickupHistory();

            try
            {
                responseData.Data = _pickupRepository.GetHistory(id);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = true;
                    responseData.Message = "No record exists!";
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

        public Core.Models.Response.PickupResponse Get(int id)
        {
            PickupResponse responseData = new PickupResponse();

            try
            {
                responseData.Data = _pickupRepository.Get(id);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = true;
                    responseData.Message = "No record exists!";
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
        public Core.Models.Response.PickupDetail post(Products products)
        {
            PickupDetail responseData = new PickupDetail();

            try
            {
                bool result = _pickupRepository.post(products);
                if (!result)
                {
                    responseData.IsSuccess = true;
                    responseData.Message = "No record exists!";
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
        public Core.Models.Response.ScrapPickerPaymentResponce PaymentTransactions(Core.Models.Request.ScrapPickerPaymentTransactions scrapPickerPaymentTransactions)
        {
            ScrapPickerPaymentResponce responseData = new ScrapPickerPaymentResponce();

            try
            {
                bool result = _pickupRepository.PaymentTransactions(scrapPickerPaymentTransactions);
                if (!result)
                {
                    responseData.IsSuccess = true;
                    responseData.Message = "No record exists!";
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
         
        public DigitalKabadiApp.Core.Models.Response.ResponseData ExchangeProduct(NikaScrapApp.Core.Models.Request.ScrapPickerExchangeProducts scrapPickerExchangeProducts) 
        {
            DigitalKabadiApp.Core.Models.Response.ResponseData responsedata = new();

            try
            {
                bool result = _pickupRepository.ExchangeProduct(scrapPickerExchangeProducts);
                if (!result)
                {
                    responsedata.IsSuccess = true;
                    responsedata.Message = "no record exists!";
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
    }

}
