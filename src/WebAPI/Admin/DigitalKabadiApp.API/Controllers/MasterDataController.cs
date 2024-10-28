using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    { 
        private readonly IMasterDataService _masterDataService;
        public MasterDataController(IMasterDataService masterDataService)
        { 
            _masterDataService= masterDataService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            MasterDataResponse result = new MasterDataResponse();
            result = _masterDataService.GetMasterData();
            return Ok(result);
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
