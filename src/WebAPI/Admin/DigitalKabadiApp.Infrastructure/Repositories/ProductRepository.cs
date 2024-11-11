using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<DigitalKabadiApp.Core.Models.Response.Product> GetProducts(int id)
        {
            List<DigitalKabadiApp.Core.Models.Response.Product> result = new List<DigitalKabadiApp.Core.Models.Response.Product>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", id);
                result = sqlconnection.Query<DigitalKabadiApp.Core.Models.Response.Product>($" Select MstRole.Name as RoleName,Price,TbProductPriceRoleWise.ID as ProductPriceId,MstProduct.Id as ProductId,MstProduct.Name,MstProductLanguage.Name as NameInHindi,MstCategory.Name as CategoryName,MstUnit.Name as UnitName,AppIcon,Stock,Description,UnitId,CategoryId from MstProduct Join MstCategory on MstCategory.Id=Categoryid Join MstUnit on MstUnit.Id=UnitId Join MstProductLanguage on MstProductLanguage.ProductId=MstProduct.Id and MstProductLanguage.LanguageId=2 Join TbProductPriceRoleWise on  MstProduct.Id=TbProductPriceRoleWise.ProductId Join MstRole on MstRole.Id=TbProductPriceRoleWise.RoleId Where  MstProduct.IsDeleted=0 and (@ProductId=0 or MstProduct.Id=@ProductId) ", param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public bool DeleteProduct(int Id)
        {
            bool result;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ProductId", Id);


                result = sqlconnection.Execute($"Update MstProduct  Set IsDeleted=1 ,  DeletedOn=Getdate() Where Id=@ProductId  ", param: Parameters, commandType: CommandType.Text) > 0;
            }
            return result;

        }
        public bool ModifyProduct(DigitalKabadiApp.Core.Models.Request.Product product)
        {
            bool result;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", product.ProductId);
                parameters.Add("@ProductPriceId", product.ProductPriceId);
                parameters.Add("@Price", product.Price);
                parameters.Add("@Name", product.Name);
                parameters.Add("@CategoryId", product.CategoryId);
                parameters.Add("@UnitId", product.UnitId);
                parameters.Add("@ActionBy", product.ActionBy);
                parameters.Add("@NameInHindi", product.NameInHindi);

                string query = $"Update MstProduct  Set Name=@Name, CategoryId=@CategoryId, UnitId=@UnitId , UpdatedBy=@ActionBy ,UpdatedOn=Getdate() Where Id=@ProductId  " +
                               $"Update MstProductLanguage  Set Name=@NameInHindi Where ProductId=@ProductId and LanguageId=2 " +
                               $"Update TbProductPriceRoleWise  Set Price=@Price Where Id=@ProductPriceId ";

                result = sqlconnection.Execute(query, param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }
    }
}
