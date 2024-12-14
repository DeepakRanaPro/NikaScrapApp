using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class ContactUsRepositary: IContactUsRepositary
    {
        private readonly string _connectionString;
        public ContactUsRepositary(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<ContactUs> GetContact(int id)

        {
            List<ContactUs> result = new List<ContactUs>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select TbContactUs.Id,Source,Subject,Description,FromEmail , TbUser.Id as UserID,IsDeleted,GETDATE() from TbContactUs " +
                    $"left join TbUser on TbUser.Id =TbContactUs.UserId ";
                var parameters = new DynamicParameters();
                parameters.Add("@RatingFrom", id);


                result = sqlconnection.Query<ContactUs>($"{query}", commandType: CommandType.Text).ToList();
            }
            return result;
        }

        public bool AddContactUs(Core.Models.Request.ContactUs contactUs)
        {
            bool result;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@SourceType", contactUs.SourceType);
                parameters.Add("@Subject", contactUs.Subject);
                parameters.Add("@Description", contactUs.Description);
                parameters.Add("@FromEmail", contactUs.FromEmail);
                parameters.Add("@UserId", contactUs.UserId);
                parameters.Add("@IsDeleted", contactUs.IsDeleted);
                parameters.Add("@CreatedOn", contactUs.CreatedOn);

                result = sqlConnection.Execute($"Insert into TbContactUs(Source,Subject,Description,FromEmail,UserId,IsDeleted,CreatedOn) Values(@Source,@Subject,@Description,@FromEmail,@UserId,@IsDeleted,@CreatedOn)", param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }
}
    }