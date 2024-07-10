using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.BannerDto
{
    public class ResultBannerDto
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerLink { get; set; }
        public string BannerImage { get; set; }
        public bool BannerStatus { get; set; }
    }
}