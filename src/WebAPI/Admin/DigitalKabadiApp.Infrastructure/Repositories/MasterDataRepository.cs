using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly string _connectionString;
        public MasterDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<MasterData> GetMasterData()
        {
            List<MasterData> result = new List<MasterData>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                result = sqlconnection.Query<MasterData>($"ProcGetMasterData", commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }
    }
}
