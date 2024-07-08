using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.TableDto
{
    public class ResultTableDto
    {
        public int TableId { get; set; }
        public string TableTitle { get; set; }
        public bool TableStatus { get; set; }
    }
}