using Microsoft.IdentityModel.Tokens;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace NikaScrapApplication.API.Services
{
    public class AuthService
    {
        string _secretKey;
        public AuthService(string secretKey) {
            _secretKey = secretKey;
        }
        public JWTTokenDetailResponse GenrateToken(UserCredential userCredential)
        {
            var jwtTokenDetail = new JWTTokenDetailResponse() { IsSuccess = false, Message= "Invalid Credentials!", ResponseCode=401 };
            var userInfo = VerifyCredential(userCredential);

            if(userCredential==null)
            {
                return jwtTokenDetail;
            }

            var key = Encoding.ASCII.GetBytes(_secretKey);
            var jwtHandler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                 
                Subject=GenrateClaims(userInfo),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
             };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return new JWTTokenDetailResponse
            {
                 Data = new JWTTokenDetails()
                   {
                       AccessToken = jwtHandler.WriteToken(token),
                       TokenType = "bearer",
                       ExpiresIn = 2,
                   },
                IsSuccess = true,
                Message = "Success"
            };
        }
        public static ClaimsIdentity GenrateClaims(UserCredential userCredential)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, userCredential.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, userCredential.Roles));
            claims.AddClaim(new Claim(ClaimTypes.MobilePhone, userCredential.MobileNo));
            claims.AddClaim(new Claim("ObjectId", userCredential.ObjectId));
            claims.AddClaim(new Claim("Id", userCredential.Id.ToString()));

            return claims;  
        }
        public UserCredential VerifyCredential(UserCredential userCredential)
        {
           if(userCredential.MobileNo=="9992165828" && userCredential.Password=="123456")
            {
                return new UserCredential() 
                {
                  Id=1,
                  Password = userCredential.Password,
                  MobileNo = userCredential.MobileNo,
                  ObjectId = new Guid().ToString(),
                  Roles = "Admin",
                  UserName = "Deepak Rana"
                };
            }
            else if (userCredential.MobileNo == "9017700043" && userCredential.Password == "123456")
            {
                return new UserCredential()
                {
                    Id = 2,
                    Password = userCredential.Password,
                    MobileNo = userCredential.MobileNo,
                    ObjectId = new Guid().ToString(),
                    Roles = "User",
                    UserName = "Sourav Rana"
                };
            }

            return null;
        }
    }
}
