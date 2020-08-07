using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class User : IdentityUser
    {
        public ICollection<NotificationsUsers> NotificationsUsers { get; set; }
    }
}
