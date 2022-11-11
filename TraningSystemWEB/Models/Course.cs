using System.Collections.Generic;

namespace XTLAB
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Target { get; set; }
        public string Content { get; set; }
        public string AssessmentForm { get; set; }
        public string CalculatesPointGuide { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Exercise> Exercise { get; set; }
    }
}
