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
    public class PickupService : IPickupService
    {
        private readonly IPickupRepository _pickupRepository;
        public PickupService(IPickupRepository pickupRepository)
        {
            _pickupRepository = pickupRepository;
        }

        public PickupRecordsResponse PickupRecords(PickupReport pickupReport)
        {
            PickupRecordsResponse responseData = new PickupRecordsResponse();

            try
            {
                responseData.Data = _pickupRepository.GetPickupRecords(pickupReport);
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
