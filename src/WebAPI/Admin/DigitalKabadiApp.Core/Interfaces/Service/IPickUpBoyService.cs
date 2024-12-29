using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IPickUpBoyService
    {
        Core.Models.Response.PickupHistory GetHistory(int id);
        Core.Models.Response.PickupResponse Get(int id);
        Core.Models.Response.PickupDetail post(Products products);
        Core.Models.Response.ScrapPickerPaymentResponce PaymentTransactions(Core.Models.Request.ScrapPickerPaymentTransactions scrapPickerPaymentTransactions);
        DigitalKabadiApp.Core.Models.Response.ResponseData ExchangeProduct(NikaScrapApp.Core.Models.Request.ScrapPickerExchangeProducts scrapPickerExchangeProducts);
    }
}