using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IUserService
    {
        UserDetail GetProduct(int id);
    }
}