using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.MessageDto
{
    public class ResultMessageDto
    {
        public int MessageId { get; set; }
        public string MessageFullname { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string MessageMail { get; set; }
        public bool MessageRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}