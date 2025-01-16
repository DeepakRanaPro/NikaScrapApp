﻿using Azure.Core;
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

        public List<PickupHistory> PickupHistory(int PickupId, List<PickupProducts> products) 
        { 
                List<PickupHistory> result;

                string sqlQuery = $"Select Id,Name from [dbo].LocationTypeDetails Where LanguageId=";

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    // result = con.Query<PickupHistory, UserAddress, PickupHistory>(sqlQuery, commandType: CommandType.Text).ToList();
                    result = sqlConnection.Query<PickupHistory, NikaScrapApp.Core.Models.Response.UserAddress>(sqlQuery, (pickup, address) => { pickup.UserAddressDetails = address; return pickup; }, splitOn: "UserAddressId", param: parameters, commandType: CommandType.Text).ToList();
                }
                return result; 
        }
    }
}
