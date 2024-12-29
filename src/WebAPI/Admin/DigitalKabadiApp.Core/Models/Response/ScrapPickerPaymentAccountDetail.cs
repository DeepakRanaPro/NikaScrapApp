using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class ScrapPickerPaymentAccountDetail : Response
    {
        public List<ScrapPickerPaymentAccountDetails> Data { get; set; }
    }
        public class ScrapPickerPaymentAccountDetails
    {
       

        public int ScrapPickerId { get; set; }
        public string ScrapPickerName { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime LastTransactionOn { get; set; }

    }
}
