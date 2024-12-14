using Dapper;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class PickupBoyRepository : IPickupBoyRepository
    {
        private readonly string _connectionString;
        public PickupBoyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Pickup> GetHistory(int id)
        {
            List<Pickup> result = new List<Pickup>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"SELECT TbPickups.id ,pickupCode,LocationType,Landmark,FullAddress,IsDefault,AlternateMobileNumber,LocationTypeId,State,City AS AddressFullAddress ,TbUserAddress.Id,PickupCode,PickUpDate,TimeSlotId,StatusId,FullAddress,EstimatedWeightId,TbUserAddress.UserId,AddressId  from TbPickups " +
                              $"join TbUserAddress on  TbUserAddress.Id=TbPickups.UserId";
                var Parameter = new DynamicParameters(sqlconnection);
                {
                    result = sqlconnection.Query<Pickup>($"{query}", commandType: CommandType.Text).ToList();
                }
                return result;
            }
        }
        public List<UpApprovedPikup> Get(int id)
        {
            List<UpApprovedPikup> result = new List<UpApprovedPikup>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select Id,PickupCode,PickUpDate,TimeSlotId,StatusId,EstimatedWeightId,PickupCode from TbPickups ";
                var Parameter = new DynamicParameters(sqlconnection);
                {
                    result = sqlconnection.Query<UpApprovedPikup>($"{query}", commandType: CommandType.Text).ToList();
                }
                return result;
            }
        }
            public bool   post(Products products)
            {
            bool result = false;
                using (var sqlconnection = new SqlConnection(_connectionString))

                {
                string query = $"Select MstProduct.Id,MstProduct.Name ,MstUnit.Name as UnitName,ProductsWithPriceAndUnit_FromKakar_CSV.price from MstProduct " +
                              $"join MstUnit on MstProduct.UnitId = MstUnit.Id " +
                              $"join ProductsWithPriceAndUnit_FromKakar_CSV on MstUnit.id= ProductsWithPriceAndUnit_FromKakar_CSV.id ";
                    var Parameter = new DynamicParameters(sqlconnection);
                    {
                        result = sqlconnection.Execute($"{query}", commandType: CommandType.Text)>0;
                    }
                    return result;
                }
            }
    }
}
