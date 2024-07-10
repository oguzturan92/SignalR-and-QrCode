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
    public class SliderDal : GenericRepository<Slider>, ISliderDal
    {
        public SliderDal(Context context) : base(context)
        {
        }

        public string GetFirstSliderImage()
        {
            using (var context = new Context())
            {
                return context.Sliders.Where(x => x.SliderStatus).FirstOrDefault().SliderImage;
            }
        }

        public List<Slider> GetSliderIsTrue()
        {
            using (var context = new Context())
            {
                return context.Sliders.Where(x => x.SliderStatus).ToList();
            }
        }
    }
}