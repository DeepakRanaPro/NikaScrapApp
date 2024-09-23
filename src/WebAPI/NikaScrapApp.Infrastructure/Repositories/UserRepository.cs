using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using System.Data;
using NikaScrapApp.Core.Models.Response;
using NikaScrapApp.Core.Models.Request;
using System.Collections.Generic;


namespace NikaScrapApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NikaScrapApp.Core.Models.Response.UserAddress AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress)
        {
            NikaScrapApp.Core.Models.Response.UserAddress result = new NikaScrapApp.Core.Models.Response.UserAddress();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", addUesrAddress.UserId);
                parameters.Add("@Pincode", addUesrAddress.Pincode);
                parameters.Add("@LocationType", addUesrAddress.LocationType);
                parameters.Add("@Landmark", addUesrAddress.Landmark);
                parameters.Add("@FullAddress", addUesrAddress.FullAddress);
                parameters.Add("@IsDefault", addUesrAddress.IsDefault);

                string query = $" if not exists ( Select * from TbUserAddress where UserId=@UserId) " +
                                  $"Begin " +
                                           $"Set @IsDefault=1 " +
                                  " End " +
                          $" Insert into TbUserAddress(UserId,Pincode,LocationType,Landmark,FullAddress,IsDefault) values(@UserId,@Pincode,@LocationType,@Landmark,@FullAddress,@IsDefault) " +
                         " select * from TbUserAddress Where id=IDENT_CURRENT('TbUserAddress')";

                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>(query, param: parameters, commandType: CommandType.Text).FirstOrDefault();
            }
            return result;
        }

        public bool DeleteAddress(int id)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                result = sqlConnection.Execute($"Delete TbUserAddress where id=@id ", param: parameters) > 0;
            }
            return result;
        }

        public List<NikaScrapApp.Core.Models.Response.UserAddress> GetAddress(int userId)
        {
            List<NikaScrapApp.Core.Models.Response.UserAddress> result = new List<NikaScrapApp.Core.Models.Response.UserAddress>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>($"select * from TbUserAddress Where UserId=@UserId ", param: parameters).ToList();
            }

            return result;
        }
        public bool SetDefaultAddress(int id, int Userid)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                string query = $"Update UserAddress Set UserAddress.IsDefault=0 from TbUserAddress UserAddress Where UserAddress.UserId=@UserId; " +
                               "Update UserAddress Set UserAddress.IsDefault=1 from TbUserAddress UserAddress Where UserAddress.Id=@Id;";

                var parameters = new DynamicParameters();
                parameters.Add("@Userid", Userid);
                parameters.Add("@Id", id);
                result = sqlConnection.Execute(query, param: parameters, commandType: CommandType.Text) > 0;
                return result;
            }

        }

        public bool UpdateUserAddress(NikaScrapApp.Core.Models.Request.UserAddress userAddress)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Pincode", userAddress.Pincode);
                parameters.Add("@LocationType", userAddress.LocationType);
                parameters.Add("@Landmark", userAddress.Landmark);
                parameters.Add("@FullAddress", userAddress.FullAddress); 
                parameters.Add("@Id", userAddress.Id);

                result = sqlConnection.Execute($"Update TbUserAddress set Pincode=@Pincode,LocationType=@LocationType, Landmark=@Landmark,FullAddress=@FullAddress where Id=@Id", param: parameters, commandType: CommandType.Text) > 0;

                return result;
            }

        }

        public bool UserProfileUpdate(UserProfileUpdate userProfileUpdate)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Userid", userProfileUpdate.Userid);
                parameters.Add("@Name", userProfileUpdate.Name);
                parameters.Add("@EmailId", userProfileUpdate.EmailId);

                result = sqlConnection.Execute($"Update TbUser set Name=@Name, EmailId=@EmailId where Id=@Userid", param: parameters, commandType: CommandType.Text) > 0;

                return result;
            }
        }

        public bool SetRole(SetUserRoleRequest setUserRoleRequest)
        {
            bool result = false;

            using (var con = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                result = con.Execute($"Update TbUser Set RoleId={setUserRoleRequest.RoleId} where Id={setUserRoleRequest.UserId}", commandType: CommandType.Text) > 0;
            }
            return result;
        }

        public  NikaScrapApp.Core.Models.Response.UserAddress  GetDefaultAddress(int userId) 
        {
            NikaScrapApp.Core.Models.Response.UserAddress  result = new  NikaScrapApp.Core.Models.Response.UserAddress();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>($"select * from TbUserAddress Where UserId=@UserId and IsDefault=1", param: parameters).FirstOrDefault();
            }

            return result;
        }
    }
}

