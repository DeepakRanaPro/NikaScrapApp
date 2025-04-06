using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;
using NikaScrapApp.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class DismantleRepository : IDismantleRepository
    {
        private readonly string _connectionString;
        public DismantleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool DismantleProduct(DismantleProduct dismantleProduct)
        {
            bool result = false;
            int dismantleId;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string query = @"
                            INSERT INTO TbDismantle (ProductId, OrignalQuantity, Remarks, CreatedBy, CreatedOn) 
                            VALUES (@Productid, @OrignalQuantity, @Remarks, @CreatedBy, Getdate());

                            SET @DismantleId = SCOPE_IDENTITY();";

                var parameters = new DynamicParameters();
                parameters.Add("@Productid", dismantleProduct.Productid);
                parameters.Add("@OrignalQuantity", dismantleProduct.OrignalQuantity);
                parameters.Add("@Remarks", dismantleProduct.Remarks);
                parameters.Add("@CreatedBy", dismantleProduct.ActionBy);
                parameters.Add("@DismantleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                sqlConnection.Execute(query, param: parameters, commandType: CommandType.Text);

                // Retrieve the scalar output value
                dismantleId = parameters.Get<int>("@DismantleId");
            }

            if (dismantleId > 0)
            {
                foreach (var element in dismantleProduct.DismantleElements)
                {
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        string query = @"
                                    INSERT INTO TbDismantleElements (DismantleId, Productid,Quantity) 
                                    VALUES (@DismantleId, @Productid,@Quantity);";

                        var parameters = new DynamicParameters();
                        parameters.Add("@Productid", element.Productid);
                        parameters.Add("@Quantity", element.Quantity);
                        parameters.Add("@DismantleId", dismantleId);

                        result = sqlConnection.Execute(query, param: parameters, commandType: CommandType.Text) > 0;
                    }
                }
            }

            return result;
        }

        public List<ProcessDetails> ProcessDetails(int ProductId)
        {
            List<ProcessDetails> result = new List<ProcessDetails>();

            string sqlQuery = $" select ProductId, MstProduct.Name As ProductName,MstUnit.Name As UnitName,Quantity from TbDismantleElements join MstProduct on TbDismantleElements.ProductId=MstProduct.Id join MstUnit on TbDismantleElements.UnitId=MstUnit.Id ";


            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", ProductId);

                result = sqlConnection.Query<ProcessDetails>(sqlQuery, parameters, commandType: CommandType.Text).ToList();
            }
            return result;
        }

        //public List<ProcessDetails> ProcessDetails(ProcessDetails processDetails)
        //{
        //    List<ProcessDetails> result = new List<ProcessDetails>();

        //    string sqlQuery = $" Select TbExchangeProducts.ExchangeProductId,TbExchangeProducts.Name as ProductName,Price,MstUnit.Name as UnitName from TbExchangeProducts join MstUnit on MstUnit.Id=TbExchangeProducts.UnitId WHERE TbExchangeProducts.ExchangeProductId = @Id";


        //    using (var sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Id", ProcessDetails);

        //        result = sqlConnection.Query<ProcessDetails>(sqlQuery, parameters, commandType: CommandType.Text).ToList();
        //    }
        //    return result;
        //}

    }

}
