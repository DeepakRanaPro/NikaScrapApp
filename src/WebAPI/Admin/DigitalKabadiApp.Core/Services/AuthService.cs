using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Interfaces.Service;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DigitalKabadiApp.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        { 
            _authRepository = authRepository;
        }

        public LoginResponse Login(Login login)
        {
            LoginResponse responseData = new LoginResponse();

            try
            {
                var data = _authRepository.Login(login);

                if (data == null)
                {
                    return new LoginResponse
                    {
                        IsSuccess = false,
                        Message = "Fail",
                        ResponseCode = 900
                    };
                }

                responseData.Data = data; 
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = false;
                responseData.Message = $"Exception: {ex.Message}";
                responseData.ResponseCode = 999;
            }
            return responseData;
        }
    }
}
