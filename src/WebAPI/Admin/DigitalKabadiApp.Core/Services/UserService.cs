using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Response;
using DigitalKabadiApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Services
{
    public class UserService  //: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //public User GetProduct(int id)
        //{
        //    UserResponse responseData = new UserResponse();

        //    try
        //    {
        //        responseData.Data = _userRepository.GetUser(id);
        //        if (!responseData.Data.Any())
        //        {
        //            responseData.IsSuccess = false;
        //            responseData.Message = "Fail";
        //            responseData.ResponseCode = 999;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData.IsSuccess = false;
        //        responseData.Message = $"Exception:{ex.Message}";
        //        responseData.ResponseCode = 999;
        //    }
        //    return responseData;
        //}
    }
}
