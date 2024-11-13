using Dapper;
using DigitalKabadiApp.Core.Models.Request;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<UserDetail> GetUser(int id )
        {
            List<UserDetail> result = new List<UserDetail>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                string query =  $"select TbUser.Id , TbUser.Name ,MobileNumber ,EmailId,  Password,  TbUserAddress.UserId ,State,City ,MstRole.Id from TbUser" +
                               $"join TbUserAddress on TbUser.Id = TbUserAddress.Id" +
                               $"join MstRole on TbUser.RoleId = MstRole.Id  where (@Id = 0 or TbUser.id = @Id) and (@RoleId = 0 or TbUser.RoleId = @RoleId) and (@State = 0 or TbUserAddress.state = @State) and (@City=0 or TbUserAddress.City = @City)";
                              
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
               
                result = sqlconnection.Query<UserDetail>($"query ", param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }
    }
}
