using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class TrainingProgram
    {
        public TrainingProgram()
        {
            Knowledge = new HashSet<Knowledge>();
            Skill = new HashSet<Skill>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }
        public int? JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Knowledge> Knowledge { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
