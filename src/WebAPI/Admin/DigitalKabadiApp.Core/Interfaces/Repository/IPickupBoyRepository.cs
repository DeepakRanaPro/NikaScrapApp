using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IPickupBoyRepository
    {
        List<Pickup> GetHistory(int id);
        List<UpApprovedPikup> Get(int id);
        bool post(Products products);
        bool PaymentTransactions(Core.Models.Request.ScrapPickerPaymentTransactions scrapPickerPaymentTransactions);
        bool ExchangeProduct(NikaScrapApp.Core.Models.Request.ScrapPickerExchangeProducts scrapPicker);
        bool PickupBoyReport(PickupBoyReport report);


    }
}