using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public class JobPosition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int JobPositionID { get; set; }
        public string JobPositionName { get; set; }
        public string Desciption { get; set; }
        public ICollection<Trainee> Trainees { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
    }
}
