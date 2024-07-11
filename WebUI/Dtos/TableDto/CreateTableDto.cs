using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.TableDto
{
    public class CreateTableDto
    {
        public string TableTitle { get; set; }
        public bool TableStatus { get; set; }
        public bool TableIsItFull { get; set; }
        public string TableColor { get; set; }
    }
}