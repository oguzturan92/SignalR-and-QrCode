using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.NotificationDto
{
    public class GetByIdNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationContent { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}