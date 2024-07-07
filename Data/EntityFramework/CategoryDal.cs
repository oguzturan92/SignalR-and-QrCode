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
    public class CategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public CategoryDal(Context context) : base(context)
        {
        }

        public int CategoryCount()
        {
            using (var context = new Context())
            {
                return context.Categories.Count();
            }
        }

        public List<Category> GetCategoriesAndProducts()
        {
            using (var context = new Context())
            {
                return context.Categories.Include(i => i.Products).ToList();
            }
        }
    }
}