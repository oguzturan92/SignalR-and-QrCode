using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.ContactDto
{
    public class GetByIdContactDto
    {
        public int ContactId { get; set; }
        public string ContactMap { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactAddress { get; set; }
    }
}