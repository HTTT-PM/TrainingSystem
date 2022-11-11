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

        /// <summary>
        /// GET LIST CLASSROOM 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <return>
        /// 
        /// </return>
        [HttpGet]
        public IEnumerable<Classroom> Get()
        {
            return _context.Classroom.ToList();
        }

        [HttpPost]
        public IEnumerable<Classroom> AddClassroom([FromBody] Classroom classroom)
        {
            _context.Classroom.Add(classroom);
            _context.SaveChanges();
            return _context.Classroom.ToList();
        }
    }
}
