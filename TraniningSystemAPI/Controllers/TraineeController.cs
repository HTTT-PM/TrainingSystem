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
                            TraineeID = t.TraineeID,
                            TraineeName = t.TraineeName,
                            JobPositionName = t.JobPosition.JobPositionName,
                            DepartmentName = t.Department.DepartmentName,
                            GetAccessToHCMData = t.GetAccessToHCMData
                         };

            return result;
        }

        [HttpGet("/trainee/access-hcm-data/true")]
        public IEnumerable<TraineeDto> GetTraineeAccessHCMData()
        {
            var result = from t in _context.Trainee
                         where t.GetAccessToHCMData == true
                         select new TraineeDto()
                         {
                             TraineeID = t.TraineeID,
                             TraineeName = t.TraineeName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName,
                             GetAccessToHCMData = t.GetAccessToHCMData
                         };

            return result;
        }

        [HttpGet("/trainee/access-hcm-data/false")]
        public IEnumerable<TraineeDto> GetTraineeNotAccessHCMData()
        {
            var result = from t in _context.Trainee
                         where t.GetAccessToHCMData == false
                         select new TraineeDto()
                         {
                             TraineeID = t.TraineeID,
                             TraineeName = t.TraineeName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName,
                             GetAccessToHCMData = t.GetAccessToHCMData
                         };

            return result;
        }
    }
}
