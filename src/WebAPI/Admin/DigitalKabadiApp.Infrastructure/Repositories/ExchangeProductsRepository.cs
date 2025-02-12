using Dapper;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class ExchangeProductsRepository : IExchangeProductsRepository
    {
        private readonly string _connectionString;
        public ExchangeProductsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ExchangeProductAccount> GetPickupBoyList(int id)
        {
            List<ExchangeProductAccount> Results = new List<ExchangeProductAccount>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("id", id);
                Results = sqlconnection.Query<ExchangeProductAccount>($"SELECT TbUser.Name, ScrapPickerId, SUM(Quantity) AS TotalQuantity FROM TbScrapPickerExchangeProductAccount JOIN TbUser ON TbUser.Id = TbScrapPickerExchangeProductAccount.ScrapPickerId GROUP BY Name, ScrapPickerId HAVING SUM(Quantity) > 50 ", param: parameter, commandType: CommandType.Text).ToList();

                return Results;
            }
        }
    }
}
