using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class ProductDal : GenericRepository<Product>, IProductDal
    {
        public ProductDal(Context context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategory()
        {
            using (var context = new Context())
            {
                var values = context.Products.Include(i => i.Category).ToList();
                return values;
            }
        }
    }
}