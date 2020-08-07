using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Notifications.Hubs;
using Notifications.Models;

namespace Notifications.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly DB _context;
        private readonly UserManager<User> _userManager;
        private IHubContext<NotificationHub> _hubContext;

        public NotificationsController(DB context,UserManager<User> userManager, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        // GET: Notifications
        public IActionResult Index()
        {
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(_context.Notifications.Include(x=>x.NotificationsUsers).Where(x=>x.NotificationsUsers.Any(a=>a.UserID ==userid)));
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Text")] Notification notification,List<string> UsersIds)
        {
            if (ModelState.IsValid)
            {
                notification.ID = Guid.NewGuid();
                notification.SenderName = User.Identity.Name;
                _context.Add(notification);
                foreach (var item in UsersIds)
                {
                   await  _context.NotificationsUsers.AddAsync(new NotificationsUsers { UserID = item, NotificationID = notification.ID });
                }
                await _context.SaveChangesAsync();
                await _hubContext.Clients.Users(UsersIds).SendAsync("ReceiveMessage", notification.SenderName, notification.Text);
                return RedirectToAction(nameof(Index));
            }
            return View(notification);
        }
    }
}
