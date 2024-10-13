using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Category> GetCategory(int id)
        {
            List<Category> result = new List<Category>();
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                result = sqlconnection.Query<Category>($" select MstCategory.Id, MstCategory.Name as NameInEnglish, MstCategoryLanguage.Name as NameIsHindi  from MstCategory Join MstCategoryLanguage On MstCategoryLanguage.CategoryId = MstCategory.Id Where (@Id=0 or MstCategory.Id=@Id)",param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }
        public bool InsertCategory(Category category)
        {
            bool result;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                string query = $"Declare @CategoryId int " +
                               $"if not exists(select 1 from MstCategory where Name=@NameInEnglish) " +
                               $"Begin " +
                                   $"Insert into MstCategory (Name) Values(@NameInEnglish) " +
                                   $"Set @CategoryId = IDENT_CURRENT('MstCategory') " +
                                   $"Insert into MstCategoryLanguage (CategoryId, LanguageId, Name) Values(@CategoryId, 2, N''+@NameInHindi+'') " +
                               $"End ";

                var parameters = new DynamicParameters();

                parameters.Add("@NameInHindi", category.NameIsHindi);
                parameters.Add("@NameInEnglish", category.NameInEnglish);
                result = sqlconnection.Execute(query, param: parameters, commandType: CommandType.Text) > 0;

            }
            return result;
        }
        public bool DeleteCategory(int Id)
        {
            bool result;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@Id", Id);


                result = sqlconnection.Execute($"DELETE FROM MstCategoryLanguage WHERE Id = @Id ", param: Parameters, commandType: CommandType.Text) > 0;
            }
            return result;

        }
        public bool ModifyCategory(Category category)
        {
            bool result;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", category.Id);
                parameters.Add("@NameInEnglish", category.NameInEnglish);

                string query = $"if not exists(select 1 from MstCategory where Name=@NameInEnglish and Id!=@Id) " +
                               $"Begin " +
                                   $"UPDATE MstCategory SET Name = @NameInEnglish WHERE Id = @Id; " +
                                   $"UPDATE MstCategoryLanguage SET Name = N'{category.NameIsHindi}'  WHERE  CategoryId = @Id " +
                               "End ";

                result = sqlconnection.Execute(query, param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }

    }
}
