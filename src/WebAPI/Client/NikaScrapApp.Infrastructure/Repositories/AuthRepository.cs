﻿using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.Data;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string _connectionString;
        public AuthRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
      
        public UserCredential VerifyCredential(UserCredential userCredential) 
        {
            UserCredential result = new UserCredential();

            using (var con = new SqlConnection(_connectionString))
            {  
                result = con.Query<UserCredential>($"Select TbUser.Id,TbUser.Name as UserName,MobileNumber as MobileNo,MstRole.Name as Roles  From TbUser  Join MstRole on MstRole.Id = TbUser.RoleId Where MobileNumber='{userCredential.MobileNo}' and Password='{userCredential.Password}'",  commandType: CommandType.Text).FirstOrDefault() ;
            }
            return result;
        }

        public UserCredential UserDetailById(UserCredential userCredential) 
        {
            UserCredential result = new UserCredential();

            using (var con = new SqlConnection(_connectionString))
            {
                result = con.Query<UserCredential>($"Select TbUser.Id,TbUser.Name as UserName,MobileNumber as MobileNo,MstRole.Name as Roles  From TbUser  Join MstRole on MstRole.Id = TbUser.RoleId Where TbUser.Id='{userCredential.Id}'", commandType: CommandType.Text).FirstOrDefault();
            }
            return result;
        }

        public string Login(Login login)
        {
            string result = null;

            using (var con = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("MobileNumber", login.MobileNo);
                result = con.Query<string>("[dbo].[ProcAuthUser]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public Users? VerifyOTP(OTP otpDTO)
        {
            Users result;

            using (var con = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("MobileNumber", otpDTO.MobileNo);
                parameters.Add("OTP", otpDTO.Otp);
                result = con.Query<Users>("[dbo].[ProcOTPVerify]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
    }
}
