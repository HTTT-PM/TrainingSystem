using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/course-participant")]
    [ApiController]
    public class CourseParticipant : Controller
    {
        private readonly ModelContext _context;

        public CourseParticipant(ModelContext context)
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
                             JobPositionName = j.JobPositionName
                         };
            return result;
        }

        [HttpGet("{CourseID:int}/{TraineeID:int}/skill")]
        public IEnumerable<EvaluateSkillDto> GetSkillEvalution([FromRoute] int CourseID, [FromRoute] int TraineeID)
        {

            var result = from tcs in _context.TraineeCourseSkill
                         join s in _context.Skill on tcs.SkillKey equals s.SkillID
                         where (tcs.CourseKey == CourseID) && (tcs.TraineeKey == TraineeID)
                         select new EvaluateSkillDto()
                         {
                             SkillName = s.SkillName,
                             Evaluate = tcs.Evaluate
                         };
            return result;
        }

        [HttpGet("{CourseID:int}/{TraineeID:int}/knowledge")]
        public IEnumerable<EvaluateKnowledgeDto> GetKnowledgeEvalution([FromRoute] int CourseID, [FromRoute] int TraineeID)
        {

            var result = from tck in _context.TraineeCourseKnowledge
                         join k in _context.Knowledge on tck.KnowledgeKey equals k.KnowledgeID
                         where (tck.CourseKey == CourseID) && (tck.TraineeKey == TraineeID)
                         select new EvaluateKnowledgeDto()
                         {
                             KnowledgeName = k.KnowledgeName,
                             Evaluate = tck.Evaluate
                         };
            return result;
        }
    }
}
