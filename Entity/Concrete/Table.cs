using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableTitle { get; set; }
        public bool TableStatus { get; set; }
        public bool TableIsItFull { get; set; }
        public string TableColor { get; set; }
    }
}