using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;


namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TrainingController : Controller
    {

        private readonly ModelContext _context;

        public TrainingController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/trainning
        [HttpGet]
        public IEnumerable<TrainingProgramDto> GetTrainingDetails()
        {
            var result = from t in _context.TrainingProgram
                         select new TrainingProgramDto()
                         {
                             TrainingID = t.TrainingID,
                             TrainingName = t.TrainingName,
                             JobPositionName = t.JobPosition.JobPositionName,
                             DepartmentName = t.Department.DepartmentName
                         };
            return result;
        }

        // GET: api/trainning/{TrainingID}/skill
        [HttpGet("{TrainingProgramID:int}/skill")]
        public IEnumerable<SkillDto> GetSkillOfTrainingDByID([FromRoute] int TrainingProgramID)
        {
            var result = from t in _context.SkillTrainingProgram
                         where t.TrainingProgramKey == TrainingProgramID
                         select new SkillDto()
                         {
                             SkillID = t.Skill.SkillID,
                             SkillName = t.Skill.SkillName,
                         };
            return result;
        }

        // GET: api/trainning/{TrainingID}/knowledge
        [HttpGet("{TrainingProgramID:int}/knowledge")]
        public IEnumerable<KnowledgeDto> GetKnowledgelOfTrainingDByID([FromRoute] int TrainingProgramID)
        {
            var result = from t in _context.KnowledgeTrainingProgram
                         where t.TrainingProgramKey == TrainingProgramID
                         select new KnowledgeDto()
                         {
                             KnowledgeID = t.Knowledge.KnowledgeID,
                             KnowledgeName = t.Knowledge.KnowledgeName,
                         };
            return result;
        }

        // GET: api/trainning/{TrainingID}/course
        [HttpGet("{TrainingProgramID:int}/course")]
        public IEnumerable<CourseDto> GetCourselOfTrainingDByID([FromRoute] int TrainingProgramID)
        {
            var result = from t in _context.CourseTrainingProgram
                         where t.TrainingProgramKey == TrainingProgramID
                         select new CourseDto()
                         {
                             CourseID = t.Course.CourseID,
                             CourseName = t.Course.CourseName,
                         };
            return result;
        }

        //Post: api/training
        [HttpPost]
        public IEnumerable<TrainingProgram> AddTrainingProgram(TrainingProgram train)
        {
            _context.TrainingProgram.Add(train);
            _context.SaveChanges();
            return _context.TrainingProgram.ToList();
        }

        //Delete: api/trainning/
        [HttpDelete("{TrainingID:int}")]
        public string DeleteTrainingProgram([FromRoute] int TrainingID)
        {
            TrainingProgram checkTrainingProgram = _context.TrainingProgram.Find(TrainingID);
            if (checkTrainingProgram != null)
            {
                _context.TrainingProgram.Remove(checkTrainingProgram);
                _context.SaveChanges();
            }
            return "OK";
        }

        //Delete: api/trainning/TrainingID/{SkillID}
        [HttpDelete("{TrainingID:int}/{SkillID:int}")]
        public string DeleteSkillTrainingProgram([FromRoute] int TrainingProgramKey, [FromRoute] int SkillKey)
        {
            SkillTrainingProgram checkSkillTrainingProgram = _context.SkillTrainingProgram.Find(TrainingProgramKey, SkillKey);
            if (checkSkillTrainingProgram != null)
            {
                _context.SkillTrainingProgram.Remove(checkSkillTrainingProgram);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}



