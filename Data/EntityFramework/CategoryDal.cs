using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;

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
    }
}