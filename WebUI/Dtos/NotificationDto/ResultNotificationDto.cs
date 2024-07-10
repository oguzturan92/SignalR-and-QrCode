using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.NotificationDto
{
    public class ResultNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationContent { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}