using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
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
                parameters.Add("@CreatedFromDate", pickupReport.CreatedFromDate);
                parameters.Add("@CreatedToDate", pickupReport.CreatedToDate);
                result = sqlconnection.Query<PickupRecords>($"[dbo].[PickupReport]", param: parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public bool UpdatePickupStatus(PickupStatus pickupStatus) 
        {
           bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PickupId", pickupStatus.PickupId);
                parameters.Add("@StatusId", pickupStatus.StatusId);
                parameters.Add("@Remarks", pickupStatus.Remarks);
                parameters.Add("@ActionBy", pickupStatus.ActionBy);
                result = sqlconnection.Execute($" Update [dbo].TbPickups Set StatusId=@StatusId, Remarks= @Remarks, UpdatedBy = @ActionBy Where Id=@PickupId", param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }

        public bool AssignPickup(PickupAssign pickupAssign)  
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PickupId", pickupAssign.PickupId);
                parameters.Add("@UserId", pickupAssign.UserId);
                parameters.Add("@Remarks", pickupAssign.Remarks);
                parameters.Add("@ActionBy", pickupAssign.ActionBy);
                result = sqlconnection.Execute($" Update [dbo].TbPickups Set WastePickerId=@UserId ,StatusId=6,  Remarks= @Remarks, UpdatedBy = @ActionBy Where Id=@PickupId", param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }

        public string? GetMobileNo(int UserId)
        {
            string? result = string.Empty;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                result = sqlConnection.Query<string>($" Select MobileNumber from TbUser Where id={UserId}", commandType: CommandType.Text).FirstOrDefault();
            }
            return result;
        }

        public string? GetPickupCode(int pickupId)
        {
            string? result = string.Empty;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                result = sqlConnection.Query<string>($" Select PickupCode from TbPickups Where id={pickupId}", commandType: CommandType.Text).FirstOrDefault();
            }
            return result;
        }
    }
}
