namespace TraniningSystemAPI.Dto
{
    public class EvaluateDto
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int TraineeID { get; set; }
        public string TraineeName { get; set; }
        public string ResultOfEvaluation { get; set; }
        public string JobPositionName { get; set; }
    }
}
