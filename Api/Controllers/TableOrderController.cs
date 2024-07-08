using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.OrderDto;
using Dtos.TableDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableOrderController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public TableOrderController(ITableService tableService, IMapper mapper, IOrderService orderService)
        {
            _tableService = tableService;
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult TableOrderList()
        {
            var values = _mapper.Map<List<ResultTableDto>>(_tableService.GetTablesStatusTrue());
            return Ok(values);
        }

        // [HttpPost]
        // public IActionResult TableOrderCreate(CreateTableOrderDto createTableOrderDto)
        // {
        //     var value = new TableOrder()
        //     {
        //         TableOrderTitle = createTableOrderDto.TableOrderTitle,
        //         TableOrderStatus = createTableOrderDto.TableOrderStatus
        //     };
        //     _tableService.Create(value);
        //     return Ok("Ekleme işlemi başarılı");
        // }

        [HttpGet("{tableId}")]
        public IActionResult TableOrderDetail(int tableId)
        {
            var orderAndOrderLine = _orderService.OrderAndOrderLine(tableId);

            var resultOrderAndOrderLineDto = new ResultOrderAndOrderLineDto
            {
                OrderId = orderAndOrderLine.OrderId,
                TableId = orderAndOrderLine.TableId,
                OrderTableNumber = orderAndOrderLine.OrderTableNumber,
                OrderComplate = orderAndOrderLine.OrderComplate,
                OrderDescription = orderAndOrderLine.OrderDescription,
                OrderDate = orderAndOrderLine.OrderDate,
                OrderTotalPrice = orderAndOrderLine.OrderTotalPrice,
                OrderLines = orderAndOrderLine.OrderLines.Select(x => new ResultOrderAndOrderLineDto.OrderLine
                {
                    OrderLineId = x.OrderLineId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ProductCount = x.ProductCount,
                    OrderId = x.OrderId
                }).ToList()
            };

            return Ok(resultOrderAndOrderLineDto);
        }

        // [HttpPut]
        // public IActionResult TableOrderUpdate(UpdateTableOrderDto updateTableOrderDto)
        // {
        //     var value = new TableOrder()
        //     {
        //         TableOrderId = updateTableOrderDto.TableOrderId,
        //         TableOrderTitle = updateTableOrderDto.TableOrderTitle,
        //         TableOrderStatus = updateTableOrderDto.TableOrderStatus
        //     };
        //     _tableService.Update(value);
        //     return Ok("Güncelleme işlemi başarılı");
        // }

        // [HttpDelete("{id}")]
        // public IActionResult TableOrderDelete(int id)
        // {
        //     var value = _tableService.GetById(id);
        //     _tableService.Delete(value);
        //     return Ok("Silme İşlemi Başarılı");
        // }
    }
}