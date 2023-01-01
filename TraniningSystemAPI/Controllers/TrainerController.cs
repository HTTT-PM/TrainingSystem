using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;
using TraniningSystemAPI.Dto;

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

        // GET: api/trainer
        [HttpGet]
        public IEnumerable<TrainerDto> Get()
        {
            var result = from t in _context.Trainer
                         select new TrainerDto()
                         {
                             TrainerID = t.TrainerID,
                             TrainerName = t.TrainerName,
                             TrainerEmail = t.TrainerEmail
                         };

            return result;
        }

        [HttpGet("search")]
        public IEnumerable<Trainer> Search(string searchString)
        {
            return _context.Trainer.Where(c => c.TrainerName.Contains(searchString)).ToList();
        }
    }
}
