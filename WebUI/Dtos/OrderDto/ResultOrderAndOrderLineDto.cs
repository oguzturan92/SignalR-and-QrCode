using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.OrderDto
{
    public class ResultOrderAndOrderLineDto
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string OrderTableNumber { get; set; }
        public bool OrderComplate { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public class OrderLine
        {
            public int OrderLineId { get; set; }
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductCount { get; set; }
            public int OrderId { get; set; }
        }
    }
}