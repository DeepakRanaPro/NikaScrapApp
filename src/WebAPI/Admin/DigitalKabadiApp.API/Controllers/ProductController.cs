using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServics;
        public ProductController(IProductService productServics)
        {
            _productServics = productServics;  
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            ProductResponse result = new ProductResponse();
            result = _productServics.GetProduct(id);
            return Ok(result);
        }
       
        [HttpDelete]
        public ActionResult DeleteProduct([FromQuery] int id)
        {
            ResponseData result = new ResponseData();
            result = _productServics.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult ModifyProduct(Core.Models.Request.Product product) 
        {
            ResponseData result = new ResponseData();
            result = _productServics.ModifyProduct(product); 
            return Ok(result);
        } 
    }
}
