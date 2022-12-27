using Microsoft.EntityFrameworkCore;
using TraniningSystemAPI.Entity;

namespace TraniningSystemAPI.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }
        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<JobPosition> JobPosition { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Content> Content { get; set; }

        public DbSet<ClassroomDetail> ClassroomDetail { get; set; }
        public DbSet<CourseTrainingProgram> CourseTrainingProgram { get; set; }
        public DbSet<KnowledgeTrainingProgram> KnowledgeTrainingProgram { get; set; }
        public DbSet<SkillTrainingProgram> SkillTrainingProgram { get; set; }
        public DbSet<ClassroomParticipant> ClassroomParticipant { get; set; }
        public DbSet<CourseParticipant> CourseParticipant { get; set; }
        public DbSet<SkillCourse> SkillCourse { get; set; }
        public DbSet<KnowledgeCourse> KnowledgeCourse { get; set; }
        public DbSet<TraineeCourseKnowledge> TraineeCourseKnowledge { get; set; }
        public DbSet<TraineeCourseSkill> TraineeCourseSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Knowledge>().ToTable("Knowledge");
            modelBuilder.Entity<TrainingProgram>().ToTable("TrainingProgram");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<Classroom>().ToTable("Classroom");
            modelBuilder.Entity<Document>().ToTable("Document");
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<JobPosition>().ToTable("JobPosition");
            modelBuilder.Entity<Trainee>().ToTable("Trainee");
            modelBuilder.Entity<Content>().ToTable("Content");

            modelBuilder.Entity<ClassroomDetail>().ToTable("ClassroomDetail");
            modelBuilder.Entity<CourseTrainingProgram>().ToTable("CourseTrainingProgram");
            modelBuilder.Entity<KnowledgeTrainingProgram>().ToTable("KnowledgeTrainingProgram");
            modelBuilder.Entity<SkillTrainingProgram>().ToTable("SkillTrainingProgram");
            modelBuilder.Entity<ClassroomParticipant>().ToTable("ClassroomParticipant");
            modelBuilder.Entity<SkillCourse>().ToTable("SkillCourse");
            modelBuilder.Entity<KnowledgeCourse>().ToTable("KnowledgeCourse");
            modelBuilder.Entity<CourseParticipant>().ToTable("CourseParticipant");
            modelBuilder.Entity<TraineeCourseKnowledge>().ToTable("TraineeCourseKnowledge");
            modelBuilder.Entity<TraineeCourseSkill>().ToTable("TraineeCourseSkill");

            modelBuilder.Entity<TraineeCourseSkill>().HasKey(x => new { x.SkillKey, x.CourseKey, x.TraineeKey });
            modelBuilder.Entity<TraineeCourseSkill>()
                .HasOne(t => t.Skill)
               .WithMany(t => t.TraineeCourseSkill)
                .HasForeignKey(t => t.SkillKey);
            modelBuilder.Entity<TraineeCourseSkill>()
                .HasOne(t => t.Course)
                 .WithMany(t => t.TraineeCourseSkill)
                 .HasForeignKey(t => t.CourseKey);
            modelBuilder.Entity<TraineeCourseSkill>()
                .HasOne(t => t.Trainee)
                 .WithMany(t => t.TraineeCourseSkill)
                 .HasForeignKey(t => t.TraineeKey);

            modelBuilder.Entity<TraineeCourseKnowledge>().HasKey(x => new { x.KnowledgeKey, x.CourseKey, x.TraineeKey });
            modelBuilder.Entity<TraineeCourseKnowledge>()
                .HasOne(t => t.Knowledge)
               .WithMany(t => t.TraineeCourseKnowledge)
                .HasForeignKey(t => t.KnowledgeKey);
            modelBuilder.Entity<TraineeCourseKnowledge>()
                .HasOne(t => t.Course)
                 .WithMany(t => t.TraineeCourseKnowledge)
                 .HasForeignKey(t => t.CourseKey);
            modelBuilder.Entity<TraineeCourseKnowledge>()
                .HasOne(t => t.Trainee)
                 .WithMany(t => t.TraineeCourseKnowledge)
                 .HasForeignKey(t => t.TraineeKey);

            modelBuilder.Entity<KnowledgeTrainingProgram>().HasKey(x => new { x.KnowledgeKey, x.TrainingProgramKey });
            modelBuilder.Entity<KnowledgeTrainingProgram>()
                .HasOne(t => t.Knowledge)
               .WithMany(t => t.KnowledgeTrainingProgram)
                .HasForeignKey(t => t.KnowledgeKey);
            modelBuilder.Entity<KnowledgeTrainingProgram>()
                .HasOne(t => t.TrainingProgram)
                 .WithMany(t => t.KnowledgeTrainingProgram)
                 .HasForeignKey(t => t.TrainingProgramKey);

            modelBuilder.Entity<SkillTrainingProgram>().HasKey(x => new { x.SkillKey, x.TrainingProgramKey });
            modelBuilder.Entity<SkillTrainingProgram>()
                .HasOne(t => t.Skill)
               .WithMany(t => t.SkillTrainingProgram)
                .HasForeignKey(t => t.SkillKey);
            modelBuilder.Entity<SkillTrainingProgram>()
                .HasOne(t => t.TrainingProgram)
                 .WithMany(t => t.SkillTrainingProgram)
                 .HasForeignKey(t => t.TrainingProgramKey);

            modelBuilder.Entity<CourseTrainingProgram>().HasKey(x => new { x.CourseKey, x.TrainingProgramKey });
            modelBuilder.Entity<CourseTrainingProgram>()
                .HasOne(t => t.Course)
               .WithMany(t => t.CourseTrainingProgram)
                .HasForeignKey(t => t.CourseKey);
            modelBuilder.Entity<CourseTrainingProgram>()
                .HasOne(t => t.TrainingProgram)
                 .WithMany(t => t.CourseTrainingProgram)
                 .HasForeignKey(t => t.TrainingProgramKey);

            modelBuilder.Entity<SkillCourse>().HasKey(x => new { x.SkillKey, x.CourseKey });
            modelBuilder.Entity<SkillCourse>()
                .HasOne(t => t.Skill)
               .WithMany(t => t.SkillCourse)
                .HasForeignKey(t => t.SkillKey);
            modelBuilder.Entity<SkillCourse>()
                .HasOne(t => t.Course)
                 .WithMany(t => t.SkillCourse)
                 .HasForeignKey(t => t.CourseKey);

            modelBuilder.Entity<KnowledgeCourse>().HasKey(x => new { x.KnowledgeKey, x.CourseKey });
            modelBuilder.Entity<KnowledgeCourse>()
                .HasOne(t => t.Knowledge)
               .WithMany(t => t.KnowledgeCourse)
                .HasForeignKey(t => t.KnowledgeKey);
            modelBuilder.Entity<KnowledgeCourse>()
                .HasOne(t => t.Course)
                 .WithMany(t => t.KnowledgeCourse)
                 .HasForeignKey(t => t.CourseKey);

            modelBuilder.Entity<ClassroomDetail>().HasKey(x => new { x.ClassroomKey, x.CourseKey });
           modelBuilder.Entity<ClassroomDetail>()
               .HasOne(t => t.Classroom)
              .WithMany(t => t.ClassroomDetails)
               .HasForeignKey(t => t.ClassroomKey);
           modelBuilder.Entity<ClassroomDetail>()
               .HasOne(t => t.Course)
                .WithMany(t => t.ClassroomDetails)
                .HasForeignKey(t => t.CourseKey);

           modelBuilder.Entity<ClassroomParticipant>().HasKey(x => new { x.ClassroomKey, x.TraineeKey });
            modelBuilder.Entity<ClassroomParticipant>()
                .HasOne(t => t.Classroom)
               .WithMany(t => t.ClassroomParticipants)
                .HasForeignKey(t => t.ClassroomKey);
            modelBuilder.Entity<ClassroomParticipant>()
                .HasOne(t => t.Trainee)
                .WithMany(t => t.ClassroomParticipants)
               .HasForeignKey(t => t.TraineeKey);

            modelBuilder.Entity<CourseParticipant>().HasKey(x => new { x.CourseKey, x.TraineeKey });
            modelBuilder.Entity<CourseParticipant>()
                .HasOne(t => t.Course)
               .WithMany(t => t.CourseParticipant)
                .HasForeignKey(t => t.CourseKey);
            modelBuilder.Entity<CourseParticipant>()
                .HasOne(t => t.Trainee)
                .WithMany(t => t.CourseParticipant)
               .HasForeignKey(t => t.TraineeKey);

            modelBuilder.Entity<Trainee>()
              .HasOne(t => t.Department)
               .WithMany(t => t.Trainees)
               .HasForeignKey(t => t.DepartmentId);

            modelBuilder.Entity<Trainee>()
               .HasOne(t => t.JobPosition)
              .WithMany(t => t.Trainees)
              .HasForeignKey(t => t.JobPositionId);

            modelBuilder.Entity<TrainingProgram>()
                .HasOne(t => t.Department)
                .WithMany(t => t.TrainingPrograms)
               .HasForeignKey(t => t.DepartmentID);

            modelBuilder.Entity<TrainingProgram>()
                .HasOne(t => t.JobPosition)
                .WithMany(t => t.TrainingPrograms)
                .HasForeignKey(t => t.JobPositionID);
        }
    }
}

