using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.ContactDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult ContactCreate(CreateContactDto createContactDto)
        {
            var value = new Contact()
            {
                ContactMap = createContactDto.ContactMap,
                ContactPhone = createContactDto.ContactPhone,
                ContactMail = createContactDto.ContactMail,
                ContactAddress = createContactDto.ContactAddress
            };
            _contactService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            var value = _contactService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
        {
            var value = new Contact()
            {
                ContactId = updateContactDto.ContactId,
                ContactMap = updateContactDto.ContactMap,
                ContactPhone = updateContactDto.ContactPhone,
                ContactMail = updateContactDto.ContactMail,
                ContactAddress = updateContactDto.ContactAddress
            };
            _contactService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetFirstContact")]
        public IActionResult GetFirstContact()
        {
            var value = _mapper.Map<GetFirstContactDto>(_contactService.GetFirstContact());
            return Ok(value);
        }

        [HttpGet("GetFirstContactMapUrl")]
        public IActionResult GetFirstContactMapUrl()
        {
            var value = _contactService.GetFirstContactMapUrl();
            return Ok(value);
        }
    }
}