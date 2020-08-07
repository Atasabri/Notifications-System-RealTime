using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class NotificationsUsers
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public Guid NotificationID { get; set; }
        [ForeignKey(nameof(NotificationID))]
        public Notification Notification { get; set; }
    }
}
