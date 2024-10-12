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
        public NikaScrapApp.Core.Models.Request.ScrapInfo AddScrap(NikaScrapApp.Core.Models.Request.ScrapPickup scrap)
        {
            NikaScrapApp.Core.Models.Request.ScrapInfo result;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@UserId", scrap.UserId);
                parameters.Add("@PickUpDate", scrap.PickUpDate);
                parameters.Add("@TimeSlotId", scrap.TimeSlotId);
                parameters.Add("@AddressId", scrap.AddressId);
                parameters.Add("@EstimatedWeightId", scrap.EstimatedWeightId);
                result = sqlConnection.Query<NikaScrapApp.Core.Models.Request.ScrapInfo>($"[dbo].[InsertScrapPickup]", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
       
        List<ScrapInfo> ISchedulePickupRepositary.GetHistory(int userId, int statusId, int languageId, int PageNumber, int RowsOfPage)
        {
            List<ScrapInfo> Result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);
                parameters.Add("@statusId", statusId);
                parameters.Add("@languageId", languageId);
                parameters.Add("@PageNumber", PageNumber);
                parameters.Add("@RowsOfPage", RowsOfPage);
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
        public List<NikaScrapApp.Core.Models.Response.TimeSlot> GetTimeSlot(int userId)
        {
            List<NikaScrapApp.Core.Models.Response.TimeSlot> result = new List<NikaScrapApp.Core.Models.Response.TimeSlot>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string query = $"select MstTimeSlots.Id,MstTimeSlots.Name from MstTimeSlots " +
                               $"Join [dbo].MapTimeSlotsRoleWise TimeSlotsRoleWise On TimeSlotsRoleWise.TimeSlotId=MstTimeSlots.Id  " +
                               $"Join tbUser On tbUser.RoleId=TimeSlotsRoleWise.RoleId Where tbUser.Id={userId} ";

                result = sqlConnection.Query<NikaScrapApp.Core.Models.Response.TimeSlot>(query, commandType: CommandType.Text).ToList();
            }
            return result;
        }
        public NikaScrapApp.Core.Models.Request.ScrapInfo PickupCancel(int pickupId) 
        {
            NikaScrapApp.Core.Models.Request.ScrapInfo result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            { 
                var parameters = new DynamicParameters(); 
                parameters.Add("@Id",  pickupId);

                string query = $"Update Pickups Set  StatusId=3 from TbPickups Pickups Where  Id=@Id" +
                               $" SELECT TbPickups.Id, PickupCode, PickUpDate, MstTimeSlots.Name As TimeSlot, TbUserAddress.FullAddress As FullAddress,  MstStatus.Name As Status, TbScrapWeightRoleWise.Label as EstimatedWeigh FROM TbPickups" +
                               $" JOIN MstTimeSlots ON TbPickups.TimeSlotId = MstTimeSlots.Id " +
                               $" JOIN TbUserAddress On TbPickups.AddressId = TbUserAddress.Id" +
                               $" JOIN MstStatus ON TbPickups.StatusId = MstStatus.Id" +
                               $" JOIN TbScrapWeightRoleWise ON TbScrapWeightRoleWise.Id = TbPickups.EstimatedWeightId " +
                               $"  WHERE TbPickups.Id=@Id";


                result = sqlConnection.Query<NikaScrapApp.Core.Models.Request.ScrapInfo>(query, param: parameters, commandType: CommandType.Text).FirstOrDefault();
                return result;
            }
        }
    }
}
