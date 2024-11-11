using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly string _connectionString;
        public AuthRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UsersDetail? Login(Login login)
        {
            UsersDetail? result = null;  

            using (var con = new SqlConnection(_connectionString))
            {

                string query = $"Select TbUser.Id,TbUser.Name,RoleId,MstRole.Name as Role,EmailId,MobileNumber from [dbo].TbUser " +
                               $" Join [dbo].MstRole on MstRole.Id = TbUser.RoleId" +
                               $" Where EmailId=@EmailId and Password=@Password";

                var parameters = new DynamicParameters();
                parameters.Add("EmailId", login.EmailId);
                parameters.Add("Password", login.Password);

                result = con.Query<UsersDetail>( query, parameters, commandType: CommandType.Text).FirstOrDefault();
            }
            return result;
        }
    }
}
