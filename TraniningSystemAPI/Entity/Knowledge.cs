using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Knowledge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KnowledgeID { get; set; }
        public string KnowledgeName { get; set; }
        public virtual ICollection<KnowledgeTrainingProgram> KnowledgeTrainingProgram { get; set; }
        public virtual ICollection<KnowledgeCourse> KnowledgeCourse { get; set; }
    }
}

