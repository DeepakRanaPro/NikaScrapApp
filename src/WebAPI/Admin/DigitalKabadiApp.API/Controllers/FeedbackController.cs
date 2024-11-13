using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly iFeedbackService _FeedbackService;
        public FeedbackController(iFeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
        }

        [HttpPost]
        public ActionResult Get(DigitalKabadiApp.Core.Models.Request.Feedback feedback)
        {
            FeedbackResponse result = new FeedbackResponse();
            result = _FeedbackService.GetFeedback(feedback);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Insert(Core.Models.Request.Feedback feedback)
        {
            FeedbackResponse result = new FeedbackResponse();
            result = _FeedbackService.InsertFeedback(feedback);
            return Ok(result);
        }
    }
}
