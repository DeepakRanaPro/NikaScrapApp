﻿using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IUserService
    {
        UserAddressResponse AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress, int languageId);
        UserAddressResponse GetAddress(int userid, int languageId);
        UserAddressResponse DeleteAddress(int id);
        UserAddressResponse SetDefaultAddress(int id, int UserId);
        UserAddressResponse UpdateUserAddress(NikaScrapApp.Core.Models.Request.UserAddress userAddress);
        UserProfileUpdateResponse UserProfileUpdate(NikaScrapApp.Core.Models.Request.UserProfileUpdate userProfileUpdate);
        ResponseData SetRole(SetUserRoleRequest setUserRoleRequest);
    }
}
