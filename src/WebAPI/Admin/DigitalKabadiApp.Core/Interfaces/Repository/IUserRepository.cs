using DigitalKabadiApp.Core.Models.Request;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        List<UserDetail> GetUser(int id);
    }
}