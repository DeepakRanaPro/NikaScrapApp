using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface IProductService
    {
        ResponseData DeleteProduct(int id);
        ProductResponse GetProduct(int id);
        ResponseData ModifyProduct(Models.Request.Product product);
    }
}