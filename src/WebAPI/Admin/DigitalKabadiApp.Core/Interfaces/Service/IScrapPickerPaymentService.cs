using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IScrapPickerPaymentService
    {
        ScrapPickerPaymentAccountDetail PickerPaymentAccountDetail(int ScrapPickerId);
        //PickerPaymentTransactions PickerPaymentTransactions(int ScrapPickerId, int PickupId);
        //Core.Models.Response.ScrapPickerPaymentAccount ScrapPickerPaymentAccounts(int ScrapPickerId);
        Core.Models.Response.TbScrapPickerPaymentTransactions ScrapPickerPaymentTransaction(int id);

    }
}