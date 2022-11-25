using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class TrainingProgram
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }
        public int? JobPositionID { get; set; }
        public JobPosition JobPosition { get; set; }
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<CourseTrainingProgram> CourseTrainingProgram { get; set; }
        public virtual ICollection<KnowledgeTrainingProgram> KnowledgeTrainingProgram { get; set; }
        public virtual ICollection<SkillTrainingProgram> SkillTrainingProgram { get; set; }
    }
}
