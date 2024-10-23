using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataRepository _masterDataRepository;
        public MasterDataController(IMasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            MasterDataResponse result = new MasterDataResponse();
            result.Data = _masterDataRepository.GetMasterData();
            return Ok(result);
        }
    }
}
