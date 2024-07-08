using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.OrderDto
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string OrderTableNumber { get; set; }
        public bool OrderComplate { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
    }
}