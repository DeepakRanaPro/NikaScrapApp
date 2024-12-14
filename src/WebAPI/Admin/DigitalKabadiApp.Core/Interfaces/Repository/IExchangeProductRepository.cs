using DigitalKabadiApp.Core.Models.Request;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IExchangeProductRepository
    {
        bool InsertRecord(ExchangeProduct exchangeProduct);
        List<Core.Models.Response.ExchangeProduct> GetRecords();
        List<Core.Models.Response.ExchangeProduct> GetRecord(int id);
        bool Edit(Core.Models.Request.ExchangeProduct exchangeProduct);
    }
}