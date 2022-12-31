namespace TraniningSystemAPI.Entity
{
    public class TraineeCourseExercise
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public int ExerciseKey { get; set; }
        public Exercise Exercise { get; set; }
        public string Link { get; set; }
        public int? Point { get; set; }
    }
}
