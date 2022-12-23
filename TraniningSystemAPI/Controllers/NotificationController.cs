using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;


namespace TraniningSystemAPI.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : Controller
    {
        
        private readonly ModelContext _context;
        public NotificationController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            return _context.Notification.ToList();
        }

        //Post: api/course
        [HttpPost]
        public RedirectResult AddNotification([FromForm] Notification notifi)
        {
            _context.Notification.Add(notifi);
            _context.SaveChanges();
            return RedirectPermanent("https://localhost:44322/manager/notification.htm");
        }
    }
}
