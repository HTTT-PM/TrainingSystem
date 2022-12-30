using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : Controller
    {
        private readonly ModelContext _context;

        public TraineeController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/trainee
        [HttpGet]
        public IEnumerable<TraineeDto> Get()
        {
            var result = from t in _context.Trainee
                         select new TraineeDto()
                         {
                            TraineeID = t.TraineerID,
                            TraineeName = t.TraineeName,
                            JobPositionName = t.JobPosition.JobPositionName,
                            DepartmentName = t.Department.DepartmentName,
                            GetAccessToHCMData = t.GetAccessToHCMData
                         };

            return result;
        }

    }
}
