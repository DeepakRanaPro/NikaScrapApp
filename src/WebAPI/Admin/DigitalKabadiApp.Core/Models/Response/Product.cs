using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalKabadiApp.Core.Models.Response
{
    public class ProductResponse : Response
    {
        public List<Product> Data { get; set; }
    }
    public class Product
    { 
        public int ProductId { get; set; }
        public int ProductPriceRoleWiseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameInHindi { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string AppIcon { get; set; } = string.Empty;
        public decimal Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UnitId { get; set; }
        public int ProductPriceId { get; set; }
        public string RoleName { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
       
        //Join TbProductPriceRoleWise on  MstProduct.Id=TbProductPriceRoleWise.ProductId Join MstRole on MstRole.Id=TbProductPriceRoleWise.RoleId
    }
}
