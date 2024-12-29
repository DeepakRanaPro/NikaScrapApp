using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class WarehouseInchargeRepository : IWarehouseInchargeRepository
    {
        private readonly string _connectionString;
        public WarehouseInchargeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NikaScrapApp.Core.Models.Response.UnappprovedPickup> GetUnapprovedPickups(string PickupCode) 
        {
            List<NikaScrapApp.Core.Models.Response.UnappprovedPickup> result = new List<NikaScrapApp.Core.Models.Response.UnappprovedPickup>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select TbPickups.Id as PickupId,PickupCode,PickupDate,MstTimeSlots.Name as TimeSlot,MstStatus.Name as Status, TbUser.Name as PickupBoy,TotalAmount from TbPickups " +
                    $"Join MstTimeSlots on MstTimeSlots.Id=TbPickups.TimeSlotId " +
                    $"Join MstStatus on MstStatus.Id=TbPickups.StatusId " +
                    $"Join TbUser on TbUser.Id=TbPickups.WastePickerId  " +
                    $"Where TbPickups.StatusId=4 and (@PickupCode='0' or PickupCode=@PickupCode) ";
                var parameters = new DynamicParameters();
                parameters.Add("@PickupCode", PickupCode);

                result = sqlconnection.Query<NikaScrapApp.Core.Models.Response.UnappprovedPickup>($"{query}", param:parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public List<NikaScrapApp.Core.Models.Response.UnApproved> GetUnapprovedPickupDetails(int pickupId) 
        {
            List< NikaScrapApp.Core.Models.Response.UnApproved> result = new List<NikaScrapApp.Core.Models.Response.UnApproved>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                string query = $"select TbPickupProducts.PickupId,Price, ApprovedQuantity ,MstUnit.Name As UnitName ,MstProduct.Id ,MstProduct.Name from TbPickupProducts " +
                    $"join MstUnit on TbPickupProducts.UnitId=MstUnit.Id " +
                    $"join MstProduct on TbPickupProducts.PickupProductId = MstProduct.Id Where PickupId=@PickupId ";
                var parameters = new DynamicParameters();
                parameters.Add("@PickupId", pickupId);
                 
                result = sqlconnection.Query<NikaScrapApp.Core.Models.Response.UnApproved>($"{query}", param:parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }
        public bool ApprovePickupProducts(NikaScrapApp.Core.Models.Request.UnApprovedPickup unApprovedPickup)  

        {
           bool result = true;
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Update TbPickups set StatusId=5,WareHouseInchargeId=@WareHouseInchargeId where Id=@PickupId " +
                               $"Update TbPickupProducts set ApprovedQuantity=@ApprovedQuantity,Remarks=@Remarks where PickupProductId=@PickupProductId ";
 
                var parameters = new DynamicParameters();

                parameters.Add("@WareHouseInchargeId", unApprovedPickup.WareHouseInchargeId);
                parameters.Add("@PickupId", unApprovedPickup.PickupId);
                parameters.Add("@ApprovedQuantity", unApprovedPickup.ApprovedQuantity);
                parameters.Add("@Remarks", unApprovedPickup.Remarks);
                parameters.Add("@PickupProductId", unApprovedPickup.PickupProductId);
                  
                result = sqlconnection.Execute($"{query}",param:parameters, commandType: CommandType.Text)>0;
            }
            return result;
        }

     
    }
}
