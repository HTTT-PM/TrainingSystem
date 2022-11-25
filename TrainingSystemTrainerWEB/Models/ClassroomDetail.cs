using System;

namespace TraniningSystemAPI.Entity
{
    public partial class ClassroomDetail
    {
        public int ClassroomKey { get; set; }
        public Classroom Classroom { get; set; }
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int Priority { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean StudyForm { get; set; }
    }
}
