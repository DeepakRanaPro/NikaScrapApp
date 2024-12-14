using DigitalKabadiApp.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IContactUsRepositary
    {
        List<ContactUs> GetContact(int id);

        bool AddContactUs(Core.Models.Request.ContactUs contactUs);
    }
}
