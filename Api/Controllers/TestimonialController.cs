using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.TestimonialDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            var value = new Testimonial()
            {
                TestimonialFullname = createTestimonialDto.TestimonialFullname,
                TestimonialTitle = createTestimonialDto.TestimonialTitle,
                TestimonialComment = createTestimonialDto.TestimonialComment
            };
            _testimonialService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                TestimonialFullname = updateTestimonialDto.TestimonialFullname,
                TestimonialTitle = updateTestimonialDto.TestimonialTitle,
                TestimonialComment = updateTestimonialDto.TestimonialComment
            };
            _testimonialService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.GetById(id);
            _testimonialService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}