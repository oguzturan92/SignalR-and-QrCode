using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.OrderLineDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderLineController : ControllerBase
    {
        private readonly IOrderLineService _orderLineService;
        private readonly IMapper _mapper;

        public OrderLineController(IMapper mapper, IOrderLineService orderLineService)
        {
            _mapper = mapper;
            _orderLineService = orderLineService;
        }

        // [HttpGet]
        // public IActionResult OrderLineList()
        // {
        //     var values = _mapper.Map<List<ResultOrderLineDto>>(_orderLineService.GetAll());
        //     return Ok(values);
        // }

        [HttpPost]
        public IActionResult OrderLineCreate(CreateOrderLineDto createOrderLineDto)
        {
            var value = new OrderLine()
            {
                ProductName = createOrderLineDto.ProductName,
                ProductPrice = createOrderLineDto.ProductPrice,
                ProductCount = createOrderLineDto.ProductCount,
                OrderId = createOrderLineDto.OrderId
            };
            _orderLineService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{orderId},{productName}")]
        public IActionResult OrderLineGet(int orderId, string productName)
        {
            var value = _orderLineService.GetOrderLine(orderId, productName);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult OrderLineUpdate(UpdateOrderLineDto updateOrderLineDto)
        {
            var value = new OrderLine()
            {
                OrderLineId = updateOrderLineDto.OrderLineId,
                ProductName = updateOrderLineDto.ProductName,
                ProductPrice = updateOrderLineDto.ProductPrice,
                ProductCount = updateOrderLineDto.ProductCount,
                OrderId = updateOrderLineDto.OrderId
            };
            _orderLineService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult OrderLineDelete(int id)
        {
            var value = _orderLineService.GetById(id);
            _orderLineService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }

    }
}