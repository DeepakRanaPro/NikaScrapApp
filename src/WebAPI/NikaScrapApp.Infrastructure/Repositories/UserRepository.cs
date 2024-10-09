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

        public NikaScrapApp.Core.Models.Response.UserAddress AddAddress(NikaScrapApp.Core.Models.Request.UserAddress addUesrAddress, int languageId)
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
                parameters.Add("@AlternateMobileNumber", addUesrAddress.AlternateMobileNumber);
                parameters.Add("@LocationTypeId", addUesrAddress.LocationTypeId);
                parameters.Add("@languageId", languageId);
                parameters.Add("@State", addUesrAddress.State);
                parameters.Add("@City", addUesrAddress.City);
                string query = $" Set @IsDefault=0  " +
                               $" if not exists ( Select * from TbUserAddress where UserId=@UserId and IsDelete=0) " +
                                  $"Begin " +
                                           $"Set @IsDefault=1 " +
                                  " End " +
                          $" Insert into TbUserAddress(UserId,Pincode,LocationType,Landmark,FullAddress,IsDefault,AlternateMobileNumber,LocationTypeId,State,City) values(@UserId,@Pincode,@LocationType,@Landmark,@FullAddress,@IsDefault,@AlternateMobileNumber,@LocationTypeId,@State,@City) " +
                         " select TbUserAddress.Id,UserId,Pincode,LocationTypeDetails.Name as LocationType,Landmark,FullAddress,AlternateMobileNumber,LocationTypeId,IsDefault,IsDelete,CreatedOn,State,City from TbUserAddress " +
                         " Join LocationTypeDetails on LocationTypeDetails.Id=TbUserAddress.LocationTypeId and LocationTypeDetails.LanguageId=@languageId and TbUserAddress.id=IDENT_CURRENT('TbUserAddress')";

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
                result = sqlConnection.Execute($"Update TbUserAddress Set IsDelete=1,IsDefault=0 where id=@id ", param: parameters) > 0;
            }
            return result;
        }

        public List<NikaScrapApp.Core.Models.Response.UserAddress> GetAddress(int userId, int languageId)
        {
            List<NikaScrapApp.Core.Models.Response.UserAddress> result = new List<NikaScrapApp.Core.Models.Response.UserAddress>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string query = $" select TbUserAddress.Id,UserId,Pincode,LocationTypeDetails.Name as LocationType,Landmark,FullAddress,AlternateMobileNumber,LocationTypeId,IsDefault,IsDelete,CreatedOn,State,City from TbUserAddress  " +
                               $" Join LocationTypeDetails on LocationTypeDetails.Id=TbUserAddress.LocationTypeId and LocationTypeDetails.LanguageId=@LanguageId " +
                               $" Where TbUserAddress.UserId=@UserId ";

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@LanguageId", languageId);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>(query, param: parameters).ToList();
            }

            return result;
        }

        public  NikaScrapApp.Core.Models.Response.UserAddress GetAddressByPickupId(int PickupId, int languageId)
        {
            NikaScrapApp.Core.Models.Response.UserAddress result = new  NikaScrapApp.Core.Models.Response.UserAddress();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string query = $" select TbUserAddress.Id,UserId,Pincode,LocationTypeDetails.Name as LocationType,Landmark,FullAddress,AlternateMobileNumber,LocationTypeId,IsDefault,IsDelete,CreatedOn,State,City from TbUserAddress  " +
                               $" Join LocationTypeDetails on LocationTypeDetails.Id=TbUserAddress.LocationTypeId and LocationTypeDetails.LanguageId=@LanguageId " +
                               $" Where TbUserAddress.Id = (Select top 1 AddressId from TbPickups Where TbPickups.Id=@PickupId) ";

                var parameters = new DynamicParameters();
                parameters.Add("@LanguageId", languageId);
                parameters.Add("@PickupId", PickupId);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>(query, param: parameters).FirstOrDefault();
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
                parameters.Add("@IsDefault", userAddress.IsDefault);
                parameters.Add("@AlternateMobileNumber", userAddress.AlternateMobileNumber);
                parameters.Add("@LocationTypeId", userAddress.LocationTypeId);
                parameters.Add("@State", userAddress.State);
                parameters.Add("@City", userAddress.City);
                parameters.Add("@Id", userAddress.Id);

                result = sqlConnection.Execute($"Update TbUserAddress set State=@State,City=@City,Pincode=@Pincode,LocationTypeId=@LocationTypeId, Landmark=@Landmark,FullAddress=@FullAddress,AlternateMobileNumber=@AlternateMobileNumber where Id=@Id", param: parameters, commandType: CommandType.Text) > 0;

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

        public NikaScrapApp.Core.Models.Response.UserAddress GetAddressDetails(int Addressid) 
        {
            NikaScrapApp.Core.Models.Response.UserAddress result = new NikaScrapApp.Core.Models.Response.UserAddress();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Addressid", Addressid);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.UserAddress>($"select * from TbUserAddress Where Id=@Addressid", param: parameters).FirstOrDefault();
            }

            return result;
        }

    }
}

