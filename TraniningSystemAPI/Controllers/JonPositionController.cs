using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/job-position")]
    [ApiController]
    public class JonPositionController : ControllerBase
    {
        private readonly ModelContext _context;

        public JonPositionController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<JobPosition> Get()
        {
            return _context.JobPosition.ToList();
        }
    }
}
