using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.SocialMediaDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = new SocialMedia()
            {
                SocialMediaIcon = createSocialMediaDto.SocialMediaIcon,
                SocialMediaLink = createSocialMediaDto.SocialMediaLink
            };
            _socialMediaService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult SocialMediaGet(int id)
        {
            var value = _socialMediaService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = new SocialMedia()
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                SocialMediaIcon = updateSocialMediaDto.SocialMediaIcon,
                SocialMediaLink = updateSocialMediaDto.SocialMediaLink
            };
            _socialMediaService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var value = _socialMediaService.GetById(id);
            _socialMediaService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}