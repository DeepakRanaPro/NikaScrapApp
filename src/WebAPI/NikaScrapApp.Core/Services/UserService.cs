using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
 
namespace NikaScrapApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserAddressResponse AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress, int languageId)
        {
            UserAddressResponse responseData = new UserAddressResponse();
            try
            {
                NikaScrapApp.Core.Models.Response.UserAddress result = _userRepository.AddAddress(addUesrAddress, languageId);
                responseData.Data.Add(result);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
        public UserAddressResponse GetAddress(int userId,int languageId)
        {
            UserAddressResponse responseData = new UserAddressResponse();
            try
            {
                responseData.Data = _userRepository.GetAddress(userId, languageId);

                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
        public UserAddressResponse DeleteAddress(int id)
        {
            UserAddressResponse responseData = new UserAddressResponse();
            try
            {
                bool result = _userRepository.DeleteAddress(id);
                if (!result)
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

        public UserAddressResponse SetDefaultAddress(int Id, int UserId)
        {
            UserAddressResponse responsedata = new UserAddressResponse();
            try
            {
                bool result = _userRepository.SetDefaultAddress(Id, UserId);
                {
                    if (!result)
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;
                    }
                }
            }
            catch (Exception ex)
            {
                responsedata.IsSuccess = false;
                responsedata.Message = $"exception:{ex.Message}";
                responsedata.ResponseCode = 999;
            }
            return responsedata;
        }
        public UserAddressResponse UpdateUserAddress(NikaScrapApp.Core.Models.Request.UserAddress userAddress)
        {
            UserAddressResponse responsedata = new UserAddressResponse();
            try
            {
                bool result = _userRepository.UpdateUserAddress(userAddress);
                {
                    if (!result)
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;
                    }
                }
            }
            catch (Exception ex)
            {
                responsedata.IsSuccess = false;
                responsedata.Message = $"exception:{ex.Message}";
                responsedata.ResponseCode = 999;
            }
            return responsedata;
        }
        public UserProfileUpdateResponse UserProfileUpdate(NikaScrapApp.Core.Models.Request.UserProfileUpdate userProfileUpdate)
        {
            UserProfileUpdateResponse responsedata = new UserProfileUpdateResponse();
            try
            {
                bool result = _userRepository.UserProfileUpdate(userProfileUpdate);
                {
                    if (!result)
                    {
                        responsedata.IsSuccess = false;
                        responsedata.Message = "fail";
                        responsedata.ResponseCode = 999;

                    }
                }
            }
            catch (Exception ex)
            {
                responsedata.IsSuccess = false;
                responsedata.Message = $"exception:{ex.Message}";
                responsedata.ResponseCode = 999;
            }
            return responsedata;
        }

        public ResponseData SetRole(SetUserRoleRequest setUserRoleRequest)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _userRepository.SetRole(setUserRoleRequest);

                if (!responseData.Data)
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 900;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

        public UserAddressResponse GetDefaultAddress(int userId, int languageId) 
        {
            UserAddressResponse responseData = new UserAddressResponse();
            try
            {
                responseData.Data = _userRepository.GetAddress(userId, languageId);
                if (!responseData.Data.Any())
                {
                    responseData.IsSuccess = false;
                    responseData.Message = "Fail";
                    responseData.ResponseCode = 999;
                }
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception:{ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }

    }
}

