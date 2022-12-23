using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TraniningSystemAPI.Entity
{
    public partial class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int CourseID { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
