namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface IProductRepository
    {
        bool DeleteProduct(int Id);
        List<Models.Response.Product> GetProducts(int id);
        bool ModifyProduct(Models.Request.Product product);
    }
}