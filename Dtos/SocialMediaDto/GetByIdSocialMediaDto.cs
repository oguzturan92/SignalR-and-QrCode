using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.SocialMediaDto
{
    public class GetByIdSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaLink { get; set; }
    }
}