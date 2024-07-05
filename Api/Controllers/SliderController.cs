using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.SliderDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult SliderCreate(CreateSliderDto createSliderDto)
        {
            var value = new Slider()
            {
                SliderTitle = createSliderDto.SliderTitle,
                SliderSubTitle = createSliderDto.SliderSubTitle,
                SliderLink = createSliderDto.SliderLink
            };
            _sliderService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult SliderGet(int id)
        {
            var value = _sliderService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult SliderUpdate(UpdateSliderDto updateSliderDto)
        {
            var value = new Slider()
            {
                SliderId = updateSliderDto.SliderId,
                SliderTitle = updateSliderDto.SliderTitle,
                SliderSubTitle = updateSliderDto.SliderSubTitle,
                SliderLink = updateSliderDto.SliderLink
            };
            _sliderService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult SliderDelete(int id)
        {
            var value = _sliderService.GetById(id);
            _sliderService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}