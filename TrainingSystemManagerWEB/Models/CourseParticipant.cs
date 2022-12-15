namespace TraniningSystemAPI.Entity
{
    public class CourseParticipant
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public string ResultOfEvaluation { get; set; }
    }
}
