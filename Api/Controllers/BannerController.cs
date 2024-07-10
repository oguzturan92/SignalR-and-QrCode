using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.BannerDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BannerList()
        {
            var values = _mapper.Map<List<ResultBannerDto>>(_bannerService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BannerCreate(CreateBannerDto createBannerDto)
        {
            var value = new Banner()
            {
                BannerTitle = createBannerDto.BannerTitle,
                BannerSubTitle = createBannerDto.BannerSubTitle,
                BannerLink = createBannerDto.BannerLink,
                BannerImage = createBannerDto.BannerImage,
                BannerStatus = createBannerDto.BannerStatus
            };
            _bannerService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult BannerGet(int id)
        {
            var value = _bannerService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult BannerUpdate(UpdateBannerDto updateBannerDto)
        {
            var value = new Banner()
            {
                BannerId = updateBannerDto.BannerId,
                BannerTitle = updateBannerDto.BannerTitle,
                BannerSubTitle = updateBannerDto.BannerSubTitle,
                BannerLink = updateBannerDto.BannerLink,
                BannerImage = updateBannerDto.BannerImage,
                BannerStatus = updateBannerDto.BannerStatus
            };
            _bannerService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult BannerDelete(int id)
        {
            var value = _bannerService.GetById(id);
            _bannerService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetBannerIsTrue")]
        public IActionResult GetBannerIsTrue()
        {
            var values = _mapper.Map<List<ResultBannerDto>>(_bannerService.GetBannerIsTrue());
            return Ok(values);
        }
    }
}