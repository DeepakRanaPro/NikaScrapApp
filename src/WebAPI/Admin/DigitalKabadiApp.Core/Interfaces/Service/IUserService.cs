using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IUserService
    {
        UserResponse GetUser(int id);
    }
}