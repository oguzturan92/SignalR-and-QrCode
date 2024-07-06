using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        public string BookingFullname { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingPersonCount { get; set; }
        public bool BookingStatus { get; set; }
        public DateTime BookingDate { get; set; }
    }
}