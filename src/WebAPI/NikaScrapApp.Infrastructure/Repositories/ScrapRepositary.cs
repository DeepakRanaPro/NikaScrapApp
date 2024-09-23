using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using System.Data; 

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class SchedulePickupRepository : ISchedulePickupRepositary
    {
        private readonly string _connectionString;
        public SchedulePickupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool AddScrap(NikaScrapApp.Core.Models.Request.ScrapPickup scrap)
        {
            bool result;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", scrap.UserId);
                parameters.Add("@PickUpDate", scrap.PickUpDate);
                parameters.Add("@TimeSlotId", scrap.TimeSlotId);
                parameters.Add("@AddressId", scrap.AddressId);

                result = sqlConnection.Execute($"[dbo].[InsertScrapPickup]", param: parameters, commandType: CommandType.StoredProcedure) > 0;
            }
            return result;
        }
       
        List<ScrapInfo> ISchedulePickupRepositary.GetHistory(int userId, int statusId, int languageId)
        {
            List<ScrapInfo> Result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);
                parameters.Add("@statusId", statusId);
                parameters.Add("@languageId", languageId);

                Result = sqlConnection.Query<ScrapInfo>($"[dbo].[ManageScrap]", param: parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return Result;
        }
        public List<NikaScrapApp.Core.Models.Response.EstimateWeight> GetEstimatesWeight(int UserId)
        {
            List<NikaScrapApp.Core.Models.Response.EstimateWeight> result = new List<NikaScrapApp.Core.Models.Response.EstimateWeight>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserId", UserId);
                result =  sqlConnection.Query<Core.Models.Response.EstimateWeight>($"select TbScrapWeightRoleWise.Id,Label As Name from TbScrapWeightRoleWise join TbUser on  TbScrapWeightRoleWise.RoleId=TbUser.RoleId where TbUser.Id=@UserId", param: parameters, commandType: CommandType.Text).ToList();


            }
            return result;
        }
        public List<NikaScrapApp.Core.Models.Response.TimeSlot> GetTimeSlot()
        {
            List<NikaScrapApp.Core.Models.Response.TimeSlot> result = new List<NikaScrapApp.Core.Models.Response.TimeSlot>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            { 

                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.TimeSlot>($"select Id,Name from MstTimeSlots", commandType: CommandType.Text).ToList();
            }
            return result;
        }
        public bool PickupCancel(int pickupId) 
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            { 
                var parameters = new DynamicParameters(); 
                parameters.Add("@Id",  pickupId);

                result = sqlConnection.Execute($"Update Pickups Set  StatusId=3 from TbPickups Pickups Where  Id=@Id ", param: parameters, commandType: CommandType.Text) > 0;
                return result;
            }
        }
    }
}
