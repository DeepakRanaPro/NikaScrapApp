using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.Data;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class PickupBoyRepository : IPickupBoyRepository
    {
        private readonly string _connectionString;
        public PickupBoyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool UpdateScrapPickup(ScrapPickupByWastePicker scrapPickupByWastePicker)
        {
            bool result;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TotalAmount", scrapPickupByWastePicker.TotalAmount);
                parameters.Add("@ExchangeProductsAmount", scrapPickupByWastePicker.ExchangeProductsAmount);
                parameters.Add("@PaymentModeId", scrapPickupByWastePicker.PaymentModeId);
                parameters.Add("@PaymentAmount", scrapPickupByWastePicker.PaymentAmount);
                parameters.Add("@TransactionCode", scrapPickupByWastePicker.TransactionCode);
                parameters.Add("@PickupBoyRemarks", scrapPickupByWastePicker.PickupBoyRemarks);
                parameters.Add("@PickupId", scrapPickupByWastePicker.PickupId);

                result = sqlConnection.Execute($" Update Pickups Set StatusId=4,TotalAmount=@TotalAmount,ExchangeProductsAmount=@ExchangeProductsAmount,PaymentModeId=@PaymentModeId, PaymentAmount=@PaymentAmount,TransactionCode=@TransactionCode, PickupBoyRemarks=@PickupBoyRemarks From TbPickups  Where Id=@PickupId ", param: parameters, commandType: CommandType.Text) > 0;

                return result;
            }
        }

        public bool InsertPickupProduct(int PickupId, List<PickupProducts> products)
        {
            int totalProducts = 0;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                foreach (var product in products)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductTypeId", product.ProductTypeId);
                    parameters.Add("@PickupId", PickupId);
                    parameters.Add("@UnitId", product.UnitId);
                    parameters.Add("@Price", product.Price);
                    parameters.Add("@Quantity", product.Quantity);

                    totalProducts += sqlConnection.Execute($" Insert into TbPickupProducts (ProductTypeId,PickupId,ProductId,UnitId,Price,Quantity) Values(@ProductTypeId,@PickupId,@ProductId,@UnitId,@Price,@Quantity) ", param: parameters, commandType: CommandType.Text);
                }
                return totalProducts > 0;
            }
        }

        public List<PickupHistory> PickupHistory(int userId)
        {
            string sqlQuery = @"
              SELECT 
                  TbPickups.Id AS PickupID,
                  PickupCode,
                  PickUpDate,
                  TbUserAddress.Id AS UserAddressId,
                  PickupCode,
                  LocationType,
                  Landmark,
                  AlternateMobileNumber,
                  IsDefault,
                  State,
                  City,
                  EstimatedWeightId,
                  FullAddress,
                  MstTimeSlots.Name AS TimeSlot,
                  MstStatus.Name AS Status,
                  TbScrapWeightRoleWise.Label AS EstimatedWeigh
              FROM TbPickups
              JOIN TbUserAddress ON TbUserAddress.Id = TbPickups.AddressId
              JOIN TbUser ON TbUser.Id = TbPickups.UserId
              JOIN MapTimeSlotsRoleWise ON MapTimeSlotsRoleWise.Id = TbPickups.TimeSlotId
              JOIN MstTimeSlots ON MstTimeSlots.Id = MapTimeSlotsRoleWise.TimeSlotId
              JOIN MstStatus ON MstStatus.Id = TbPickups.StatusId
              JOIN TbScrapWeightRoleWise ON TbScrapWeightRoleWise.Id = TbPickups.EstimatedWeightId AND TbScrapWeightRoleWise.RoleId = TbUser.RoleId
              WHERE (TbPickups.WastePickerId = @userId or TbPickups.WareHouseInchargeId = @userId)";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var result = sqlConnection.Query<PickupHistory, Core.Models.Response.UserAddress, PickupHistory>(
                    sqlQuery,
                    (pickupHistory, userAddress) =>
                    {
                        pickupHistory.UserAddressDetails = userAddress;
                        return pickupHistory;
                    },
                    parameters,
                    splitOn: "UserAddressId"
                ).ToList();

                return result;
            }
        }

        public PickupInfo PickupDetail(int pickupId)
        {
            PickupInfo pickupInfo = new PickupInfo();
            List<PickupInfoConsolidated> ConsolidatedInfo = new List<PickupInfoConsolidated>();

            string sqlQuery = $" SELECT  TbPickupProducts.ProductTypeId,MstProduct.Name as ProductName, MstUnit.Name as UnitName,TbPickupProducts.Price,TbPickupProducts.Quantity, TbPickupPayment.TotalAmount as TotalAmountToCustomer,TbPickupPayment.TransactionCode,MstPaymentMode.Name as PaymentMode,TbPickupPayment.Remarks  FROM TbPickupProducts \r\n " +
                              $" JOIN TbPickups ON TbPickups.Id = TbPickupProducts.PickupId " +
                              $" JOIN MstProduct ON MstProduct.Id = TbPickupProducts.ProductId " +
                              $" JOIN MstUnit ON MstUnit.Id = TbPickupProducts.UnitId  " +
                              $" JOIN TbPickupPayment ON TbPickupPayment.Id = TbPickupProducts.ProductTypeId " +
                              $" Join MstProductType on MstProductType.Id=TbPickupProducts.ProductTypeId " +
                              $" JOIN MstPaymentMode ON MstPaymentMode.Id = TbPickupPayment.PaymentModeId " +
                              $" JOIN TbExchangeProducts ON TbExchangeProducts.ExchangeProductId = TbPickupProducts.ProductTypeId ";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@pickupId", pickupId);

                ConsolidatedInfo = sqlConnection.Query<PickupInfoConsolidated>(sqlQuery, parameters, commandType: CommandType.Text).ToList();
            }

            pickupInfo.TotalAmountToCustomer = ConsolidatedInfo.FirstOrDefault().TotalAmountToCustomer;
            pickupInfo.PaymentMode = ConsolidatedInfo.FirstOrDefault().PaymentMode;
            pickupInfo.TransactionCode = ConsolidatedInfo.FirstOrDefault().TransactionCode;
            pickupInfo.Remarks = ConsolidatedInfo.FirstOrDefault().Remarks;

            pickupInfo.ScrapProducts.AddRange(ConsolidatedInfo.Where(var => var.ProductTypeId == 1).Select(var => new Product()
            {
                 ProductName = var.ProductName,
                UnitName = var.UnitName,
                Price = var.Price,
                Quantity = var.Quantity,
            }
            ).ToList());

            pickupInfo.ExchangedProducts.AddRange(ConsolidatedInfo.Where(var => var.ProductTypeId == 2).Select(var => new Product()
            {
                ProductName = var.ProductName,
                UnitName = var.UnitName,
                Price = var.Price,
                Quantity = var.Quantity,
            }
            ).ToList());

            return pickupInfo;
        }
    }
}
