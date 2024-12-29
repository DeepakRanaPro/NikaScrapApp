using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IScrapPickerPaymentRepository
    {
        List<ScrapPickerPaymentAccountDetails> PickerPaymentAccountDetail(int ScrapPickerId);
        //List<Core.Models.Request.PickerPaymentTransaction> PickerPaymentTransactions(int ScrapPickerId, int PickupId);
        //List<Core.Models.Response.ScrapPickerPaymentAccounts> PickerPaymentAccounts(int ScrapPickerId);
        List<Core.Models.Response.TbScrapPickerPaymentTransaction> ScrapPickerPaymentTransaction(int id);


    }
}