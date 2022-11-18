using Microsoft.AspNetCore.Mvc;
using System;
using TraniningSystemAPI.Data;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomDetailController : Controller
    {
        private readonly ModelContext _context;

        public ClassroomDetailController(ModelContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string AddClassroomDetail(ClassroomDetail classroomDetail)
        {
            ClassroomDetail checkClassRoomDetail = _context.ClassroomDetail.Find(classroomDetail.ClassroomKey, classroomDetail.CourseKey);
            if(checkClassRoomDetail != null)
            {
                return "NOTOK";
            }

            Classroom checkClassroom = _context.Classroom.Find(classroomDetail.ClassroomKey);
            if (checkClassroom == null)
            {
                return "NOTOK";
            }

            _context.ClassroomDetail.Add(classroomDetail);
            _context.SaveChanges();
            return "OK";
        }

        [HttpDelete("{ClassroomKey:int}/{CourseKey:int}")]
        public string DeleteClassroomDetail([FromRoute] int ClassroomKey, [FromRoute] int CourseKey)
        {
            ClassroomDetail checkClassRoomDetail = _context.ClassroomDetail.Find(ClassroomKey, CourseKey);
            if (checkClassRoomDetail != null)
            {
                _context.ClassroomDetail.Remove(checkClassRoomDetail);
                _context.SaveChanges();
            }
            return "OK";
        }
    }
}
