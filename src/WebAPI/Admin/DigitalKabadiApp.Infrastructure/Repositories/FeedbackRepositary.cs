using Dapper;
using DigitalKabadiApp.Core.Interfaces.Repository;
using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public class FeedbackRepositary: iFeedbackRepositary
    {
        private readonly string _connectionString;
        public FeedbackRepositary(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Core.Models.Response.Feedback> GetFeedback(Core.Models.Request.Feedback feedback)
        {
            List<Core.Models.Response.Feedback> result = new List<Core.Models.Response.Feedback>();
            using (var sqlconnection = new SqlConnection(_connectionString))

            {
                string query = $"Select TbFeedback.Id,ImagePath,Description,TbPickups.PickupCode, TbUser.Name as userName, TbFeedback.Rating from TbFeedback " +
                    $"join TbPickups on TbFeedback.PickupId = TbPickups.Id " +
                    $"join TbUser on TbFeedback.Id = TbPickups.Id " +
                    $"Where  (@RatingFrom = 0 or (TbFeedback.Rating between @RatingFrom and @RatingTo  ) ) and (@FromDate='1900-01-01' or (DateDiff(Day,TbFeedback.CreatedOn,@FromDate)<=0 and DateDiff(Day,TbFeedback.CreatedOn,@ToDate)>=0))";
                var parameters = new DynamicParameters();
                parameters.Add("@RatingFrom", feedback.RatingFrom);
                parameters.Add("@RatingTo", feedback.RatingTo);
                parameters.Add("@FromDate", feedback.CreatedFrom);
                parameters.Add("@ToDate", feedback.CreatedTo);
                 
                result = sqlconnection.Query<Core.Models.Response.Feedback>($"{query}", param: parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }

       
        public bool Insertfeedback(Core.Models.Request.Feedback feedback)
        {
            bool result = false;
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", feedback.Id);
                parameters.Add("@pickupId", feedback.PickupId);
                parameters.Add("@Imagepath", feedback.ImagePath);
                parameters.Add("@Description", feedback.Description);

                result = sqlconnection.Execute($" Insert into TbFeedback(Id,pickupId,Imagepath,Description,CreatedOn,UserName,Rating)values (@Id,@pickupId,@Imagepath,@Description,@UserName,@Rating, Getdate())", param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }


    }
}