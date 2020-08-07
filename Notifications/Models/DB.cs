using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class DB : IdentityDbContext<User>
    {
        public DB(DbContextOptions<DB> options)
      : base(options)
        { }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationsUsers> NotificationsUsers { get; set; }
    }
}
