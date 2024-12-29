

using DigitalKabadiApp.Core.Models.Request;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class PickerPaymentTransactions :Response
    {
        public List<PickerPaymentTransaction> Data { get; set; }
        
    }
}
