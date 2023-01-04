namespace TraniningSystemAPI.Entity
{
    public class TraineeExercise
    {
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public int ExerciseKey { get; set; }
        public Exercise Exercise { get; set; }
        public string Link { get; set; }
        public int? Point { get; set; }
    }
}
