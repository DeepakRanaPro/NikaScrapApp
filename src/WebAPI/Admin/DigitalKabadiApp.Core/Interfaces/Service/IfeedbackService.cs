using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface iFeedbackService
    {
        FeedbackResponse GetFeedback(Models.Request.Feedback feedback);
        FeedbackResponse InsertFeedback(Core.Models.Request.Feedback feedback);
    }
}
