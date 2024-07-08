using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string OrderTableNumber { get; set; }
        public bool OrderComplate { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderTotalPrice { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}