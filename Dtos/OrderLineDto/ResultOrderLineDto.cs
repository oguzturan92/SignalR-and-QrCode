using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.OrderLineDto
{
    public class ResultOrderLineDto
    {
        public int OrderLineId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public int OrderId { get; set; }
    }
}