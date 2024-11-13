using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface iFeedbackRepositary
    {
        List<Core.Models.Response.Feedback> GetFeedback(Core.Models.Request.Feedback feedback);
        bool Insertfeedback(Core.Models.Request.Feedback feedback);
    }
}
