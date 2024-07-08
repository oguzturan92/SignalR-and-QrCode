using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.OrderDto;
using Entity.Concrete;

namespace Api.Mapping
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderAndOrderLineDto>().ReverseMap();
            CreateMap<Order, ResultOrderDto>().ReverseMap();
        }
    }
}