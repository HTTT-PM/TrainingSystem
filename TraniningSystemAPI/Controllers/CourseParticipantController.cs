using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;
namespace TraniningSystemAPI.Controllers
{
    [Route("api/course-participant")]
    [ApiController]
    public class CourseParticipantController : Controller
    {
        private readonly ModelContext _context;

        public CourseParticipantController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EvaluateDto> GetCourseResult()
        {
            var result = from cp in _context.CourseParticipant
                         join c in _context.Course on cp.CourseKey equals c.CourseID
                         join t in _context.Trainee on cp.TraineeKey equals t.TraineerID
                         join j in _context.JobPosition on t.JobPositionId equals j.JobPositionID
                         where cp.IsComplete
                         select new EvaluateDto()
                         {
                             CourseID = c.CourseID,
                             CourseName = c.CourseName,
                             TraineeID = t.TraineerID,
                             TraineeName = t.TraineeName,
                             ResultOfEvaluation = cp.ResultOfEvaluation,
                             JobPositionName = j.JobPositionName,
                             Point = cp.Point
                         };
            return result;
        }

        [HttpGet("job/{JobPositionID:int}")]
        public IEnumerable<EvaluateDto> GetCourseResultByJobID([FromRoute] int JobPositionID)
        {
            var result = from cp in _context.CourseParticipant
                         join c in _context.Course on cp.CourseKey equals c.CourseID
                         join t in _context.Trainee on cp.TraineeKey equals t.TraineerID
                         join j in _context.JobPosition on t.JobPositionId equals j.JobPositionID
                         where cp.IsComplete && (t.JobPositionId == JobPositionID)
                         select new EvaluateDto()
                         {
                             CourseID = c.CourseID,
                             CourseName = c.CourseName,
                             TraineeID = t.TraineerID,
                             TraineeName = t.TraineeName,
                             ResultOfEvaluation = cp.ResultOfEvaluation,
                             JobPositionName = j.JobPositionName,
                             Point = cp.Point
                         };
            return result;
        }

        [HttpGet("skill/{SkillID:int}")]
        public IEnumerable<EvaluateDto> GetCourseResultBySkillID([FromRoute] int SkillID)
        {
            var result = from cp in _context.CourseParticipant
                         join c in _context.Course on cp.CourseKey equals c.CourseID
                         join t in _context.Trainee on cp.TraineeKey equals t.TraineerID
                         join j in _context.JobPosition on t.JobPositionId equals j.JobPositionID
                         join sc in _context.SkillCourse on cp.CourseKey equals sc.CourseKey
                         where cp.IsComplete && (sc.SkillKey == SkillID)
                         select new EvaluateDto()
                         {
                             CourseID = c.CourseID,
                             CourseName = c.CourseName,
                             TraineeID = t.TraineerID,
                             TraineeName = t.TraineeName,
                             ResultOfEvaluation = cp.ResultOfEvaluation,
                             JobPositionName = j.JobPositionName,
                             Point = cp.Point
                         };
            return result;
        }

        [HttpGet("knowledge/{KnowledgeID:int}")]
        public IEnumerable<EvaluateDto> GetCourseResultByKnowledgeID([FromRoute] int KnowledgeID)
        {
            var result = from cp in _context.CourseParticipant
                         join c in _context.Course on cp.CourseKey equals c.CourseID
                         join t in _context.Trainee on cp.TraineeKey equals t.TraineerID
                         join j in _context.JobPosition on t.JobPositionId equals j.JobPositionID
                         join kc in _context.KnowledgeCourse on cp.CourseKey equals kc.CourseKey
                         where cp.IsComplete && (kc.KnowledgeKey == KnowledgeID)
                         select new EvaluateDto()
                         {
                             CourseID = c.CourseID,
                             CourseName = c.CourseName,
                             TraineeID = t.TraineerID,
                             TraineeName = t.TraineeName,
                             ResultOfEvaluation = cp.ResultOfEvaluation,
                             JobPositionName = j.JobPositionName,
                             Point = cp.Point
                         };
            return result;
        }

        [HttpGet("{CourseID:int}/{TraineeID:int}/skill")]
        public IEnumerable<EvaluateSkillDto> GetSkillEvalution([FromRoute] int CourseID, [FromRoute] int TraineeID)
        {

            var result = from tcs in _context.TraineeCourseSkill
                         join s in _context.Skill on tcs.SkillKey equals s.SkillID
                         join sc in _context.SkillCourse on new { tcs.SkillKey, tcs.CourseKey} equals new { sc.SkillKey, sc.CourseKey }
                         where (tcs.CourseKey == CourseID) && (tcs.TraineeKey == TraineeID)
                         select new EvaluateSkillDto()
                         {
                             SkillName = s.SkillName,
                             Evaluate = tcs.Evaluate,
                             Point = tcs.Point,
                             Weight = sc.Weight
                         };
            return result;
        }

        [HttpGet("{CourseID:int}/{TraineeID:int}/knowledge")]
        public IEnumerable<EvaluateKnowledgeDto> GetKnowledgeEvalution([FromRoute] int CourseID, [FromRoute] int TraineeID)
        {

            var result = from tck in _context.TraineeCourseKnowledge
                         join k in _context.Knowledge on tck.KnowledgeKey equals k.KnowledgeID
                         join kc in _context.KnowledgeCourse on new { tck.KnowledgeKey, tck.CourseKey } equals new { kc.KnowledgeKey, kc.CourseKey }
                         where (tck.CourseKey == CourseID) && (tck.TraineeKey == TraineeID)
                         select new EvaluateKnowledgeDto()
                         {
                             KnowledgeName = k.KnowledgeName,
                             Evaluate = tck.Evaluate,
                             Point = tck.Point,
                             Weight = kc.Weight
                         };
            return result;
        }
        //Post: api/course
        [HttpPost]
        public RedirectResult AddCourseParticipant([FromForm] CourseParticipant course)
        {
            _context.CourseParticipant.Add(course);
            _context.SaveChanges();
            return RedirectPermanent("https://localhost:44331/trainee/add-courseparticipant.htm");
        }
    }
}
