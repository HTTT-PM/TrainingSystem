using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TraniningSystemAPI.Entity
{
    public partial class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public virtual ICollection<SkillTrainingProgram> SkillTrainingProgram { get; set; }
    }
}
