using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dtos.TableDto;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TableList()
        {
            var values = _mapper.Map<List<ResultTableDto>>(_tableService.GetAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult TableCreate(CreateTableDto createTableDto)
        {
            var value = new Table()
            {
                TableTitle = createTableDto.TableTitle,
                TableStatus = createTableDto.TableStatus,
                TableColor = createTableDto.TableColor,
                TableIsItFull = createTableDto.TableIsItFull
            };
            _tableService.Create(value);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult TableGet(int id)
        {
            var value = _tableService.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult TableUpdate(UpdateTableDto updateTableDto)
        {
            var value = new Table()
            {
                TableId = updateTableDto.TableId,
                TableTitle = updateTableDto.TableTitle,
                TableStatus = updateTableDto.TableStatus,
                TableColor = updateTableDto.TableColor,
                TableIsItFull = updateTableDto.TableIsItFull
            };
            _tableService.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult TableDelete(int id)
        {
            var value = _tableService.GetById(id);
            _tableService.Delete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}