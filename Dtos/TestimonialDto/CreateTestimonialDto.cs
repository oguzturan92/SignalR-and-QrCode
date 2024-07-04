using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string TestimonialFullname { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialComment { get; set; }
    }
}