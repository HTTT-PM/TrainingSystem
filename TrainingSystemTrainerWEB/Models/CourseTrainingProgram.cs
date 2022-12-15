namespace TraniningSystemAPI.Entity
{
    public class CourseTrainingProgram
    {
        public int TrainingProgramKey { get; set; }
        public TrainingProgram TrainingProgram { get; set; }
        public int CourseKey { get; set; }
        public Course Course { get; set; }
    }
}
