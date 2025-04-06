using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DismantleController : ControllerBase
    {
        private readonly IDismantleService _dismantle;

        public DismantleController(IDismantleService dismantle)
        {
            _dismantle = dismantle;
        }

        [HttpPost]
        public IActionResult DismantleProduct(DismantleProduct dismantleProduct)
        {
            ResponseData result = new ResponseData();

            result = _dismantle.DismantleProduct(dismantleProduct);

            return Ok(result);
        }
    }
}
