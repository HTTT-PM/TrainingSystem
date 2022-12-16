namespace TraniningSystemAPI.Entity
{
    public class TraineeCourseSkill
    {
        public int CourseKey { get; set; }
        public Course Course { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
        public int SkillKey { get; set; }
        public Skill Skill { get; set; }
        public string Evaluate { get; set; }
    }
}
