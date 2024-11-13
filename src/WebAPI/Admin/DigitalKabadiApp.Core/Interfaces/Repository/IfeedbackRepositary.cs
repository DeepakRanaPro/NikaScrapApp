using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IfeedbackRepositary
    {
        List<Models.Response.Feedback> GetFeedback(Models.Response.Feedback feedback);
        bool Insertfeedback(Core.Models.Response.Feedback feedback);
    }
}
