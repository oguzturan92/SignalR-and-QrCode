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
    public class BannerDal : GenericRepository<Banner>, IBannerDal
    {
        public BannerDal(Context context) : base(context)
        {
        }

        public List<Banner> GetBannerIsTrue()
        {
            using (var context = new Context())
            {
                return context.Banners.Where(x => x.BannerStatus).ToList();
            }
        }
    }
}