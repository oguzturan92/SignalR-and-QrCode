using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.SliderDto
{
    public class GetByIdSliderDto
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubTitle { get; set; }
        public string SliderLink { get; set; }
        public string SliderImage { get; set; }
        public bool SliderStatus { get; set; }
    }
}