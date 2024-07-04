using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.AboutDto
{
    public class CreateAboutDto
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImage { get; set; }
    }
}