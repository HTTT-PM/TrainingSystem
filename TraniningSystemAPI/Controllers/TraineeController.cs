using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;
using static System.Net.WebRequestMethods;

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


        [HttpGet("{TraineeID:int}/course/{CourseID:int}/exercise")]
        public IEnumerable<TraineeExerciseDto> GetExerciseByTraineeID([FromRoute] int TraineeID , int CourseID )
        {
            var result = from C in _context.Course 
                         join CP in _context.CourseParticipant on C.CourseID equals CP.CourseKey
                         join TE in _context.TraineeExercise on CP.TraineeKey equals TE.TraineeKey
                         join E in _context.Exercise on TE.ExerciseKey equals E.ExerciseID
                         join Ct in _context.Content on E.ContentID equals Ct.ContentID
                         where TE.TraineeKey == TraineeID && C.CourseID == CourseID
                         select new TraineeExerciseDto()
                         {
                             TraineeID = TraineeID,
                             Point= TE.Point,
                             ExerciseName = E.ExerciseName,
                             ContentName = Ct.ContentName,

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
