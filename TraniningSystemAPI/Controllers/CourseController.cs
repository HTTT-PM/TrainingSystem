using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ModelContext _context;

        public CourseController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/classroom
        [HttpGet]
        public IEnumerable<Course> Get(string searchString)
        {
            return _context.Course.Where(c=> c.CourseName.Contains(searchString)).ToList();
        }
    }
}
