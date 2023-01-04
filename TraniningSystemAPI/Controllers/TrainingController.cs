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

        // GET: api/trainning/{TrainingID}
        [HttpGet("{TrainingProgramID:int}")]
        public IEnumerable<TrainingProgramDto> GetTPByTrainingDByID([FromRoute] int TrainingProgramID)
        {
            var result = from t in _context.TrainingProgram
                         where t.TrainingID == TrainingProgramID
                         select new TrainingProgramDto()
                         {
                             TrainingID = t.TrainingID,
                             TrainingName = t.TrainingName,
                             DepartmentName= t.Department.DepartmentName,
                             JobPositionName= t.JobPosition.JobPositionName,
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

        //Post: api/training/{TrainingProgramKey}/skill/{SkillKey}
        [HttpPost("{TrainingProgramKey:int}/skill/{SkillKey:int}")]
        public string AddSkill([FromRoute] int TrainingProgramKey, [FromRoute] int SkillKey)
        {
            SkillTrainingProgram checkSkillTrainingProgram = _context.SkillTrainingProgram.Find(SkillKey, TrainingProgramKey);

            if (checkSkillTrainingProgram == null)
            {
                SkillTrainingProgram skillTraining = new SkillTrainingProgram { TrainingProgramKey=TrainingProgramKey, SkillKey=SkillKey };
                _context.SkillTrainingProgram.Add(skillTraining);
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        //Post: api/training/{TrainingProgramKey}/knowledge/{KnowledgeKey}
        [HttpPost("{TrainingProgramKey:int}/knowledge/{KnowledgeKey:int}")]
        public string AddKnowledge([FromRoute] int TrainingProgramKey, [FromRoute] int KnowledgeKey)
        {
            KnowledgeTrainingProgram checkKnowledgeTrainingProgram = _context.KnowledgeTrainingProgram.Find(KnowledgeKey, TrainingProgramKey);

            if (checkKnowledgeTrainingProgram == null)
            {
                KnowledgeTrainingProgram knowledgeTraining = new KnowledgeTrainingProgram { TrainingProgramKey = TrainingProgramKey, KnowledgeKey = KnowledgeKey };
                _context.KnowledgeTrainingProgram.Add(knowledgeTraining);
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        //Post: api/training/{TrainingProgramKey}/course/{CourseKey}
        [HttpPost("{TrainingProgramKey:int}/course/{CourseKey:int}")]
        public string AddCourse([FromRoute] int TrainingProgramKey, [FromRoute] int CourseKey)
        {
            CourseTrainingProgram checkCourseTrainingProgram = _context.CourseTrainingProgram.Find(CourseKey, TrainingProgramKey);

            if (checkCourseTrainingProgram == null)
            {
                CourseTrainingProgram CourseTrainin = new CourseTrainingProgram { TrainingProgramKey = TrainingProgramKey, CourseKey = CourseKey };
                _context.CourseTrainingProgram.Add(CourseTrainin);
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
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
        [HttpDelete("{TrainingProgramKey:int}/skill/{SkillKey:int}")]
        public string DeleteSkillTrainingProgram([FromRoute] int TrainingProgramKey, [FromRoute] int SkillKey)
        {
            SkillTrainingProgram checkSkillTrainingProgram = _context.SkillTrainingProgram.Find(SkillKey, TrainingProgramKey);

            if (checkSkillTrainingProgram != null)
            {
                _context.SkillTrainingProgram.Remove(checkSkillTrainingProgram);
                _context.SaveChanges();
            }
            return "OK";
        }

        //Delete: api/training/TrainingID/{KnowledgeID}
        [HttpDelete("{TrainingProgramKey:int}/knowledge/{KnowledgeKey:int}")]
        public string DeleteKnowledgeTrainingProgram([FromRoute] int TrainingProgramKey, [FromRoute] int KnowledgeKey)
        {
            KnowledgeTrainingProgram checkKnowledgeTrainingProgram = _context.KnowledgeTrainingProgram.Find(KnowledgeKey, TrainingProgramKey);

            if (checkKnowledgeTrainingProgram != null)
            {
                _context.KnowledgeTrainingProgram.Remove(checkKnowledgeTrainingProgram);
                _context.SaveChanges();
            }
            return "OK";
        }

        //Delete: api/training/TrainingID/{CourseID}
        [HttpDelete("{TrainingProgramKey:int}/course/{CourseKey:int}")]
        public string DeleteCourseTrainingProgram([FromRoute] int TrainingProgramKey, [FromRoute] int CourseKey)
        {
            CourseTrainingProgram checkCourseTrainingProgram = _context.CourseTrainingProgram.Find(CourseKey, TrainingProgramKey);

            if (checkCourseTrainingProgram != null)
            {
                _context.CourseTrainingProgram.Remove(checkCourseTrainingProgram);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}



