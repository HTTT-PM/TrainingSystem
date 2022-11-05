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

        // GET: api/classroom
        [HttpGet]
        public IEnumerable<Classroom> Get()
        {
            return _context.Classroom.ToList();
        }
        //[HttpPost]
        //  public string AddClassroom(Classroom classroom)
        //   {
        //_context.Classroom.Add(classroom);
        //            _context.SaveChanges();
        //            return "ADD SUCCESS";
        //   }
        //  [HttpPost]
        //   public IEnumerable<Classroom> AddClassroom(Classroom classroom)
        //  {
        //   _context.Classroom.Add(classroom);
        //   _context.SaveChanges();
        //  return _context.Classroom.ToList();
        //   }
        [HttpPost]
        void AddClassroom(Classroom classroom)
        {
            _context.Classroom.Add(classroom);
            _context.SaveChanges();

        }
    }
}
