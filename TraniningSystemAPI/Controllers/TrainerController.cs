using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : Controller
    {
        private readonly ModelContext _context;

        public TrainerController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public IEnumerable<Trainer> Search(string searchString)
        {
            return _context.Trainer.Where(c => c.TrainerName.Contains(searchString)).ToList();
        }
    }
}
