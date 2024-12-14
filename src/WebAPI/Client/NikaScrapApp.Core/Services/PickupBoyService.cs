using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Core.Services
{
    public class PickupBoyService : IPickupBoyService
    {
        private readonly IPickupBoyRepository _pickupBoyRepository;
        public PickupBoyService(IPickupBoyRepository pickupBoyRepository)
        {
            _pickupBoyRepository = _pickupBoyRepository;
        }

        public ResponseData InsertPickupProduct(int PickupId, List<PickupProducts> products)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _pickupBoyRepository.InsertPickupProduct(PickupId, products);

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

        public ResponseData UpdateScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _pickupBoyRepository.UpdateScrapPickup(scrapPickupByWastePicker);

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
