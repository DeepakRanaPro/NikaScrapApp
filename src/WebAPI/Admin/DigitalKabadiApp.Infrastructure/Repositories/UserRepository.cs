using Dapper;
using DigitalKabadiApp.Core.Models.Request;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<UserDetail> GetUser(int id)
        {
            List<UserDetail> result = new List<UserDetail>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserID", id);
                result = sqlconnection.Query<UserDetail>($"  select TbUser.Id , TbUser.Name ,MobileNumber ,EmailId,  Password,  TbUserAddress.UserId ,State,City ,MstRole.Id from TbUserjoin TbUserAddress on TbUser.Id = TbUserAddress.Idjoin MstRole on TbUser.RoleId = MstRole.Id ", param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }
    }
}
