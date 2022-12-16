namespace TraniningSystemAPI.Entity
{
    public class TraineeCourseKnowledge
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public int KnowledgeKey { get; set; }
        public Knowledge Knowledge { get; set; }
        public string Evaluate { get; set; }
    }
}
