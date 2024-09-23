using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IUserRepository
    {
        List<NikaScrapApp.Core.Models.Response.UserAddress> GetAddress(int userId);
        NikaScrapApp.Core.Models.Response.UserAddress AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress);
        bool DeleteAddress(int id);
        bool SetDefaultAddress(int id, int UserId);
        bool UpdateUserAddress(NikaScrapApp.Core.Models.Request.UserAddress userAddress);
        bool UserProfileUpdate(UserProfileUpdate userProfileUpdate);

        bool SetRole(NikaScrapApp.Core.Models.Request.SetUserRoleRequest setUserRoleRequest);

        NikaScrapApp.Core.Models.Response.UserAddress GetDefaultAddress(int userId);
    }
}
