using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.BookingDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BookingCreate(CreateBookingDto createBookingDto)
        {
            var value = new Booking()
            {
                BookingFullname = createBookingDto.BookingFullname,
                BookingPhone = createBookingDto.BookingPhone,
                BookingMail = createBookingDto.BookingMail,
                BookingPersonCount = createBookingDto.BookingPersonCount,
                BookingDate = createBookingDto.BookingDate
            };
            _bookingService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            var value = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                BookingFullname = updateBookingDto.BookingFullname,
                BookingPhone = updateBookingDto.BookingPhone,
                BookingMail = updateBookingDto.BookingMail,
                BookingPersonCount = updateBookingDto.BookingPersonCount,
                BookingDate = updateBookingDto.BookingDate
            };
            _bookingService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult BookingDelete(int id)
        {
            var value = _bookingService.GetById(id);
            _bookingService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}