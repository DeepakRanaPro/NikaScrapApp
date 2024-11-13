using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.API.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IfeedbackService _FeedbackService;
        public FeedbackController(IfeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
        }

        [HttpGet]
        public ActionResult Get(Feedback feedback)
        {
            FeedbackResponse result = new FeedbackResponse();
            result = _FeedbackService.GetFeedback(feedback);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Insert(Feedback feedback)
        {
            FeedbackResponse result = new FeedbackResponse();
            result = _FeedbackService.GetFeedback(feedback);
            return Ok(result);
        }
    }
}
