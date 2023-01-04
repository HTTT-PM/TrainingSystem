namespace TraniningSystemAPI.Dto
{
    public class TraineeInCourse
    {
        public int TraineeID { get; set; }
        public string TraineeName { get; set; }
        public string ResultOfEvaluation { get; set; }
        public bool IsComplete { get; set; }
        public int Point { get; set; }
        public int Rank { get; set; }
    }
}
