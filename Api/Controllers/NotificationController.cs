using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.NotificationDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
        {
            var value = new Notification()
            {
                NotificationContent = createNotificationDto.NotificationContent,
                NotificationDate = createNotificationDto.NotificationDate
            };
            _notificationService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult NotificationGet(int id)
        {
            var value = _notificationService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
        {
            var value = new Notification()
            {
                NotificationId = updateNotificationDto.NotificationId,
                NotificationContent = updateNotificationDto.NotificationContent,
                NotificationDate = updateNotificationDto.NotificationDate
            };
            _notificationService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }
        
    }
}