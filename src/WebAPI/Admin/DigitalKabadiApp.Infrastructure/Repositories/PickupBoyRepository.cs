using Dapper;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Transactions;

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
        public bool post(Products products)
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select MstProduct.Id,MstProduct.Name ,MstUnit.Name as UnitName,ProductsWithPriceAndUnit_FromKakar_CSV.price from MstProduct " +
                              $"join MstUnit on MstProduct.UnitId = MstUnit.Id " +
                              $"join ProductsWithPriceAndUnit_FromKakar_CSV on MstUnit.id= ProductsWithPriceAndUnit_FromKakar_CSV.id ";
                var Parameter = new DynamicParameters(sqlconnection);
                {
                    result = sqlconnection.Execute($"{query}", commandType: CommandType.Text) > 0;
                }
                return result;
            }
        }
        public bool PaymentTransactions(Core.Models.Request.ScrapPickerPaymentTransactions scrapPickerPaymentTransactions)
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"If not exists (select 1 from TbScrapPickerPaymentAccount Where ScrapPickerId=@ScrapPickerId) " +
                               $"Begin " +

                               $"Insert into TbScrapPickerPaymentAccount(ScrapPickerId, CurrentAmount, LastTransactionOn) Values(@ScrapPickerId, @PaymentAmount, Getdate()) " +
                               "End " +
                               "Else " +
                               $"Begin " +

                               $"Update TbScrapPickerPaymentAccount Set CurrentAmount = (CurrentAmount + @PaymentAmount), LastTransactionOn = Getdate() Where ScrapPickerId = @ScrapPickerId " +

                               $"End " +

                               $"Insert into TbScrapPickerPaymentTransactions(ScrapPickerId, TransactionTypeId, PaymentModeId, TransactionCode, PaymentAmount, PaymentOn, PaymentBy, Remarks ) " +
                               $"Values(@ScrapPickerId, @TransactionTypeId, @PaymentModeId, @TransactionCode, @PaymentAmount, Getdate(), @PaymentBy, @Remarks) ";
                var Parameter = new DynamicParameters(sqlconnection);
                Parameter.Add("@ScrapPickerId", scrapPickerPaymentTransactions.ScrapPickerId);
                Parameter.Add("@TransactionTypeId", scrapPickerPaymentTransactions.TransactionTypeId);
                Parameter.Add("@PaymentModeId", scrapPickerPaymentTransactions.PaymentModeId);
                Parameter.Add("@TransactionCode", scrapPickerPaymentTransactions.TransactionCode);
                Parameter.Add("@PaymentAmount", scrapPickerPaymentTransactions.PaymentAmount);
                Parameter.Add("@PaymentBy", scrapPickerPaymentTransactions.PaymentBy);
                Parameter.Add("@Remarks", scrapPickerPaymentTransactions.Remarks);
                {
                    result = sqlconnection.Execute($"{query}", param: Parameter, commandType: CommandType.Text) > 0;
                }
                return result;
            }
        }
            public bool ExchangeProduct(NikaScrapApp.Core.Models.Request.ScrapPickerExchangeProducts scrapPicker)
            {
                bool result = false;
                using (var sqlconnection = new SqlConnection(_connectionString))

                {
                    string query = $"IF NOT EXISTS (SELECT 1 FROM TbScrapPickerExchangeProducts  WHERE ScrapPickerId=@ScrapPickerId and ProductId=@ProductId )  " +
                                   $"Begin " +

                                   $"INSERT INTO TbScrapPickerExchangeProductAccount (ScrapPickerId, ProductId, Quantity) VALUES (@ScrapPickerId,@ProductId,@Quantity) " +
                                   "End " +
                                   "Else " +
                                   $"Begin " +

                                   $"Update TbScrapPickerExchangeProductAccount Set   Quantity= (Quantity + @Quantity) Where ScrapPickerId = @ScrapPickerId and ProductId=@ProductId  " +

                                   $"End " +

                                   $" INSERT into  TbScrapPickerExchangeProducts(ScrapPickerId, ProductId, ProductPrice, Quantity, ActionBy, ActionOn, Remarks) " +
                                   $" VALUES (@ScrapPickerId, @ProductId, @ProductPrice, @Quantity, @ActionBy, Getdate(),@Remarks) ";
                    var Parameter = new DynamicParameters(sqlconnection);
                Parameter.Add("@ScrapPickerId", scrapPicker.ScrapPickerId);
                    Parameter.Add("@ProductId", scrapPicker.ProductId);
                    Parameter.Add("@ProductPrice", scrapPicker.ProductPrice);
                    Parameter.Add("@Quantity", scrapPicker.Quantity);
                    Parameter.Add("@ActionBy", scrapPicker.ActionBy);
                    Parameter.Add("@Remarks", scrapPicker.Remarks);
                    {
                        result = sqlconnection.Execute(query, param: Parameter, commandType: CommandType.Text) > 0;
                    }
                    return result;
                }
            }
        public bool PickupBoyReport(PickupBoyReport report)
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select MstProduct.Id,MstProduct.Name ,MstUnit.Name as UnitName,ProductsWithPriceAndUnit_FromKakar_CSV.price from MstProduct " +
                              $"join MstUnit on MstProduct.UnitId = MstUnit.Id " +
                              $"join ProductsWithPriceAndUnit_FromKakar_CSV on MstUnit.id= ProductsWithPriceAndUnit_FromKakar_CSV.id ";
                var Parameter = new DynamicParameters(sqlconnection);
                {
                    result = sqlconnection.Execute($"{query}", commandType: CommandType.Text) > 0;
                }
                return result;
            }
        }
    }
}
