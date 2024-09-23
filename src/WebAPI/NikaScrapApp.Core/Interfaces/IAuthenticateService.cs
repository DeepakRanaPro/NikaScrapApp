using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.Security.Claims;

namespace NikaScrapApp.Core.Interfaces
{
    public interface IAuthenticateService
    {
        JWTTokenDetailResponse GenrateToken(UserCredential userCredential);
        ClaimsIdentity GenrateClaims(UserCredential userCredential);
        ResponseData Login(Login login);
        UserResponse VerifyOTP(OTP otpDTO);
    }
}