using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public class CourseParticipant
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public string ResultOfEvaluation { get; set; }
        public bool IsComplete { get; set; }
        public int Point { get; set; }
        
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        
        public Account Account { get; set; }
    }
}
