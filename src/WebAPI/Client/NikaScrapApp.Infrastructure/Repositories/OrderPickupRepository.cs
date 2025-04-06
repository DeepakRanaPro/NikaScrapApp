using Dapper;
using Microsoft.Data.SqlClient;
using NikaScrapApp.Core.Interfaces;
using NikaScrapApp.Core.Models.Request;

namespace NikaScrapApp.Infrastructure.Repositories
{
    public class OrderPickupRepository : IOrderPickupRepository
    {
        private readonly string _connectionString;
        public OrderPickupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ProcessOrderPickup(OrderPickup orderPickup)
        {
            bool result = false;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        // Insert Pickup Payment
                        string paymentQuery = @"
                    INSERT INTO TbPickupPayment (PickupId, TotalAmount, ExchangeProductsAmount, PaymentModeId, PaidAmount, TransactionCode, Remarks)
                    VALUES (@PickupId, @TotalAmount, @ExchangeProductsAmount, @PaymentModeId, @PaidAmount, @TransactionCode, @Remarks)";

                        sqlConnection.Execute(paymentQuery, new
                        {
                            orderPickup.PickupId,
                            orderPickup.TotalAmount,
                            orderPickup.ExchangeProductsAmount,
                            orderPickup.PaymentModeId,
                            orderPickup.PaidAmountToCustomer,
                            orderPickup.TransactionCode,
                            orderPickup.Remarks
                        }, transaction);

                        // Update Pickup Status
                        string updatePickupQuery = "UPDATE TbPickups SET StatusId = 2 WHERE PickupId = @PickupId";
                        sqlConnection.Execute(updatePickupQuery, new { orderPickup.PickupId }, transaction);

                        // Insert Scrap Products
                        if (orderPickup.ScrapProducts.Any())
                        {
                            string insertScrapProductsQuery = @"
                        INSERT INTO TbPickupProducts (PickupId, ProductTypeId, ProductDescription, ProductId, UnitId, Price, Quantity, ApprovedQuantity, Remarks)
                        VALUES (@PickupId, @ProductTypeId, @ProductDescription, @ProductId, @UnitId, @Price, @Quantity, @ApprovedQuantity, @Remarks)";

                            foreach (var product in orderPickup.ScrapProducts)
                            {
                                sqlConnection.Execute(insertScrapProductsQuery, new
                                {
                                    orderPickup.PickupId,
                                    ProductTypeId = 1,
                                    product.ProductDescription,
                                    product.ProductId,
                                    product.unitId,
                                    product.price,
                                    product.Quantity,
                                    ApprovedQuantity = 0,
                                    product.Remarks
                                }, transaction);
                            }
                        }

                        // Insert Exchanged Product
                        if (orderPickup.ExchangedProduct.Any())
                        {
                            string insertExchangedProductsQuery = @" 
                        INSERT INTO TbPickupProducts (PickupId, ProductTypeId, ProductDescription, ProductId, UnitId, Price, Quantity, ApprovedQuantity, Remarks)
                        VALUES (@PickupId, @ProductTypeId, @ProductDescription, @ProductId, @UnitId, @Price, @Quantity, @ApprovedQuantity, @Remarks)";

                            foreach (var product in orderPickup.ScrapProducts)
                            {
                                sqlConnection.Execute(insertExchangedProductsQuery, new
                                {
                                    orderPickup.PickupId,
                                    ProductTypeId = 2,
                                    product.ProductDescription, 
                                    product.ProductId,
                                    product.unitId,
                                    product.price,
                                    product.Quantity,
                                    ApprovedQuantity = 0,
                                    product.Remarks
                                }, transaction);
                            }
                        }

                        // Commit transaction
                        transaction.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Log error
                        Console.WriteLine($"Error processing order pickup: {ex.Message}");
                    }
                }
            }

            return result;
        }
    }
}
