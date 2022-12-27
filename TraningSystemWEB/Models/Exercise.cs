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
        public int Weight { get; set; }
        public int? ContentID { get; set; }
        public ICollection<Content> Content { get; set; }
        public int? SkillID { get; set; }
        public ICollection<Skill> Skill { get; set; }
        public int? KnowledgeID { get; set; }
        public ICollection<Knowledge> Knowledge { get; set; }
    }
}
