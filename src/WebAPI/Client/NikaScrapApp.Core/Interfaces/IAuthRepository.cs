
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces  
{
    public interface IAuthRepository
    {
        public UserCredential UserDetailById(UserCredential userCredential);
        UserCredential VerifyCredential(UserCredential userCredential);
        string Login(Login login);
        Users? VerifyOTP(OTP otpDTO);
    }
}