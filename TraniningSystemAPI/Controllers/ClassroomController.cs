using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : Controller
    {
        private readonly ModelContext _context;

        public ClassroomController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Classroom> Get()
        {
            return _context.Classroom.ToList();
        }

        [Route("newest")]
        [HttpGet]
        public int GetNewest()
        {
            return _context.Classroom.OrderByDescending(u => u.ClassroomID).FirstOrDefault().ClassroomID;
        }

        [HttpPost]
        public RedirectResult AddClassroom([FromForm] Classroom classroom)
        {
            _context.Classroom.Add(classroom);
            _context.SaveChanges();
            return RedirectPermanent("https://localhost:44335/admin/add-classroom-detail.htm");
        }
    }
}
