using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class PickupRepository : IPickupRepository
    {
        private readonly string _connectionString;
        public PickupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PickupRecords> GetPickupRecords(PickupReport pickupReport)
        {
            List<PickupRecords> result = new List<PickupRecords>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", pickupReport.UserId);
                parameters.Add("@StatusId", pickupReport.StatusId);
                parameters.Add("@PickupCode", pickupReport.PickupCode);
                parameters.Add("@State", pickupReport.State);
                parameters.Add("@City", pickupReport.City);
                parameters.Add("@LocationTypeId", pickupReport.LocationTypeId);
                parameters.Add("@FromDate", pickupReport.FromDate);
                parameters.Add("@ToDate", pickupReport.ToDate);
                result = sqlconnection.Query<PickupRecords>($"[dbo].[PickupReport]", param: parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }
    }
}
