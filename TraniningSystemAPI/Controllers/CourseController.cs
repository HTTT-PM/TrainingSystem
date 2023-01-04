using Microsoft.AspNetCore.Mvc;
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
            if(course==null) return null;

            List<Document> documents = _context.Document.Where(x => x.CourseID == CourseID).ToList();
            if (documents != null) course.Documents = documents;

            List<Exercise> exercises = _context.Exercise.Where(x => x.CourseID == CourseID).ToList();
            if (exercises != null) course.Exercises = exercises;

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
                         };
            return result;
        }


        // GET: api/course/{SkillID}
        [HttpGet("skill/{SkillID:int}")]
        public IEnumerable<Course> GetCourseFilterRelateToSkill([FromRoute] int SkillID)
        {
            var result = from C in _context.Course
                         join CTP in _context.CourseTrainingProgram on C.CourseID equals CTP.CourseKey
                         join STP in _context.SkillTrainingProgram on CTP.TrainingProgramKey equals STP.TrainingProgramKey
                         where STP.SkillKey == SkillID
                         select new Course()
                         {
                             CourseID = C.CourseID,
                             CourseName = C.CourseName,
                             NumberOfLesson = C.NumberOfLesson,
                             AssessmentForm = C.AssessmentForm,
                         };

            return result.Distinct();
        }


        [HttpGet("knowledge/{KnowledgeID:int}")]
        public IEnumerable<CourseDto> GetCourseFilterRelateToKnowledge([FromRoute] int KnowledgeID)
        {
            var result = from C in _context.Course
                         join CTP in _context.CourseTrainingProgram on C.CourseID equals CTP.CourseKey
                         join KTP in _context.KnowledgeTrainingProgram on CTP.TrainingProgramKey equals KTP.TrainingProgramKey
                         where KTP.KnowledgeKey == KnowledgeID
                         select new CourseDto()
                         {
                             CourseID = C.CourseID,
                             CourseName = C.CourseName,
                         };

            return result.Distinct();
        }

        // GET: api/course/{JobPositionID}
        [HttpGet("{JobPositionID:int}")]
        public IEnumerable<CourseDto> GetCourseFilterRelateToJobPosition([FromRoute] int JobPositionID)
        {
            var result = from C in _context.Course
                         join CTP in _context.CourseTrainingProgram on C.CourseID equals CTP.CourseKey
                         join TP in _context.TrainingProgram on CTP.TrainingProgramKey equals TP.TrainingID
                         join J in _context.JobPosition on TP.JobPositionID equals J.JobPositionID
                         where J.JobPositionID == JobPositionID
                         select new CourseDto()
                         {
                             CourseID = C.CourseID,
                             CourseName = C.CourseName,
                         };
            return result.Distinct();
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
                         };
            return result;
        }

        // GET: api/course/search
        [HttpGet("search")]
        public IEnumerable<Course> SearchCourse(string searchString)
        {
            return _context.Course.Where(c => c.CourseName.Contains(searchString)).ToList();
        }

        // PUT: api/course/{courseID}
        [HttpPut("{CourseID:int}")]
        public string Update([FromRoute] int CourseID, string CourseName)
        {
            Course checkCourse = _context.Course.Find(CourseID);
            if (checkCourse != null)
            {
                checkCourse.CourseName = CourseName;
                _context.SaveChanges();
                return "OK";
            }
            return "NOTOK";
        }

        //Post: api/course
        [HttpPost]
        public RedirectResult AddCourse([FromForm] Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
            return RedirectPermanent("https://localhost:44331/trainer/add-course.htm");
        }
    }
}
