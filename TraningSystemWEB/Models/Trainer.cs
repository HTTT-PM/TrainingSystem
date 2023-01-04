using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Trainer
    {
        public Trainer()
        {
            Classroom = new HashSet<Classroom>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int TrainerAge { get; set; }
        public string TrainerEmail { get; set; }
        public virtual ICollection<Classroom> Classroom { get; set; }
    }
}
