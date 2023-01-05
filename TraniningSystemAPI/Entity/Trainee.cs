using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public class Trainee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TraineerID { get; set; }
        public string TraineeName { get; set; }
        public int? TraineeAge { get; set; }
        public int? JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        
        [ForeignKey("AccountId")]
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        
        public virtual ICollection<ClassroomParticipant> ClassroomParticipants { get; set; }
        public virtual ICollection<CourseParticipant> CourseParticipant { get; set; }
        public virtual ICollection<TraineeCourseKnowledge> TraineeCourseKnowledge { get; set; }
        public virtual ICollection<TraineeCourseSkill> TraineeCourseSkill { get; set; }
    }
}
