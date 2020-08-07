using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class Notification
    {
        [Key]
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string SenderName { get; set; }

        public ICollection<NotificationsUsers> NotificationsUsers { get; set; }
    }
}
