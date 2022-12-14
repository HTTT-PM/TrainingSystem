﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TraniningSystemAPI.Data;
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
            if(course==null) return null;

            List<Document> documents = _context.Document.Where(x => x.CourseID == CourseID).ToList();
            if (documents != null) course.Documents = documents;

            List<Exercise> exercises = _context.Exercise.Where(x => x.CourseID == CourseID).ToList();
            if (exercises != null) course.Exercises = exercises;

            return course;
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
