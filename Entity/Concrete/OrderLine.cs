using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}