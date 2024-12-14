using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IContactUsService
    {
        ContactUsResponse GetContact(int id);
        ContactUsResponse AddContactUs(DigitalKabadiApp.Core.Models.Request. ContactUs contactUs);
    }
}
