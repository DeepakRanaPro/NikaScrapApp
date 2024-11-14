using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Services
{
    public class ExchangeProductService : IExchangeProductService
    {
        private readonly IExchangeProductRepository _exchangeProductRepository;
        public ExchangeProductService(IExchangeProductRepository exchangeProductRepository)
        {
            _exchangeProductRepository = exchangeProductRepository;
        }

        public ResponseData InsertRecord(Core.Models.Request.ExchangeProduct exchangeProduct)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _exchangeProductRepository.InsertRecord(exchangeProduct);
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

        public ExchangeProductResponse GetRecords()  
        {
            ExchangeProductResponse responseData = new ExchangeProductResponse();

            try
            {
                responseData.Data =  _exchangeProductRepository.GetRecords();
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

        public ExchangeProductResponse GetRecord(int id)
        {
            ExchangeProductResponse responseData = new ExchangeProductResponse();

            try
            {
                responseData.Data = _exchangeProductRepository.GetRecord(id);
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

    }
}
