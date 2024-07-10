using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaLink { get; set; }
    }
}