using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.OrderDto
{
    public class GetByIdOrderDto
    {
        public int OrderId { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
    }
}