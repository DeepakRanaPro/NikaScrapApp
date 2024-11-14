using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IExchangeProductService
    {
        ResponseData InsertRecord(Core.Models.Request.ExchangeProduct exchangeProduct);
        ExchangeProductResponse GetRecords();
        ExchangeProductResponse GetRecord(int id);
    }
}