using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigitalKabadiApp.Core.Services
{
    public  class FeedbackService :IfeedbackService

    {
        
        private readonly IfeedbackRepositary _FeedbackRepositary;
        public FeedbackService(IfeedbackRepositary FeedbackRepositary)
        {
            _FeedbackRepositary = FeedbackRepositary;
        }
        public FeedbackResponse GetFeedback(Feedback feedback)
        {
            FeedbackResponse responseData = new FeedbackResponse();

            try
            {
                responseData.Data =_FeedbackRepositary.GetFeedback(feedback);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
        public FeedbackResponse InsertFeedback(Feedback feedback)
        {
            FeedbackResponse responseData = new FeedbackResponse();

            try
            {
                responseData.Data = _FeedbackRepositary.GetFeedback(feedback);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

    }
}
