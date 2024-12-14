using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
         private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int id)
        {
            ContactUsResponse result = new ContactUsResponse();
            result = _contactUsService.GetContact(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult AddContactUs(Core.Models.Request.ContactUs contactUs)
        {
            ContactUsResponse result = new ContactUsResponse();
            result = _contactUsService.AddContactUs(contactUs);
            return Ok(result);
        }
    }
}

