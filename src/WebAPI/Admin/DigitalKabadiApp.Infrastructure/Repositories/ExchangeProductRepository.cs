using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class ExchangeProductRepository : IExchangeProductRepository
    {
        private readonly string _connectionString;
        public ExchangeProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool InsertRecord(Core.Models.Request.ExchangeProduct exchangeProduct)
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", exchangeProduct.Name);
                parameters.Add("@UnitId", exchangeProduct.UnitId);
                parameters.Add("@Price", exchangeProduct.Price);
                parameters.Add("@ImagePath", exchangeProduct.ImagePath);
                parameters.Add("@Description", exchangeProduct.Description);
                result = sqlconnection.Execute($"Insert into  ExchangeProduct (Name,UnitId,Price,ImagePath,Description,Stock,IsDeleted) Values(@Name,@UnitId,@Price,@ImagePath,@Description,0,0)", param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }

        public List<Core.Models.Response.ExchangeProduct> GetRecords() 
        {
            List<Core.Models.Response.ExchangeProduct> result = new List<Core.Models.Response.ExchangeProduct>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select ExchangeProduct.Id,ExchangeProduct.Name,MstUnit.Name as  UnitName,Price,ImagePath,Description,Stock from ExchangeProduct  " +
                    $"Join MstUnit on MstUnit.Id=ExchangeProduct.UnitId " + 
                    $"Where ExchangeProduct.IsDeleted=0"; 

                result = sqlconnection.Query<Core.Models.Response.ExchangeProduct>($"{query}", commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public List<Core.Models.Response.ExchangeProduct> GetRecord(int id)
        {
            List<Core.Models.Response.ExchangeProduct> result = new List<Core.Models.Response.ExchangeProduct>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select ExchangeProduct.Id,ExchangeProduct.Name,MstUnit.Name as  UnitName,Price,ImagePath,Description,Stock from ExchangeProduct  " +
                    $"Join MstUnit on MstUnit.Id=ExchangeProduct.UnitId " +
                    $"Where ExchangeProduct.IsDeleted=0 and  ExchangeProduct.Id=@Id";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                result = sqlconnection.Query<Core.Models.Response.ExchangeProduct>($"{query}", param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }
    }
}
