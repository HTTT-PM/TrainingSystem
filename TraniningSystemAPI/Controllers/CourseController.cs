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
    public class CourseController : Controller
    {
        private readonly ModelContext _context;

        public CourseController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/course
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _context.Course.ToList();
        }

        // GET: api/course/{CourseID}
        [HttpGet("{CourseID}")]
        public Course GetCourseByID([FromRoute] int CourseID)
        {
            Course course = _context.Course.Find(CourseID);
            if (course == null) return null;

            List<Content> contents = _context.Content.Where(x => x.CourseID == CourseID).ToList();
            if (contents != null) course.Contents = contents;

            foreach(Content content in contents)
            {
                List<Document> documents = _context.Document.Where(x => x.ContentID == content.ContentID).ToList();
                if (documents != null) content.Documents = documents;

                List<Exercise> exercises = _context.Exercise.Where(x => x.ContentID == content.ContentID).ToList();
                if (exercises != null) content.Exercises = exercises;
            }

            return course;
        }

        // GET: api/{CourseID}/skill
        [HttpGet("{CourseID:int}/skill")]
        public IEnumerable<SkillDto> GetSkillOfCourseByID([FromRoute] int CourseID)
        {
            var result = from t in _context.SkillCourse
                         where t.CourseKey == CourseID
                         select new SkillDto()
                         {
                             SkillID = t.Skill.SkillID,
                             SkillName = t.Skill.SkillName,
                             Weight = t.Weight
                         };
            return result;
        }

        // GET: api/{CourseID}/knowledge
        [HttpGet("{CourseID:int}/knowledge")]
        public IEnumerable<KnowledgeDto> GetKnowledgeOfCourseByID([FromRoute] int CourseID)
        {
            var result = from t in _context.KnowledgeCourse
                         where t.CourseKey == CourseID
                         select new KnowledgeDto()
                         {
                             KnowledgeID = t.Knowledge.KnowledgeID,
                             KnowledgeName = t.Knowledge.KnowledgeName,
                             Weight = t.Weight
                         };
            return result;
        }

        // GET: api/{CourseID}/trainee
        [HttpGet("{CourseID:int}/trainee")]
        public IEnumerable<TraineeDto> GetTraineeOfCourseByID([FromRoute] int CourseID)
        {
            var result = from t in _context.CourseParticipant
                         where t.CourseKey == CourseID
                         select new TraineeDto()
                         {
                             TraineeID = t.TraineeKey,
                             TraineeName = t.Trainee.TraineeName,
                             ResultOfEvaluation = t.ResultOfEvaluation,
                             IsComplete = t.IsComplete,
                             Point = t.Point,
                             Rank = t.Rank
                         };
            return result;
        }

        // GET: api/{CourseID}/exercise
        [HttpGet("{CourseID:int}/exercise")]
        public IEnumerable<ExerciseDto> GetExerciseListOfCourseByID([FromRoute] int CourseID)
        {
            var result = (from c in _context.Course
                         join t in _context.Content on c.CourseID equals t.CourseID
                         join e in _context.Exercise on t.ContentID equals e.ExerciseID
                         where c.CourseID == CourseID
                         select new ExerciseDto()
                         {
                             ExerciseID = e.ExerciseID,
                             ExerciseName = e.ExerciseName,
                             Link = e.Link
                         }
                        ).Distinct();
            return result;
        }

        // GET: api/course/search
        [HttpGet("search")]
        public IEnumerable<Course> SearchCourse(string searchString)
        {
            return _context.Course.Where(c => c.CourseName.Contains(searchString)).ToList();
        }

        //Post: api/course
        [HttpPost]
        public RedirectResult AddCourse([FromForm] Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
            return RedirectPermanent("https://localhost:44331/trainer/add-course.htm");
        }

        //Post: api/course/{CourseKey}/skill/{SkillKey}
        [HttpPost("{CourseKey:int}/skill/{SkillKey:int}")]
        public string AddSkill([FromRoute] int CourseKey, [FromRoute] int SkillKey, int Weight)
        {
            SkillCourse CheckSkillCourse = _context.SkillCourse.Find(SkillKey, CourseKey);

            if (CheckSkillCourse == null)
            {
                SkillCourse SkillCourse = new SkillCourse { CourseKey = CourseKey, SkillKey = SkillKey, Weight= Weight };
                _context.SkillCourse.Add(SkillCourse);
                _context.SaveChanges();
                return "OKE";
            }
            return "NOTOKE";
        }

        //Post: api/course/{CourseKey}/knowledge/{KnowledgeKey}
        [HttpPost("{CourseKey:int}/knowledge/{KnowledgeKey:int}")]
        public string AddKnowledge([FromRoute] int CourseKey, [FromRoute] int KnowledgeKey, int Weight)
        {
            KnowledgeCourse CheckKnowledgeCourse = _context.KnowledgeCourse.Find(KnowledgeKey, CourseKey);

            if (CheckKnowledgeCourse == null)
            {
                KnowledgeCourse KnowledgeCourse = new KnowledgeCourse { CourseKey = CourseKey, KnowledgeKey = KnowledgeKey, Weight = Weight };
                _context.KnowledgeCourse.Add(KnowledgeCourse);
                _context.SaveChanges();
                return "OKE";
            }
            return "NOTOKE";
        }

        //Post: api/course/{CourseID}/content
        [HttpPost("{CourseID:int}/content")]
        public int AddContent([FromRoute] int CourseID, string ContentName, [FromBody] string Description, int TrainingTime)
        {
             Content content = new Content { ContentName = ContentName, Description = Description, TrainingTime = TrainingTime, CourseID= CourseID };
             _context.Content.Add(content);
             _context.SaveChanges();
             return content.ContentID;
        }

        // PUT: api/course/{courseID}
        [HttpPut("{CourseID:int}")]
        public string Update([FromRoute] int CourseID, string CourseName, int NumberOfLesson, string Target, string AssessmentForm,[FromBody] string CalculatesPointGuide)
        {
            Course checkCourse = _context.Course.Find(CourseID);
            if (checkCourse != null)
            {
                checkCourse.CourseName = CourseName;
                checkCourse.NumberOfLesson = NumberOfLesson;
                checkCourse.Target = Target;
                checkCourse.AssessmentForm = AssessmentForm;
                checkCourse.CalculatesPointGuide = CalculatesPointGuide;
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }   

        //DELETE: api/course/{CourseID}
        [HttpDelete("{CourseID:int}")]
        public string DeleteCourse([FromRoute] int CourseID)
        {
            Course course = _context.Course.Find(CourseID);

            if (course != null)
            {
                _context.Course.Remove(course);
                _context.SaveChanges();
            }
            return "OK";
        }

        //DELETE: api/course/{CourseID}/skill/{SkillID}
        [HttpDelete("{CourseID:int}/skill/{SkillID:int}")]
        public string DeleteSKill([FromRoute] int CourseID, [FromRoute] int SkillID)
        {
            SkillCourse skillCourse = _context.SkillCourse.Find(SkillID,CourseID);

            if (skillCourse != null)
            {
                _context.SkillCourse.Remove(skillCourse);
                _context.SaveChanges();
            }
            return "OK";
        }

        //DELETE: api/course/{CourseID}/knowledge/{KnowledgeID}
        [HttpDelete("{CourseID:int}/knowledge/{KnowledgeID:int}")]
        public string DeleteKnowledge([FromRoute] int CourseID, [FromRoute] int KnowledgeID)
        {
            KnowledgeCourse knowledgeCourse = _context.KnowledgeCourse.Find(KnowledgeID, CourseID);

            if (knowledgeCourse != null)
            {
                _context.KnowledgeCourse.Remove(knowledgeCourse);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}
