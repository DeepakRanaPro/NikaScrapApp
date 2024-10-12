
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;

namespace NikaScrapApp.Core.Interfaces  
{
    public interface IAuthRepository
    {
        UserCredential VerifyCredential(UserCredential userCredential);
        bool Login(Login login);
        Users? VerifyOTP(OTP otpDTO);
    }
}