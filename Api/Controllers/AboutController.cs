using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.AboutDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AboutCreate(CreateAboutDto createAboutDto)
        {
            var value = new About()
            {
                AboutTitle = createAboutDto.AboutTitle,
                AboutDescription = createAboutDto.AboutDescription,
                AboutImage = createAboutDto.AboutImage
            };
            _aboutService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            var value = new About()
            {
                AboutId = updateAboutDto.AboutId,
                AboutTitle = updateAboutDto.AboutTitle,
                AboutDescription = updateAboutDto.AboutDescription,
                AboutImage = updateAboutDto.AboutImage
            };
            _aboutService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult AboutDelete(int id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}