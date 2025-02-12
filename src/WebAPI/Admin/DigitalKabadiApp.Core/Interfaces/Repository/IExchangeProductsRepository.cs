using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IExchangeProductsRepository
    {
        List<ExchangeProductAccount> GetPickupBoyList(int id);
    }
}