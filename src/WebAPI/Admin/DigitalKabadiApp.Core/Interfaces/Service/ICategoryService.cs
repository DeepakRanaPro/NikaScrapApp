using DigitalKabadiApp.Core.Models.Request;
using DigitalKabadiApp.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace DigitalKabadiApp.Core.Interfaces.Service
{
    public interface ICategoryService
    {
        CategoryResponse GetCategory(int id);
        CategoryResponse InsertCategory( Category category);
        CategoryResponse DeleteCategory(int id);
        CategoryResponse ModifyCategory(Category category);

    }
}