using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using WebUI.Dtos.OrderDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.Models
{
    public class TableOrderDetailModel
    {
        public ResultOrderAndOrderLineDto Order { get; set; }
        public List<ResultProductWithCategoryDto> Products { get; set; }
    }
}