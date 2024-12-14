using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IPickupBoyRepository
    {
        List<Pickup> GetHistory(int id);
        List<UpApprovedPikup> Get(int id);
        bool post(Products products);
        
    }
}