using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.MessageDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.GetMessagesDateTimeBy());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult MessageCreate(CreateMessageDto createMessageDto)
        {
            var value = new Message()
            {
                MessageFullname = createMessageDto.MessageFullname,
                MessageSubject = createMessageDto.MessageSubject,
                MessageContent = createMessageDto.MessageContent,
                MessageRead = createMessageDto.MessageRead,
                MessageDate = createMessageDto.MessageDate,
                MessageMail = createMessageDto.MessageMail
            };
            _messageService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult MessageGet(int id)
        {
            var value = _messageService.GetById(id);
            
            value.MessageRead = true;
            _messageService.Update(value);
            
            return Ok(value);
        }

        [HttpPut]
        public IActionResult MessageUpdate(UpdateMessageDto updateMessageDto)
        {
            var value = new Message()
            {
                MessageId = updateMessageDto.MessageId,
                MessageFullname = updateMessageDto.MessageFullname,
                MessageSubject = updateMessageDto.MessageSubject,
                MessageContent = updateMessageDto.MessageContent,
                MessageRead = updateMessageDto.MessageRead,
                MessageDate = updateMessageDto.MessageDate,
                MessageMail = updateMessageDto.MessageMail
            };
            _messageService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult MessageDelete(int id)
        {
            var value = _messageService.GetById(id);
            _messageService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}