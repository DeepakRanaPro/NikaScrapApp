using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System.Data;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly string _connectionString;
        public MasterDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<MasterData> GetRoles(Request request)
        {
            List<MasterData> result;

            using (var con = new SqlConnection(_connectionString))
            {
                result = con.Query<MasterData>($"Select Id,Name from [dbo].RoleDetails Where Id in (3,4,5) and LanguageId={request.LanguageId}", commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public List<MasterData> GetLocationTypes(Request request) 
        {
            List<MasterData> result;

            using (var con = new SqlConnection(_connectionString))
            {
                result = con.Query<MasterData>($"Select Id,Name from [dbo].LocationTypeDetails Where LanguageId={request.LanguageId}", commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public List<NikaScrapApp.Core.Models.Response.RateList> GetRateList(NikaScrapApp.Core.Models.Request.RateList rateListRequest)
        {
            List<NikaScrapApp.Core.Models.Response.RateList> result = new List<NikaScrapApp.Core.Models.Response.RateList>(); 

            using (var con = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserId", rateListRequest.UserId);
                parameters.Add("LanguageId", rateListRequest.LanguageId);
                var produstDetails = con.Query<ProductDetails>("[dbo].[ProcGetRateList]", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (produstDetails.Any())
                {
                    result = (produstDetails
                                    .GroupBy(p => new { p.Categoryid, p.CategoryName })
                                    .Select(g => g.First())
                                    .ToList()).Select(x => new NikaScrapApp.Core.Models.Response.RateList { Categoryid = x.Categoryid, CategoryName = x.CategoryName }).ToList();

                    result.ForEach(x =>
                    {
                        x.Products = produstDetails.Where(product => product.Categoryid == x.Categoryid).Select(x => new Products
                        {
                            AppIcon = x.AppIcon,
                            Price = Math.Round(Convert.ToDecimal(x.Price), 2).ToString(),
                            ProductId = x.ProductId,
                            ProductName = x.ProductName,
                            UnitName = x.UnitName,
                            WebAppIcon = x.WebAppIcon, 
                        }
                        ).ToList();
                    });
                }
            }

            return result;
        }

        public List<PincodeDetails> GetPincodeDetails(string pincode)  
        {
            List<PincodeDetails> result;

            using (var con = new SqlConnection(_connectionString))
            {
                result = con.Query<PincodeDetails>($" Select PinCode,City,State from [MstPingCodeData]  Where PinCode Like '%{pincode}%' ", commandType: CommandType.Text).ToList();
            }
            return result;
        }
    }
}
