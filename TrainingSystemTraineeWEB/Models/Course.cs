﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TraniningSystemAPI.Entity
{
    public partial class Course
    {
        public Course()
        {
            Documents = new HashSet<Document>();
            Exercises = new HashSet<Exercise>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumberOfLesson { get; set; }
        public string Target { get; set; }
        public string Content { get; set; }
        public string AssessmentForm { get; set; }
        public string CalculatesPointGuide { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<ClassroomDetail> ClassroomDetails { get; set; }
        public virtual ICollection<CourseTrainingProgram> CourseTrainingProgram { get; set; }
    }
}