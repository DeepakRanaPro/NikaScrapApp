using DigitalKabadiApp.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategory(int id);
        bool InsertCategory(Category category);
        bool DeleteCategory(int Id);
        bool ModifyCategory(Category category);
    }
}
