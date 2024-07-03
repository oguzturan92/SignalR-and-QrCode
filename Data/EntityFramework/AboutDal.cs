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
    public class AboutDal : GenericRepository<About>, IAboutDal
    {
        public AboutDal(Context context) : base(context)
        {
        }
    }
}