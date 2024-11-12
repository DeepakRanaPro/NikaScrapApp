using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
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
