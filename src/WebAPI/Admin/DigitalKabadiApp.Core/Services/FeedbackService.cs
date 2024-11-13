using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DigitalKabadiApp.Core.Services
{
    public  class FeedbackService :iFeedbackService

    {
        
        private readonly iFeedbackRepositary _FeedbackRepositary;
        public FeedbackService(iFeedbackRepositary FeedbackRepositary)
        {
            _FeedbackRepositary = FeedbackRepositary;
        }
        public FeedbackResponse GetFeedback(Models.Request.Feedback feedback)
        {
            FeedbackResponse responseData = new FeedbackResponse();

            try
            {
               _FeedbackRepositary.GetFeedback( feedback);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = true;
                    responseData.Message = "No record exists!";
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
        public FeedbackResponse InsertFeedback(Core.Models.Request.Feedback feedback)
        {
            FeedbackResponse responseData = new FeedbackResponse();

            try
            {
                bool result = _FeedbackRepositary.Insertfeedback(feedback);
                if (!result)
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
