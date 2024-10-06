using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApplication.API.Services;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService; 

        public MasterDataController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        [HttpPost, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult GetRoles(Request request) 
        {
            MasterDataResponse responseData = new MasterDataResponse();
 
            responseData = _masterDataService.GetRoles(request);
             
                return Ok(responseData);
           
        }

        [HttpPost, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult GetLocationTypes(Request request) 
        {
            MasterDataResponse responseData = new MasterDataResponse();

            responseData = _masterDataService.GetLocationTypes(request); 

            return Ok(responseData);

        }

        [HttpPost, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")]
        public IActionResult GetRateList(NikaScrapApp.Core.Models.Request.RateList rateListRequest) 
        {
            RateListResponse responseData = new RateListResponse();

            responseData = _masterDataService.GetRateList(rateListRequest);
             
            return Ok(responseData);  
        }

        [HttpGet, Authorize(Roles = "Admin,SubAdmin,Household,Organisation,Business Owner")] 
        public IActionResult GetPincodeDetails(string pincode)
        {
            PincodeDetailsResponse responseData = new PincodeDetailsResponse();

            responseData = _masterDataService.GetPincodeDetails(pincode);

            return Ok(responseData);

        }
    }
}
