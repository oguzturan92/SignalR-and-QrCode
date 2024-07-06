using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.OrderDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _mapper.Map<List<ResultOrderDto>>(_orderService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult OrderCreate(CreateOrderDto createOrderDto)
        {
            var value = new Order()
            {
                OrderTableNumber = createOrderDto.OrderTableNumber,
                OrderDescription = createOrderDto.OrderDescription,
                OrderDate = createOrderDto.OrderDate,
                OrderTotalPrice = createOrderDto.OrderTotalPrice
            };
            _orderService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult OrderGet(int id)
        {
            var value = _orderService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult OrderUpdate(UpdateOrderDto updateOrderDto)
        {
            var value = new Order()
            {
                OrderId = updateOrderDto.OrderId,
                OrderTableNumber = updateOrderDto.OrderTableNumber,
                OrderDescription = updateOrderDto.OrderDescription,
                OrderDate = updateOrderDto.OrderDate,
                OrderTotalPrice = updateOrderDto.OrderTotalPrice
            };
            _orderService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult OrderDelete(int id)
        {
            var value = _orderService.GetById(id);
            _orderService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}