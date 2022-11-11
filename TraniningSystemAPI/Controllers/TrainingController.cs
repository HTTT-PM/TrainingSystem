using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;




namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrainingController : Controller
    {

        private readonly ModelContext _context1;

        public TrainingController(ModelContext context1)
        {
            _context1 = context1;
        }

        // GET: api/trainning
        [HttpGet]
        public IEnumerable<TrainingProgram> GetTraing()
        {
            return _context1.TrainingProgram.ToList();
        }

        //Post: api/trainning
        [HttpPost]

        public IEnumerable<TrainingProgram> AddTrainingProgram(TrainingProgram train)
        {
            _context1.TrainingProgram.Add(train);
            _context1.SaveChanges();
            return _context1.TrainingProgram.ToList();
        }
    }
}



