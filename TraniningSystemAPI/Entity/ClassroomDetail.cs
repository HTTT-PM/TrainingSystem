using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class ClassroomDetail
    {
        public int ClassroomKey { get; set; }
        public Classroom Classroom { get; set; }
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int Priority { get; set; }
    }
}
