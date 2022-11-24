using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TraniningSystemAPI.Entity
{
    public class Trainee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TraineerID { get; set; }
        public string TraineeName { get; set; }
        public int TraineeAge { get; set; }
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<ClassroomParticipant> ClassroomParticipants { get; set; }
    }
}
