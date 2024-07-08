using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Data.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategory();
        List<Product> GetProductsWithCategoryStatusTrue();
        int ProductCount();
    }
}