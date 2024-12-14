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
    public class ContactUsService: IContactUsService
    {
        private readonly IContactUsRepositary _contactUsRepositary;
        public ContactUsService(IContactUsRepositary contactUsRepositary)
        {
            _contactUsRepositary = contactUsRepositary;
        }
        public ContactUsResponse GetContact(int id)
        {
            ContactUsResponse responseData = new ContactUsResponse();

            try
            {
                _contactUsRepositary.GetContact(id);
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
        public ContactUsResponse AddContactUs(DigitalKabadiApp.Core.Models.Request.ContactUs contactUs)
        {
            ContactUsResponse responseData = new ContactUsResponse();

            try
            {
               bool result = _contactUsRepositary.AddContactUs(contactUs);
                if (!result)
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
    }
    
}
