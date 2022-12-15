namespace TraniningSystemAPI.Entity
{
    public class KnowledgeCourse
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int KnowledgeKey { get; set; }
        public Knowledge Knowledge { get; set; }
    }
}
