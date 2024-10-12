using Microsoft.IdentityModel.Tokens;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NikaScrapApp.Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        string _secretKey;
        private readonly IAuthRepository _authRepository;
        public AuthenticateService(string secretKey, IAuthRepository authRepository)
        {
            _secretKey = secretKey;
            _authRepository = authRepository;
        }

        public JWTTokenDetailResponse GenrateToken(UserCredential userCredential)
        {
            var jwtTokenDetail = new JWTTokenDetailResponse() { IsSuccess = false, Message = "Invalid Credentials!", ResponseCode = 401 };
            var userInfo = _authRepository.VerifyCredential(userCredential);

            if (userCredential == null || userInfo == null)
            {
                return jwtTokenDetail;
            }

            JwtSecurityTokenHandler jwtHandler;
            SecurityToken token;
            _GenrateToken(userInfo, out jwtHandler, out token);
            return new JWTTokenDetailResponse
            {
                Data = new JWTTokenDetails()
                {
                    AccessToken = jwtHandler.WriteToken(token),
                    TokenType = "bearer",
                    ExpiresIn = 780,
                },
                IsSuccess = true,
                Message = "Success"
            };
        }

        private void _GenrateToken(UserCredential userInfo, out JwtSecurityTokenHandler jwtHandler, out SecurityToken token)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            jwtHandler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = GenrateClaims(userInfo),
                Expires = DateTime.UtcNow.AddHours(780),
                SigningCredentials = credentials,
            };

            token = jwtHandler.CreateToken(tokenDescriptor);
        }

        public ClaimsIdentity GenrateClaims(UserCredential userCredential)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, userCredential.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, userCredential.Roles));
            claims.AddClaim(new Claim(ClaimTypes.MobilePhone, userCredential.MobileNo));
            claims.AddClaim(new Claim("ObjectId", userCredential.ObjectId));
            claims.AddClaim(new Claim("Id", userCredential.Id.ToString()));

            return claims;
        }

        public ResponseData Login(Login login)
        {
            ResponseData responseData = new ResponseData();

            try
            {
                responseData.Data = _authRepository.Login(login);

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

        public UserResponse VerifyOTP(OTP otpDTO)
        {
            UserResponse userResponse = new UserResponse();

            try
            {
                userResponse.Data = _authRepository.VerifyOTP(otpDTO);
                 
                if (userResponse.Data == null)
                {
                    userResponse.IsSuccess = false;
                    userResponse.Message = "Fail";
                    userResponse.ResponseCode = 900;
                }
                else
                {
                    JwtSecurityTokenHandler jwtHandler;
                    SecurityToken token;

                    var userInfo = _authRepository.VerifyCredential(new UserCredential() {MobileNo= "9992165828", Password = "Admin@123" });
                    _GenrateToken(userInfo, out jwtHandler, out token);

                    userResponse.Data.JWTTokenDetail = new JWTTokenDetails()
                    {
                        AccessToken = jwtHandler.WriteToken(token),
                        TokenType = "bearer",
                        ExpiresIn = 780,
                    }; 
                }
            }
            catch (Exception ex)
            {
                userResponse.IsSuccess = false;
                userResponse.Message = $"Exception: {ex.Message}";
                userResponse.ResponseCode = 999;
            }

            return userResponse;
        }
    }
}
