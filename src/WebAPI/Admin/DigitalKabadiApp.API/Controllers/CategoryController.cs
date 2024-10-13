using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServics;
        public CategoryController(ICategoryService categoryServics)
        {
            _categoryServics = categoryServics;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            CategoryResponse result = new CategoryResponse();
            result = _categoryServics.GetCategory(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult InsertCategory(Category category)
        {
            CategoryResponse result = new CategoryResponse();
            result = _categoryServics.InsertCategory(category);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult DeleteCategory([FromQuery] int id)
        {
            CategoryResponse result = new CategoryResponse();
            result = _categoryServics.DeleteCategory(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult ModifyCategory(Category category)
        {
            CategoryResponse result = new CategoryResponse();
            result = _categoryServics.ModifyCategory(category);
            return Ok(result);
        }

    }
}
