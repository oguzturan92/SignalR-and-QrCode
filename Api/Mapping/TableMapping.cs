using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.TableDto;
using Entity.Concrete;

namespace Api.Mapping
{
    public class TableMapping:Profile
    {
        public TableMapping()
        {
            CreateMap<Table, ResultTableDto>().ReverseMap();
            CreateMap<Table, CreateTableDto>().ReverseMap();
            CreateMap<Table, UpdateTableDto>().ReverseMap();
            CreateMap<Table, GetByIdTableDto>().ReverseMap();
        }
    }
}