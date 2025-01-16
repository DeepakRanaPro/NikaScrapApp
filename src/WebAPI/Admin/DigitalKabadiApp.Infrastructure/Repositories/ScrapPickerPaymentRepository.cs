using Dapper;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class ScrapPickerPaymentRepository : IScrapPickerPaymentRepository
    {
        private readonly string _connectionString;
        public ScrapPickerPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ScrapPickerPaymentAccountDetails> PickerPaymentAccountDetail(int ScrapPickerId)
        {
            List<ScrapPickerPaymentAccountDetails> result = new List<ScrapPickerPaymentAccountDetails>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $" select ScrapPickerId , CurrentAmount as CurrentBalance, LastTransactionOn ,TbUser.Name as ScrapPickerName from TbScrapPickerPaymentAccount  " +
                               $" join TbUser on TbUser.Id = TbScrapPickerPaymentAccount.ScrapPickerId  " +
                               $" where (@ScrapPickerId=0 or ScrapPickerId=@ScrapPickerId) ";
                var Parameter = new DynamicParameters(sqlconnection);
                Parameter.Add("@ScrapPickerId", ScrapPickerId);
                {
                    result = sqlconnection.Query<ScrapPickerPaymentAccountDetails>($"{query}", param: Parameter, commandType: CommandType.Text).ToList();
                }
                return result;
            }
        }

        //public List<Core.Models.Request.PickerPaymentTransaction> PickerPaymentTransactions(int ScrapPickerId, int PickupId)
        //{
        //    List<Core.Models.Request.PickerPaymentTransaction> result = new List<Core.Models.Request.PickerPaymentTransaction>();
        //    using (var sqlconnection = new SqlConnection(_connectionString))

        //    {
        //        string query =
        //                       $"  select TbScrapPickerPaymentTransactions.Id,ScrapPickerId, PreviousBalance,TbScrapPickerPaymentTransactions.PaymentAmount,CurrentBalance,TbScrapPickerPaymentTransactions.TransactionCode,GETDATE(),PaymentBy,TbScrapPickerPaymentTransactions.Remarks,TbPickups.Id as PickupId,PickupCode from TbScrapPickerPaymentTransactions  " +
        //                       $"  join TbPickups on TbScrapPickerPaymentTransactions.PickupId = TbPickups.Id  " +
        //                       $" where ScrapPickerId=@ScrapPickerId and PickupId=@PickupId ";
        //        var Parameter = new DynamicParameters(sqlconnection);
        //        Parameter.Add("@ScrapPickerId", ScrapPickerId);
        //        Parameter.Add("@PickupId", PickupId);
        //        {
        //            result = sqlconnection.Query<Core.Models.Request.PickerPaymentTransaction>($"{query}", param: Parameter, commandType: CommandType.Text).ToList();
        //        }
        //        return result;
        //    }
        //}
        //public List<Core.Models.Response.ScrapPickerPaymentAccounts> PickerPaymentAccounts(int ScrapPickerId)
        //{
        //    List<Core.Models.Response.ScrapPickerPaymentAccounts> result = new List<Core.Models.Response.ScrapPickerPaymentAccounts>();
        //    using (var sqlconnection = new SqlConnection(_connectionString))

        //    {
        //        string query = $" Declare @ScrapPickerId int=0 " +
        //                       $"  Select TbUser.Id,TbUser.Name , CurrentAmount as CurrentBanance from TbScrapPickerPaymentAccount  PaymentAccount  " +
        //                       $"   Join TbUser on TbUser.Id=PaymentAccount.ScrapPickerId   " +
        //                       $"     Where (@ScrapPickerId=0 or PaymentAccount.ScrapPickerId=@ScrapPickerId)  ";

        //        var Parameter = new DynamicParameters(sqlconnection);
        //        {
        //            result = sqlconnection.Query<Core.Models.Response.ScrapPickerPaymentAccounts>($"{query}", param: Parameter, commandType: CommandType.Text).ToList();
        //        }
        //        return result;
        //    }
        //}
            public List<Core.Models.Response.TbScrapPickerPaymentTransaction> ScrapPickerPaymentTransaction(int id)
            {
                List<Core.Models.Response.TbScrapPickerPaymentTransaction> result = new List<Core.Models.Response.TbScrapPickerPaymentTransaction>();
                using (var sqlconnection = new SqlConnection(_connectionString))

                {
                string query = $" Select  PaymentTransactions.Id , PreviousBalance,PaymentTransactions.PaymentAmount,CurrentBalance,PaymentOn,PaymentTransactions.Remarks,MstTransactionType.Name as TransactionType,TbPickups.PickupCode as PickupCode , MstPaymentMode.Name as PaymentMode   " +
                               $" From TbScrapPickerPaymentTransactions as PaymentTransactions  " +
                               $" join MstTransactionType on PaymentTransactions.TransactionTypeId=MstTransactionType.Id  " +
                               $" left join TbPickups on PaymentTransactions.PickupId=TbPickups.Id " +
                               $" join MstPaymentMode on MstPaymentMode.Id= PaymentTransactions.PaymentModeId  Where (@ScrapPickerId=0 or ScrapPickerId=@ScrapPickerId)  ";


                var Parameters = new DynamicParameters(sqlconnection);
                    {
                       Parameters.Add("@ScrapPickerId", id);
                        result = sqlconnection.Query<Core.Models.Response.TbScrapPickerPaymentTransaction>($"{query}",param: Parameters, commandType: CommandType.Text).ToList();
                    }
                    return result;
                }
            }

            
    }
}
