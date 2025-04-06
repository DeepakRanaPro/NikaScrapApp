using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Services
{
    public class OrderPickupService : IOrderPickupService
    {
        private readonly IOrderPickupRepository _orderPickupRepository;
        public OrderPickupService(IOrderPickupRepository orderPickupRepository)
        {
            _orderPickupRepository = orderPickupRepository;
        }

        public ResponseData ProcessOrderPickup(OrderPickup orderPickup)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _orderPickupRepository.ProcessOrderPickup(orderPickup);

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
    }
}
