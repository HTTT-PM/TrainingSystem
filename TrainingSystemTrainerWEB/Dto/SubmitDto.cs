namespace TraniningSystemAPI.Dto
{
    public class SubmitDto
    {
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public int TraineeID { get; set; }
        public string TraineeName { get; set; }
        public string Link { get; set; }
        public int? Point { get; set; }
    }
}
