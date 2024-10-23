using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class SmsRepository : ISmsRepository
    {
        private readonly string _connectionString;
        public SmsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool SaveSmsApiResponse(SmsApi SmsApiResponse)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Status", SmsApiResponse.Status);
                parameters.Add("@MessageId", SmsApiResponse.MessageId);
                parameters.Add("@Code", SmsApiResponse.Code);
                parameters.Add("@Description", SmsApiResponse.Description);
                result = sqlConnection.Execute($"Insert into dbo.SmsApiResponse (Status,Code,MessageId,Description,CreatedOn) Values(@Status,@Code,@MessageId,@Description,Getdate())", param: parameters, commandType: CommandType.Text) > 0;

                return result;
            }
        }
    }
}
