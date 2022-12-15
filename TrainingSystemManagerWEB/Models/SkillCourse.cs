namespace TraniningSystemAPI.Entity
{
    public class SkillCourse
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int SkillKey { get; set; }
        public Skill Skill { get; set; }
    }
}
