using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Dto;
using TraniningSystemAPI.Entity;
using System;

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
        public IEnumerable<CourseViewModel> Get(int? classId)
        {
            var query = _context.Course.AsQueryable();

            if (classId.HasValue)
            {
                query = query.Where(item => 
                                                    item.ClassroomDetails
                                                        .Any(c => c.Classroom.ClassroomID == classId));
            } 
            
            return query.Select(item => new CourseViewModel
            {
                CourseID = item.CourseID,
                NumberOfLesson = item.NumberOfLesson,
                Target = item.Target,
                Content = item.Content,
                AssessmentForm = item.AssessmentForm,
                CourseName = item.CourseName,
                CalculatesPointGuide = item.CalculatesPointGuide,
                AccountIds = item.CourseParticipant.Select(a => a.AccountId).ToList()
            })
                .ToList();
            
        }

        // GET: api/course
        [HttpGet("result")]
        public IEnumerable<object> CourseResult(int userId)
        {
            return _context.CourseParticipant
                .Where(item => item.AccountId == userId)
                .Select(item => new
                { 
                    Course = item.Course.CourseName,
                    Point = item.Point,
                    IsComplete = item.IsComplete,
                    ResultOfEvaluation = item.ResultOfEvaluation,
                })
                .ToList();
        }

        // GET: api/course/{CourseID}
        [HttpGet("{CourseID}")]
        public Course GetCourseByID([FromRoute] int CourseID)
        {
            Course course = _context.Course.Find(CourseID);
            if (course == null) return null;

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
            return _context.Course
                .Where(c => c.CourseName.Contains(searchString))
                .ToList();
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
            return RedirectPermanent("https://localhost:44322/trainer/add-course.htm");
        }


        [HttpPost("join")]
        public IActionResult JoinCourse([FromBody] CourseParticipantViewModel model)
        {
            var trainee = _context.Trainee.First(item => item.AccountId == model.AccountId);
            Console.WriteLine(trainee.AccountId);
            _context.CourseParticipant.Add(new CourseParticipant()
            {
                CourseKey = model.CourseKey,
                TraineeKey = trainee.TraineerID,
                AccountId = model.AccountId
            });
            _context.SaveChanges();
            return Ok(model);
        }
    }

    public class CourseParticipantViewModel
    {
        public int CourseKey { get; set; }
        public int TraineeKey { get; set; }
        public int AccountId { get; set; }
    }

    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfLesson { get; set; }
        public string Target { get; set; }
        public string Content { get; set; }
        public string AssessmentForm { get; set; }
        public string CalculatesPointGuide { get; set; }
        public List<int>? AccountIds { get; set; }
    }
}